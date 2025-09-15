// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Utilities;

using TailwindMerge;

namespace LumexUI.Styles;

[ExcludeFromCodeCoverage]
internal static class Breadcrumbs
{
	private static ComponentVariant? _variant;

	public static ComponentVariant Style( TwMerge twMerge )
	{
		var twVariants = new TwVariants( twMerge );

		return _variant ??= twVariants.Create( new VariantConfig()
		{
			Slots = new SlotCollection
			{
				[nameof( BreadcrumbsSlots.Base )] = "",

				[nameof( BreadcrumbsSlots.List )] = "flex flex-wrap list-none",

				[nameof( BreadcrumbsSlots.Ellipsis )] = "text-medium",

				[nameof( BreadcrumbsSlots.Separator )] = "text-default-400 px-1"
			},
		} );
	}
}
