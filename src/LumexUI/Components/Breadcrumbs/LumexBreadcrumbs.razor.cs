// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;
using LumexUI.Utilities;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

/// <summary>
/// A component that represents a set of breadcrumbs for navigation.
/// </summary>
public partial class LumexBreadcrumbs : LumexComponentBase, ISlotComponent<BreadcrumbsSlots>
{
	/// <summary>
	/// Gets or sets content to be rendered inside the component.
	/// </summary>
	[Parameter] public RenderFragment? ChildContent { get; set; }

	/// <summary>
	/// Gets or sets the size of the <see cref="LumexBreadcrumbs"/>.
	/// </summary>
	/// <remarks>
	/// The default value is <see cref="Size.Medium"/>.
	/// </remarks>
	[Parameter] public Size Size { get; set; } = Size.Medium;

	/// <summary>
	/// Gets or sets the radius of the <see cref="LumexBreadcrumbs"/>.
	/// </summary>
	/// <remarks>
	/// The default value is <see cref="Radius.Small"/>.
	/// </remarks>
	[Parameter] public Radius Radius { get; set; } = Radius.Small;

	/// <summary>
	/// Gets or sets the variant of the <see cref="LumexBreadcrumbs"/>.
	/// </summary>
	/// <remarks>
	/// The default value is <see cref="Variant.Light"/>.
	/// </remarks>
	[Parameter] public Variant Variant { get; set; } = Variant.Light;

	/// <summary>
	/// Gets or sets the CSS class names for the breadcrumbs slots.
	/// </summary>
	[Parameter] public BreadcrumbsSlots? Classes { get; set; }

	private Dictionary<string, ComponentSlot> _slots = [];

	/// <inheritdoc/>
	protected override void OnParametersSet()
	{
		var breadcrumbs = Styles.Breadcrumbs.Style( TwMerge );
		_slots = breadcrumbs( new()
		{
			[nameof( Radius )] = Radius.ToString(),
			[nameof( Size )] = Size.ToString(),
			[nameof( Variant )] = Variant.ToString()
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
			nameof( BreadcrumbsSlots.Base ) => styles( Classes?.Base, Class ),
			nameof( BreadcrumbsSlots.Ellipsis ) => styles( Classes?.Ellipsis ),
			nameof( BreadcrumbsSlots.List ) => styles( Classes?.List ),
			nameof( BreadcrumbsSlots.Separator ) => styles( Classes?.Separator ),
			_ => throw new NotImplementedException()
		};
	}
}