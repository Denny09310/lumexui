// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;
using LumexUI.Utilities;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

/// <summary>
/// A component that represents a divider for separating content.
/// </summary>
public partial class LumexDivider : LumexComponentBase
{
	/// <summary>
	/// Gets or sets a value defining the divider's orientation.
	/// </summary>
	/// <remarks>
	/// Default value is <see cref="Orientation.Horizontal" />
	/// </remarks>
	[Parameter] public Orientation Orientation { get; set; }

	private Dictionary<string, ComponentSlot> _slots = [];

	private new string As => Orientation is Orientation.Horizontal ? "hr" : "div";

	/// <inheritdoc />
	protected override void OnParametersSet()
	{
		var divider = Styles.Divider.Style( TwMerge );
		_slots = divider(new()
		{
			[nameof(Orientation)] = Orientation.ToString(),
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
			nameof( SlotBase.Base ) => styles( Class ),
			_ => throw new NotImplementedException()
		};
	}
}