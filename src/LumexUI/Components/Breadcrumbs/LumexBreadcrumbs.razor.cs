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
	/// Gets or sets the separator element rendered between each breadcrumb item.
	/// </summary>
	[Parameter] public RenderFragment? SeparatorContent { get; set; }

	/// <summary>
	/// Gets or sets the variant of the <see cref="LumexBreadcrumbs"/>.
	/// </summary>
	/// <remarks>
	/// The default value is <see cref="Variant.Light"/>.
	/// </remarks>
	[Parameter] public Variant Variant { get; set; } = Variant.Light;

	/// <summary>
	/// Gets or sets the color scheme of the <see cref="LumexBreadcrumbs"/>.
	/// </summary>
	/// <remarks>
	/// The default value is <see cref="ThemeColor.Default"/>.
	/// </remarks>
	[Parameter] public ThemeColor? Color { get; set; }

	/// <summary>
	/// Gets or sets the size of the <see cref="LumexBreadcrumbs"/>.
	/// </summary>
	/// <remarks>
	/// The default value is <see cref="Size.Medium"/>.
	/// </remarks>
	[Parameter] public Size? Size { get; set; }

	/// <summary>
	/// Gets or sets the radius of the <see cref="LumexBreadcrumbs"/>.
	/// </summary>
	/// <remarks>
	/// The default value is <see cref="Radius.Small"/>.
	/// </remarks>
	[Parameter] public Radius Radius { get; set; } = Radius.Small;

	/// <summary>
	/// Gets or sets the underline style for the <see cref="LumexBreadcrumbs"/>.
	/// </summary>
	/// <remarks>
	/// The default value is <see cref="Underline.None"/>.
	/// </remarks>
	[Parameter] public Underline Underline { get; set; } = Underline.None;

	/// <summary>
	/// Gets or sets the maximum number of breadcrumb items to display before collapsing.
	/// </summary>
	[Parameter] public int MaxItems { get; set; }

	/// <summary>
	/// Gets or sets the number of items to display before the collapsed section.
	/// </summary>
	[Parameter] public int ItemsBeforeCollapse { get; set; }

	/// <summary>
	/// Gets or sets the number of items to display after the collapsed section.
	/// </summary>
	[Parameter] public int ItemsAfterCollapse { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether the <see cref="LumexBreadcrumbs"/> is disabled.
	/// </summary>
	[Parameter] public bool? IsDisabled { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether the separator between breadcrumb items should be hidden.
	/// </summary>
	[Parameter] public bool? HideSeparator { get; set; }

	/// <summary>
	/// Gets or sets the CSS class names for individual breadcrumb items.
	/// </summary>
	[Parameter] public BreadcrumbItemSlots? ItemClasses { get; set; }

	/// <summary>
	/// Gets or sets the CSS class names for the breadcrumbs slots.
	/// </summary>
	[Parameter] public BreadcrumbsSlots? Classes { get; set; }

	private readonly BreadcrumbsContext _context;

	private Dictionary<string, ComponentSlot> _slots = [];

	/// <summary>
	/// Initializes a new instance of the <see cref="LumexBreadcrumbs"/>.
	/// </summary>
	public LumexBreadcrumbs()
	{
		_context = new BreadcrumbsContext( this );

		As = "nav";
	}

	/// <inheritdoc/>
	protected override void OnParametersSet()
	{
		var breadcrumbs = Styles.Breadcrumbs.Style( TwMerge );
		_slots = breadcrumbs( new()
		{
			[nameof( Radius )] = Radius.ToString(),
			[nameof( Variant )] = Variant.ToString(),
			[nameof( Size )] = Size?.ToString() ?? "",
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
