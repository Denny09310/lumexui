// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;
using LumexUI.Utilities;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

/// <summary>
/// A component that represents a checkbox input.
/// </summary>
public partial class LumexCheckbox : LumexBooleanInputBase, ISlotComponent<CheckboxSlots>
{
	/// <summary>
	/// Gets or sets the content to render as icon when the checkbox is checked.
	/// </summary>
	[Parameter] public RenderFragment? IconContent { get; set; }

	/// <summary>
	/// Gets or sets the border radius of the checkbox.
	/// </summary>
	/// <remarks>
	/// The default is <see cref="Radius.Medium"/>
	/// </remarks>
	[Parameter] public Radius Radius { get; set; } = Radius.Medium;

	/// <summary>
	/// Gets or sets the CSS class names for the checkbox slots.
	/// </summary>
	[Parameter] public CheckboxSlots? Classes { get; set; }

	[CascadingParameter] internal CheckboxGroupContext? Context { get; set; }

	private readonly RenderFragment _renderCheckIcon;

	private Dictionary<string, ComponentSlot> _slots = [];

	/// <summary>
	/// Initializes a new instance of the <see cref="LumexCheckbox"/>.
	/// </summary>
	public LumexCheckbox()
	{
		_renderCheckIcon = RenderCheckIcon;
	}

	/// <inheritdoc />
	public override async Task SetParametersAsync( ParameterView parameters )
	{
		await base.SetParametersAsync( parameters );

		Color = parameters.TryGetValue<ThemeColor>( nameof( Color ), out var color )
			? color
			: Context?.Owner.Color ?? ThemeColor.Primary;

		Size = parameters.TryGetValue<Size>( nameof( Size ), out var size )
			? size
			: Context?.Owner.Size ?? Size.Medium;

		if( parameters.TryGetValue<Radius>( nameof( Radius ), out var radius ) )
		{
			Radius = radius;
		}
		else if( Context is not null )
		{
			Radius = Context.Owner.Radius;
		}

		var checkbox = Styles.Checkbox.Style( TwMerge );
		_slots = checkbox( new()
		{
			[nameof( Disabled )] = GetDisabledState().ToString(),
			[nameof( Radius )] = Radius.ToString(),
			[nameof( Size )] = Size.ToString(),
			[nameof( Color )] = Color.ToString(),
		} );
	}

	[ExcludeFromCodeCoverage]
	private string? GetStyles( string slot )
	{
		if( !_slots.TryGetValue( slot, out var styles ) )
		{
			throw new NotImplementedException();
		}

		var classes = Context?.Owner.CheckboxClasses;

		return slot switch
		{
			nameof( CheckboxSlots.Base ) => styles( classes?.Base, Classes?.Base, Class ),
			nameof( CheckboxSlots.Wrapper ) => styles( classes?.Wrapper, Classes?.Wrapper ),
			nameof( CheckboxSlots.Icon ) => styles( classes?.Icon, Classes?.Icon ),
			nameof( CheckboxSlots.Label ) => styles( classes?.Label, Classes?.Label ),
			_ => throw new NotImplementedException()
		};
	}

	/// <inheritdoc />
	protected internal override bool GetDisabledState() =>
		Disabled || ( Context?.Owner.Disabled ?? false );

	/// <inheritdoc />
	protected internal override bool GetReadOnlyState() =>
		ReadOnly || ( Context?.Owner.ReadOnly ?? false );
}
