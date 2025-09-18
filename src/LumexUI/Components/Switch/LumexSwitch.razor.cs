// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;
using LumexUI.Utilities;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

/// <summary>
/// A component that represents a switch input.
/// </summary>
public partial class LumexSwitch : LumexBooleanInputBase, ISlotComponent<SwitchSlots>
{
	/// <summary>
	/// Gets or sets the content to render within the thumb of the switch.
	/// </summary>
	[Parameter] public RenderFragment<bool>? ThumbContent { get; set; }

	/// <summary>
	/// Gets or sets the content to render at the start of the switch.
	/// </summary>
	[Parameter] public RenderFragment? StartContent { get; set; }

	/// <summary>
	/// Gets or sets the content to render at the end of the switch.
	/// </summary>
	[Parameter] public RenderFragment? EndContent { get; set; }

	/// <summary>
	/// Gets or sets the CSS class names for the switch slots.
	/// </summary>
	[Parameter] public SwitchSlots? Classes { get; set; }

	private Dictionary<string, ComponentSlot> _slots = [];

	/// <summary>
	/// Initializes a new instance of the <see cref="LumexSwitch"/>.
	/// </summary>
	public LumexSwitch()
	{
		Color = ThemeColor.Primary;
	}

	/// <inheritdoc />
	protected override void OnParametersSet()
	{
		var @switch = Styles.Switch.Style( TwMerge );
		_slots = @switch( new()
		{
			[nameof( Disabled )] = Disabled.ToString(),
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

		return slot switch
		{
			nameof( SwitchSlots.Base ) => styles( Classes?.Base, Class ),
			nameof( SwitchSlots.Wrapper ) => styles( Classes?.Wrapper ),
			nameof( SwitchSlots.Thumb ) => styles( Classes?.Thumb ),
			nameof( SwitchSlots.ThumbIcon ) => styles( Classes?.ThumbIcon ),
			nameof( SwitchSlots.StartIcon ) => styles( Classes?.StartIcon ),
			nameof( SwitchSlots.EndIcon ) => styles( Classes?.EndIcon ),
			nameof( SwitchSlots.Label ) => styles( Classes?.Label ),
			_ => throw new NotImplementedException()
		};
	}
}
