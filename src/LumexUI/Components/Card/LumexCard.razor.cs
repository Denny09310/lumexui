// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;
using LumexUI.Utilities;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

/// <summary>
/// A component that represents a card.
/// </summary>
public partial class LumexCard : LumexComponentBase, ISlotComponent<CardSlots>
{
	/// <summary>
	/// Gets or sets content to be rendered inside the card.
	/// </summary>
	[Parameter] public RenderFragment? ChildContent { get; set; }

	/// <summary>
	/// Gets or sets the border radius of the card.
	/// </summary>
	/// <remarks>
	/// Default value is <see cref="Radius.Large"/>
	/// </remarks>
	[Parameter] public Radius Radius { get; set; } = Radius.Large;

	/// <summary>
	/// Gets or sets the shadow of the card.
	/// </summary>
	/// <remarks>
	/// Default value is <see cref="Shadow.Small"/>
	/// </remarks>
	[Parameter] public Shadow Shadow { get; set; } = Shadow.Small;

	/// <summary>
	/// Gets or sets a value indicating whether the card is full-width.
	/// </summary>
	[Parameter] public bool FullWidth { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether the card is blurred.
	/// </summary>
	[Parameter] public bool Blurred { get; set; }

	/// <summary>
	/// Gets or sets the CSS class names for the card slots.
	/// </summary>
	[Parameter] public CardSlots? Classes { get; set; }

	private readonly CardContext _context;

	private Dictionary<string, ComponentSlot> _slots = [];

	/// <summary>
	/// Initializes a new instance of the <see cref="LumexCard"/>.
	/// </summary>
	public LumexCard()
	{
		_context = new CardContext( this );
	}

	/// <inheritdoc />
	protected override void OnParametersSet()
	{
		var card = Styles.Card.Style( TwMerge );
		_slots = card( new()
		{
			[nameof( Blurred )] = Blurred.ToString(),
			[nameof( FullWidth )] = FullWidth.ToString(),
			[nameof( Shadow )] = Shadow.ToString(),
			[nameof( Radius )] = Radius.ToString()
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
			nameof( CardSlots.Base ) => styles( Classes?.Base, Class ),
			_ => throw new NotImplementedException()
		};
	}
}