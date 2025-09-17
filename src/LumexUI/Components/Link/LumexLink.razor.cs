// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;
using LumexUI.Utilities;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace LumexUI;

/// <summary>
/// A component that represents a navigation link.
/// </summary>
public partial class LumexLink : LumexComponentBase
{
	/// <summary>
	/// Gets or sets content to be rendered inside the link.
	/// </summary>
	[Parameter] public RenderFragment? ChildContent { get; set; }

	/// <summary>
	/// Gets or sets a value representing the URL of the link.
	/// </summary>
	[Parameter] public string Href { get; set; } = "#";

	/// <summary>
	/// Gets or sets a value representing the URL matching behavior.
	/// </summary>
	/// <remarks>
	/// The default value is <see cref="NavLinkMatch.All"/>
	/// </remarks>
	[Parameter] public NavLinkMatch Match { get; set; } = NavLinkMatch.All;

	/// <summary>
	/// Gets or sets a color of the link.
	/// </summary>
	/// <remarks>
	/// The default value is <see cref="ThemeColor.Primary"/>
	/// </remarks>
	[Parameter] public ThemeColor Color { get; set; } = ThemeColor.Primary;

	/// <summary>
	/// Gets or sets the underline style for the link.
	/// </summary>
	/// <remarks>
	/// Default value is <see cref="Underline.None"/>
	/// </remarks>
	[Parameter] public Underline Underline { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether the link is disabled.
	/// </summary>
	[Parameter] public bool Disabled { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether the link should open in the new tab.
	/// </summary>
	/// <remarks>
	/// Sets target to `_blank` and rel to `noopener noreferrer`.
	/// </remarks>
	[Parameter] public bool External { get; set; }

	private IReadOnlyDictionary<string, object> Attributes
	{
		get
		{
			var attributes = new Dictionary<string, object>()
			{
				["href"] = Href
			};

			if( External )
			{
				attributes["target"] = "_blank";
				attributes["rel"] = "noopener noreferrer";
			}

			if( AdditionalAttributes is not null )
			{
				foreach( var attribute in AdditionalAttributes )
				{
					attributes[attribute.Key] = attribute.Value;
				}
			}

			return attributes;
		}
	}

	private Dictionary<string, ComponentSlot> _slots = [];

	/// <summary>
	/// Initializes a new instance of the <see cref="LumexLink"/>.
	/// </summary>
	public LumexLink()
	{
		As = "a";
	}

	/// <inheritdoc />
	protected override void OnParametersSet()
	{
		var link = Styles.Link.Style( TwMerge );
		_slots = link( new()
		{
			[nameof( Disabled )] = Disabled.ToString(),
			[nameof( Color )] = Color.ToString(),
			[nameof( Underline )] = Underline.ToString(),
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
