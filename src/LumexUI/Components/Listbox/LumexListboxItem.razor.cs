// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;
using LumexUI.Utilities;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace LumexUI;

/// <summary>
/// A component representing an item within the <see cref="LumexListbox{T}"/>.
/// </summary>
/// <typeparam name="TValue">The type of the value associated with the listbox item.</typeparam>
[CompositionComponent( typeof( LumexListbox<> ) )]
public partial class LumexListboxItem<TValue> : LumexComponentBase, ISlotComponent<ListboxItemSlots>, IDisposable
{
	/// <summary>
	/// Gets or sets content to be rendered inside the listbox item.
	/// </summary>
	[Parameter] public RenderFragment? ChildContent { get; set; }

	/// <summary>
	/// Gets or sets content to be rendered at the start of the listbox item.
	/// </summary>
	[Parameter] public RenderFragment? StartContent { get; set; }

	/// <summary>
	/// Gets or sets content to be rendered at the end of the listbox item.
	/// </summary>
	[Parameter] public RenderFragment? EndContent { get; set; }

	/// <summary>
	/// Gets or sets a value representing the listbox item.
	/// </summary>
	[Parameter] public TValue? Value { get; set; }

	/// <summary>
	/// Gets or sets a description of the listbox item.
	/// </summary>
	[Parameter] public string? Description { get; set; }

	/// <summary>
	/// Gets or sets an appearance style of the listbox item.
	/// </summary>
	/// <remarks>
	/// The default value is <see cref="ListboxVariant.Solid"/>
	/// </remarks>
	[Parameter] public ListboxVariant Variant { get; set; }

	/// <summary>
	/// Gets or sets a color of the listbox item.
	/// </summary>
	/// <remarks>
	/// The default value is <see cref="ThemeColor.Default"/>
	/// </remarks>
	[Parameter] public ThemeColor Color { get; set; } = ThemeColor.Default;

	/// <summary>
	/// Gets or sets a value indicating whether the listbox item is disabled.
	/// </summary>
	[Parameter] public bool Disabled { get; set; }

	/// <summary>
	/// Gets or sets a callback that is fired whenever the listbox item is clicked.
	/// </summary>
	[Parameter] public EventCallback<MouseEventArgs> OnClick { get; set; }

	/// <summary>
	/// Gets or sets the CSS class names for the listbox item slots.
	/// </summary>
	[Parameter] public ListboxItemSlots? Classes { get; set; }

	[CascadingParameter] internal ListboxContext<TValue>? Context { get; set; }

	private LumexListbox<TValue>? Listbox => Context?.Owner;

	private readonly Memoizer<Dictionary<string, ComponentSlot>> _slotsMemoizer;
	private readonly RenderFragment _renderSelectedIcon;

	private Dictionary<string, ComponentSlot> _slots = [];

	/// <summary>
	/// Initializes a new instance of the <see cref="LumexListboxItem{T}"/>.
	/// </summary>
	public LumexListboxItem()
	{
		_slotsMemoizer = new Memoizer<Dictionary<string, ComponentSlot>>();
		_renderSelectedIcon = RenderSelectedIcon;

		As = "li";
	}

	/// <inheritdoc />
	public override Task SetParametersAsync( ParameterView parameters )
	{
		parameters.SetParameterProperties( this );

		if( Listbox is not null )
		{
			// Respect the Variant value if provided; otherwise, use the owner's
			Variant = parameters.TryGetValue<ListboxVariant>( nameof( Variant ), out var variant )
				? variant
				: Listbox.Variant;

			// Respect the Color value if provided; otherwise, use the owner's
			Color = parameters.TryGetValue<ThemeColor>( nameof( Color ), out var color )
				? color
				: Listbox.Color;
		}

		return base.SetParametersAsync( ParameterView.Empty );
	}

	/// <inheritdoc />
	protected override void OnInitialized()
	{
		ContextNullException.ThrowIfNull( Context, nameof( LumexListboxItem<TValue> ) );
	}

	/// <inheritdoc />
	protected override void OnParametersSet()
	{
		// Perform a re-building only if the dependencies have changed
		_slots = _slotsMemoizer.Memoize( GetSlots, [
			GetDisabledState(),
			Variant,
			Color,
			Class,
			Classes
		] );
	}

	internal bool GetSelectedState() => Context?.SelectionMode is SelectionMode.Single
		? Listbox?.Value?.Equals( Value ) is true
		: Listbox?.Values?.Contains( Value ) is true;

	internal bool GetDisabledState() =>
		Disabled || Listbox?.DisabledItems?.Contains( Value ) is true;

	private async Task OnClickAsync( MouseEventArgs args )
	{
		if( GetDisabledState() )
		{
			return;
		}

		if( Context?.SelectionMode is not SelectionMode.None )
		{
			await SelectAsync();
		}

		await OnClick.InvokeAsync( args );
	}

	private Task SelectAsync()
	{
		Debug.Assert( Context is not null && Listbox is not null );

		if( Context.SelectionMode is SelectionMode.Single )
		{
			return Listbox.SetSelectedValue( Value );
		}
		else if( Context.SelectionMode is SelectionMode.Multiple )
		{
			return Listbox.SetSelectedValues( Value );
		}

		return Task.CompletedTask;
	}

	private Dictionary<string, ComponentSlot> GetSlots()
	{
		var listboxItem = Styles.ListboxItem.Style( TwMerge );
		return listboxItem( new()
		{
			[nameof( Disabled )] = GetDisabledState().ToString(),
			[nameof( Variant )] = Variant.ToString(),
			[nameof( Color )] = Color.ToString(),
		} );
	}

	[ExcludeFromCodeCoverage]
	private string? GetStyles( string slot )
	{
		if( !_slots.TryGetValue( slot, out var style ) )
		{
			throw new NotImplementedException();
		}

		var classes = Listbox?.ItemClasses;

		return slot switch
		{
			nameof( ListboxItemSlots.Base ) => style( classes?.Base, Classes?.Base, Class ),
			nameof( ListboxItemSlots.Title ) => style( classes?.Title, Classes?.Title ),
			nameof( ListboxItemSlots.Description ) => style( classes?.Description, Classes?.Description ),
			nameof( ListboxItemSlots.SelectedIcon ) => style( classes?.SelectedIcon, Classes?.SelectedIcon ),
			nameof( ListboxItemSlots.Wrapper ) => style( classes?.Wrapper, Classes?.Wrapper ),
			_ => throw new NotImplementedException()
		};
	}

	/// <inheritdoc />
	public virtual void Dispose()
	{
		Context?.Unregister( this );
	}
}