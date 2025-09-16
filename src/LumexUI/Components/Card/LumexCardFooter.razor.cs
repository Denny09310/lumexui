// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;
using LumexUI.Utilities;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

/// <summary>
/// A component that represents the footer section of the <see cref="LumexCard"/>.
/// </summary>
[CompositionComponent( typeof( LumexCard ) )]
public partial class LumexCardFooter : LumexComponentBase
{
	/// <summary>
	/// Gets or sets content to be rendered inside the card footer.
	/// </summary>
	[Parameter] public RenderFragment? ChildContent { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether the card footer is blurred.
	/// </summary>
	[Parameter] public bool Blurred { get; set; }

	[CascadingParameter] internal CardContext Context { get; set; } = default!;

	private Dictionary<string, ComponentSlot> _slots = [];

	/// <inheritdoc />
	protected override void OnInitialized()
	{
		ContextNullException.ThrowIfNull( Context, nameof( LumexCardFooter ) );
	}

	/// <inheritdoc />
	protected override void OnParametersSet()
	{
		var card = Styles.Card.Style( TwMerge );
		_slots = card( new()
		{
			[nameof( Radius )] = Context.Owner.Radius.ToString(),
			[nameof( Blurred )] = Blurred.ToString()
		} );
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
			nameof( CardSlots.Footer ) => styles( classes?.Footer, Class ),
			_ => throw new NotImplementedException()
		};
	}
}
