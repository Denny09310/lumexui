// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;
using System.Globalization;

using LumexUI.Common;
using LumexUI.Utilities;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;

namespace LumexUI;

/// <summary>
/// Represents a base component for form input field components.
/// </summary>
/// <typeparam name="TValue">The type of the input value.</typeparam>
public abstract partial class LumexInputFieldBase<TValue> : LumexDebouncedInputBase<TValue>,
	ISlotComponent<InputFieldSlots>,
	IAsyncDisposable
{
	private const string JavaScriptFile = "./_content/LumexUI/js/components/input.js";

	/// <summary>
	/// Gets or sets content to be rendered at the start of the textbox.
	/// </summary>
	[Parameter] public RenderFragment? StartContent { get; set; }

	/// <summary>
	/// Gets or sets content to be rendered at the end of the textbox.
	/// </summary>
	[Parameter] public RenderFragment? EndContent { get; set; }

	/// <summary>
	/// Gets or sets the label for the textbox.
	/// </summary>
	[Parameter] public string? Label { get; set; }

	/// <summary>
	/// Gets or sets the placeholder for the textbox.
	/// </summary>
	[Parameter] public string? Placeholder { get; set; }

	/// <summary>
	/// Gets or sets the description for the textbox.
	/// </summary>
	[Parameter] public string? Description { get; set; }

	/// <summary>
	/// Gets or sets the error message for the textbox.
	/// This message is displayed only when the textbox is invalid.
	/// </summary>
	[Parameter] public string? ErrorMessage { get; set; }

	/// <summary>
	/// Gets or sets the variant for the textbox.
	/// </summary>
	/// <remarks>
	/// The default value is <see cref="InputVariant.Flat"/>
	/// </remarks>
	[Parameter] public InputVariant Variant { get; set; }

	/// <summary>
	/// Gets or sets the input behavior, specifying when the textbox
	/// updates its value and triggers validation.
	/// </summary>
	/// <remarks>
	/// The default value is <see cref="InputBehavior.OnChange"/>
	/// </remarks>
	[Parameter] public InputBehavior Behavior { get; set; } = InputBehavior.OnChange;

	/// <summary>
	/// Gets or sets the border radius of the textbox.
	/// </summary>
	[Parameter] public Radius? Radius { get; set; }

	/// <summary>
	/// Gets or sets the placement of the label for the textbox.
	/// </summary>
	/// <remarks>
	/// The default value is <see cref="LabelPlacement.Inside"/>
	/// </remarks>
	[Parameter] public LabelPlacement LabelPlacement { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether the textbox is full-width.
	/// </summary>
	/// <remarks>
	/// The default value is <see langword="true"/>
	/// </remarks>
	[Parameter] public bool FullWidth { get; set; } = true;

	/// <summary>
	/// Gets or sets a value indicating whether the textbox should have a clear button.
	/// </summary>
	[Parameter] public bool Clearable { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether the textbox should automatically receive focus.
	/// </summary>
	[Parameter] public bool Autofocus { get; set; }

	/// <summary>
	/// Gets or sets a callback that is fired when the value in the textbox is cleared.
	/// </summary>
	[Parameter] public EventCallback OnCleared { get; set; }

	/// <summary>
	/// Gets or sets the CSS class names for the textbox slots.
	/// </summary>
	[Parameter] public InputFieldSlots? Classes { get; set; }

	[Inject] private IJSRuntime JSRuntime { get; set; } = default!;

	/// <summary>
	/// Gets or sets the validation error mesage of the input.
	/// </summary>
	protected string? ValidationMessage { get; private set; }

	private bool HasHelper =>
		!string.IsNullOrEmpty( Description ) ||
		!string.IsNullOrEmpty( ErrorMessage ) ||
		!string.IsNullOrEmpty( ValidationMessage );
	private bool HasValue => !string.IsNullOrEmpty( CurrentValueAsString );
	private bool ClearButtonVisible => Clearable && HasValue;
	private bool FilledOrFocused =>
		Focused ||
		HasValue ||
		StartContent is not null ||
		!string.IsNullOrEmpty( Placeholder );

	private readonly RenderFragment _renderMainWrapper;
	private readonly RenderFragment _renderInputWrapper;
	private readonly RenderFragment _renderHelperWrapper;

	private string _inputType = default!;
	private IJSObjectReference _jsModule = default!;
	private Dictionary<string, ComponentSlot> _slots = [];

	/// <summary>
	/// Initializes a new instance of the <see cref="LumexInputFieldBase{TValue}"/>.
	/// </summary>
	public LumexInputFieldBase()
	{
		_renderMainWrapper = RenderMainWrapper;
		_renderInputWrapper = RenderInputWrapper;
		_renderHelperWrapper = RenderHelperWrapper;

		As = "div";
	}

	/// <inheritdoc />
	public override async Task SetParametersAsync( ParameterView parameters )
	{
		await base.SetParametersAsync( parameters );

		if( parameters.TryGetValue<LabelPlacement>( nameof( LabelPlacement ), out var labelPlacement ) )
		{
			LabelPlacement = labelPlacement;
		}
		// Default LabelPlacement to 'Outside' if the label and its placement are not set
		else if( !parameters.TryGetValue<string>( nameof( Label ), out var _ ) )
		{
			LabelPlacement = LabelPlacement.Outside;
		}
	}

	/// <inheritdoc />
	protected override void OnParametersSet()
	{
		if( DebounceDelay > 0 && Behavior is not InputBehavior.OnInput )
		{
			throw new InvalidOperationException(
				$"{GetType()} requires '{nameof( InputBehavior.OnInput )}' behavior" +
				$" to be used when '{nameof( DebounceDelay )}' is not zero." );
		}

		UpdateSlots();
	}

	/// <inheritdoc />
	protected override async Task OnAfterRenderAsync( bool firstRender )
	{
		if( firstRender )
		{
			_jsModule = await JSRuntime.InvokeAsync<IJSObjectReference>( "import", JavaScriptFile );
		}

		if( Autofocus )
		{
			await FocusAsync();
		}
	}

	/// <inheritdoc />
	protected override Task OnInputAsync( ChangeEventArgs args )
	{
		if( Behavior is not InputBehavior.OnInput )
		{
			return Task.CompletedTask;
		}

		return base.OnInputAsync( args );
	}

	/// <inheritdoc />
	protected override Task OnChangeAsync( ChangeEventArgs args )
	{
		if( Behavior is not InputBehavior.OnChange )
		{
			return Task.CompletedTask;
		}

		return base.OnChangeAsync( args );
	}

	/// <inheritdoc />
	protected override bool TryParseValueFromString( string? value, [MaybeNullWhen( false )] out TValue result )
	{
		return BindConverter.TryConvertTo( value, CultureInfo.InvariantCulture, out result );
	}

	/// <inheritdoc />
	protected override async ValueTask SetValidationMessageAsync()
	{
		ValidationMessage = await _jsModule.InvokeAsync<string>( "input.getValidationMessage", ElementReference );
		Invalid = !string.IsNullOrEmpty( ErrorMessage ) ||
				  !string.IsNullOrEmpty( ValidationMessage );

		// Re-render to add validation classes
		UpdateSlots();
	}

	/// <summary>
	/// Sets the input type for the input field.
	/// </summary>
	/// <param name="type">The input type to set (e.g., "text", "number", "password").</param>
	protected void SetInputType( string type )
	{
		_inputType = type;
	}

	private async Task FocusInputAsync()
	{
		if( !Disabled && !ReadOnly )
		{
			await FocusAsync();
		}
	}

	private async Task ClearAsync( MouseEventArgs args )
	{
		await ClearAsyncCore();
	}

	private async Task ClearAsync( KeyboardEventArgs args )
	{
		if( args.Code is "Enter" or "Space" )
		{
			await ClearAsyncCore();
		}
	}

	private async Task ClearAsyncCore()
	{
		await SetCurrentValueAsync( default );
		await OnCleared.InvokeAsync();
		await FocusAsync();
	}

	private void UpdateSlots()
	{
		var inputField = Styles.InputField.Style( TwMerge );
		_slots = inputField( new()
		{
			[nameof( Size )] = Size.ToString(),
			[nameof( Radius )] = Radius.ToString() ?? "",
			[nameof( Disabled )] = Disabled.ToString(),
			[nameof( Invalid )] = Invalid.ToString(),
			[nameof( FullWidth )] = FullWidth.ToString(),
			[nameof( Clearable )] = Clearable.ToString(),
			[nameof( Required )] = Required.ToString(),
			[nameof( Variant )] = Variant.ToString(),
			[nameof( Color )] = Color.ToString(),
			[nameof( LabelPlacement )] = LabelPlacement.ToString(),
		} );
	}

	[ExcludeFromCodeCoverage]
	private string? GetStyles( string slot )
	{
		if( !_slots.TryGetValue( slot, out var style ) )
		{
			throw new NotImplementedException();
		}

		return slot switch
		{
			nameof( InputFieldSlots.Base ) => style( Classes?.Base, Class ),
			nameof( InputFieldSlots.MainWrapper ) => style( Classes?.MainWrapper ),
			nameof( InputFieldSlots.InputWrapper ) => style( Classes?.InputWrapper ),
			nameof( InputFieldSlots.InnerWrapper ) => style( Classes?.InnerWrapper ),
			nameof( InputFieldSlots.HelperWrapper ) => style( Classes?.HelperWrapper ),
			nameof( InputFieldSlots.Label ) => style( Classes?.Label ),
			nameof( InputFieldSlots.Input ) => style( Classes?.Input ),
			nameof( InputFieldSlots.Description ) => style( Classes?.Description ),
			nameof( InputFieldSlots.ClearButton ) => style( Classes?.ClearButton ),
			nameof( InputFieldSlots.ErrorMessage ) => style( Classes?.ErrorMessage ),
			_ => throw new NotImplementedException()
		};
	}

	/// <inheritdoc />
	public async ValueTask DisposeAsync()
	{
		try
		{
			if( _jsModule is not null )
			{
				await _jsModule.DisposeAsync();
			}

			Dispose();
		}
		catch( Exception ex ) when( ex is JSDisconnectedException or OperationCanceledException )
		{
			// The JSRuntime side may routinely be gone already if the reason we're disposing is that
			// the client disconnected. This is not an error.
		}
	}
}
