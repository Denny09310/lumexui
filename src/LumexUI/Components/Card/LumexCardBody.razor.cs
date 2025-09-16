// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;
using LumexUI.Utilities;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

/// <summary>
/// A component that represents the body section of the <see cref="LumexCard"/>.
/// </summary>
[CompositionComponent( typeof( LumexCard ) )]
public partial class LumexCardBody : LumexComponentBase
{
	/// <summary>
	/// Gets or sets content to be rendered inside the card body.
	/// </summary>
	[Parameter] public RenderFragment? ChildContent { get; set; }

	[CascadingParameter] internal CardContext Context { get; set; } = default!;

	private Dictionary<string, ComponentSlot> _slots = [];

	/// <inheritdoc />
	protected override void OnParametersSet()
	{
		var card = Styles.Card.Style( TwMerge );
		_slots = card();
	}

	/// <inheritdoc />
	protected override void OnInitialized()
	{
		ContextNullException.ThrowIfNull( Context, nameof( LumexCardBody ) );
	}

	[ExcludeFromCodeCoverage]
	private string? GetStyles( string slot )
	{
		if( !_slots.TryGetValue( slot, out var styles ) )
		{
			throw new NotImplementedException();
		}

		var classes = Context.Owner.Classes;

		return slot switch
		{
			nameof( CardSlots.Body ) => styles( classes?.Body, Class ),
			_ => throw new NotImplementedException()
		};
	}
}
