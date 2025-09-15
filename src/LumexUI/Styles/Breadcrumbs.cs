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
				[nameof( LumexBreadcrumbs.Radius )] = new VariantValueCollection
				{
					[nameof( Radius.None )] = new SlotCollection
					{
						[nameof( BreadcrumbsSlots.List )] = "rounded-none"
					},

					[nameof( Radius.Small )] = new SlotCollection
					{
						[nameof( BreadcrumbsSlots.List )] = "rounded-small"
					},

					[nameof( Radius.Medium )] = new SlotCollection
					{
						[nameof( BreadcrumbsSlots.List )] = "rounded-medium"
					},

					[nameof( Radius.Large )] = new SlotCollection
					{
						[nameof( BreadcrumbsSlots.List )] = "rounded-large"
					},

					[nameof( Radius.Full )] = new SlotCollection
					{
						[nameof( BreadcrumbsSlots.List )] = "rounded-full"
					},
				},

				[nameof( LumexBreadcrumbs.Variant )] = new VariantValueCollection
				{
					[nameof( Variant.Solid )] = new SlotCollection
					{
						[nameof( BreadcrumbsSlots.List )] = "bg-default-100",
					},

					[nameof( Variant.Outlined )] = new SlotCollection
					{
						[nameof( BreadcrumbsSlots.List )] = "border-medium border-default-200 shadow-xs",
					}
				}
			}
		} );
	}
}

[ExcludeFromCodeCoverage]
internal static class BreadcrumbItem
{
	private static ComponentVariant? _variant;

	public static ComponentVariant Style( TwMerge twMerge )
	{
		var twVariants = new TwVariants( twMerge );

		return _variant ??= twVariants.Create( new VariantConfig()
		{
			Slots = new SlotCollection
			{
				[nameof( BreadcrumbItemSlots.Base )] = "flex items-center",

				[nameof( BreadcrumbItemSlots.Item )] = new ElementClass()
					.Add( "flex gap-1 items-center" )
					.Add( "cursor-pointer" )
					.Add( "whitespace-nowrap" )
					.Add( "outline-solid outline-transparent" )
					.Add( "tap-highlight-transparent" )
					// focus ring
					.Add( Utils.FocusVisible ),

				[nameof( BreadcrumbItemSlots.Separator )] = "text-default-400 px-1 rtl:rotate-180"
			},

			Variants = new VariantCollection
			{
				[nameof( LumexBreadcrumbItem.Color )] = new VariantValueCollection
				{
					[nameof( ThemeColor.Default )] = new SlotCollection
					{
						[nameof( BreadcrumbItemSlots.Item )] = "text-foreground/50",
						[nameof( BreadcrumbItemSlots.Separator )] = "text-foreground/50",
					},

					[nameof( ThemeColor.Primary )] = new SlotCollection
					{
						[nameof( BreadcrumbItemSlots.Item )] = "text-primary/80",
						[nameof( BreadcrumbItemSlots.Separator )] = "text-primary/80",
					},

					[nameof( ThemeColor.Secondary )] = new SlotCollection
					{
						[nameof( BreadcrumbItemSlots.Item )] = "text-secondary/80",
						[nameof( BreadcrumbItemSlots.Separator )] = "text-secondary/80",
					},

					[nameof( ThemeColor.Success )] = new SlotCollection
					{
						[nameof( BreadcrumbItemSlots.Item )] = "text-success/80",
						[nameof( BreadcrumbItemSlots.Separator )] = "text-success/80",
					},

					[nameof( ThemeColor.Warning )] = new SlotCollection
					{
						[nameof( BreadcrumbItemSlots.Item )] = "text-warning/80",
						[nameof( BreadcrumbItemSlots.Separator )] = "text-warning/80",
					},

					[nameof( ThemeColor.Danger )] = new SlotCollection
					{
						[nameof( BreadcrumbItemSlots.Item )] = "text-danger/80",
						[nameof( BreadcrumbItemSlots.Separator )] = "text-danger/80",
					},
				},

				[nameof( LumexBreadcrumbItem.Size )] = new VariantValueCollection
				{
					[nameof( Size.Small )] = new SlotCollection
					{
						[nameof( BreadcrumbItemSlots.Item )] = "text-tiny",
					},

					[nameof( Size.Medium )] = new SlotCollection
					{
						[nameof( BreadcrumbItemSlots.Item )] = "text-small",
					},

					[nameof( Size.Large )] = new SlotCollection
					{
						[nameof( BreadcrumbItemSlots.Item )] = "text-medium",
					},
				},

				[nameof( LumexBreadcrumbItem.Underline )] = new VariantValueCollection
				{
					[nameof( Underline.None )] = new SlotCollection
					{
						[nameof( BreadcrumbItemSlots.Item )] = "no-underline",
					},

					[nameof( Underline.Hover )] = new SlotCollection
					{
						[nameof( BreadcrumbItemSlots.Item )] = "hover:underline",
					},

					[nameof( Underline.Always )] = new SlotCollection
					{
						[nameof( BreadcrumbItemSlots.Item )] = "underline",
					},

					[nameof( Underline.Active )] = new SlotCollection
					{
						[nameof( BreadcrumbItemSlots.Item )] = "active:underline",
					},

					[nameof( Underline.Focus )] = new SlotCollection
					{
						[nameof( BreadcrumbItemSlots.Item )] = "focus:underline",
					},
				},

				[nameof( LumexBreadcrumbItem.IsCurrent )] = new VariantValueCollection
				{
					[bool.TrueString] = new SlotCollection
					{
						[nameof( BreadcrumbItemSlots.Item )] = "cursor-default",
					},
					[bool.FalseString] = new SlotCollection
					{
						[nameof( BreadcrumbItemSlots.Item )] = "hover:opacity-hover active:opacity-disabled",
					}
				},

				[nameof( LumexBreadcrumbItem.IsDisabled )] = new VariantValueCollection
				{
					[bool.TrueString] = new SlotCollection
					{
						[nameof( BreadcrumbItemSlots.Item )] = "opacity-disabled pointer-events-none",
						[nameof( BreadcrumbItemSlots.Separator )] = "opacity-disabled",
					}
				}
			}
		} );
	}
}