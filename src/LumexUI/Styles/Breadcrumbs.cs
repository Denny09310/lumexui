// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;
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

			Variants = new VariantCollection
			{
				[nameof(LumexBreadcrumbs.Radius)]= new VariantValueCollection
				{
					[nameof(Radius.None)] = new SlotCollection
					{
						[nameof(BreadcrumbsSlots.List)] = "rounded-none"
					},

					[nameof(Radius.Small)] = new SlotCollection
					{
						[nameof(BreadcrumbsSlots.List)] = "rounded-small"
					},

					[nameof(Radius.Medium)] = new SlotCollection
					{
						[nameof(BreadcrumbsSlots.List)] = "rounded-medium"
					},

					[nameof(Radius.Large)] = new SlotCollection
					{
						[nameof(BreadcrumbsSlots.List)] = "rounded-large"
					},

					[nameof(Radius.Full)] = new SlotCollection
					{
						[nameof(BreadcrumbsSlots.List)] = "rounded-full"
					},
				},

				[nameof(LumexBreadcrumbs.Variant)] = new VariantValueCollection
				{
					[nameof(Variant.Solid)] = new SlotCollection
					{
						[nameof(BreadcrumbsSlots.List)] = "bg-default-100",
					},

					[nameof(Variant.Outlined)] = new SlotCollection
					{
						[nameof(BreadcrumbsSlots.List)] = "border-medium border-default-200 shadow-xs",
					}
				}
			}
		} );
	}
}
