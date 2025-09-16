// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;
using LumexUI.Utilities;

using TailwindMerge;

namespace LumexUI.Styles;

[ExcludeFromCodeCoverage]
internal static class Accordion
{
	private static ComponentVariant? _variant;

	public static ComponentVariant Style( TwMerge twMerge )
	{
		var twVariants = new TwVariants( twMerge );

		return _variant ??= twVariants.Create( new VariantConfig()
		{
			Base = "px-2",

			Variants = new VariantCollection
			{
				[nameof( LumexAccordion.FullWidth )] = new VariantValueCollection
				{
					[bool.TrueString] = new SlotCollection
					{
						[nameof( SlotBase.Base )] = "w-full"
					}
				},

				[nameof( LumexAccordion.Variant )] = new VariantValueCollection
				{
					[nameof( AccordionVariant.Light )] = new SlotCollection
					{
						[nameof( SlotBase.Base )] = ""
					},
					[nameof( AccordionVariant.Shadow )] = new SlotCollection
					{
						[nameof( SlotBase.Base )] = "px-4 shadow-small rounded-medium bg-surface1"
					},
					[nameof( AccordionVariant.Bordered )] = new SlotCollection
					{
						[nameof( SlotBase.Base )] = "px-4 border border-divider rounded-medium"
					},
					[nameof( AccordionVariant.Splitted )] = new SlotCollection
					{
						[nameof( SlotBase.Base )] = "group is-splitted flex flex-col gap-2"
					},
				}
			}
		} );
	}
}

[ExcludeFromCodeCoverage]
internal static class AccordionItem
{
	private static ComponentVariant? _variant;

	public static ComponentVariant Style( TwMerge twMerge )
	{
		var twVariants = new TwVariants( twMerge );

		return _variant ??= twVariants.Create( new VariantConfig()
		{
			Slots = new SlotCollection
			{
				[nameof( AccordionItemSlots.Base )] = ElementClass.Empty()
					.Add( "group-[.is-splitted]:px-4" )
					.Add( "group-[.is-splitted]:bg-surface1" )
					.Add( "group-[.is-splitted]:shadow-small" )
					.Add( "group-[.is-splitted]:rounded-medium" ),

				[nameof( AccordionItemSlots.Heading )] = "",

				[nameof( AccordionItemSlots.Trigger )] = ElementClass.Empty()
					.Add( "flex" )
					.Add( "py-4" )
					.Add( "gap-3" )
					.Add( "w-full" )
					.Add( "items-center" )
					.Add( "outline-hidden" )
					.Add( "cursor-pointer" ),

				[nameof(AccordionItemSlots.StartContent)] = ElementClass.Empty()
					.Add( "flex-shrink-0" ),

				[nameof(AccordionItemSlots.TitleWrapper)] = ElementClass.Empty()
					.Add( "flex" )
					.Add( "flex-1" )
					.Add( "flex-col" )
					.Add( "text-start" ),

				[nameof(AccordionItemSlots.Title)] = ElementClass.Empty()
					.Add( "text-foreground" ),

				[nameof(AccordionItemSlots.Subtitle)]= ElementClass.Empty()
					.Add( "text-foreground-500" )
					.Add( "text-small" ),

				[nameof(AccordionItemSlots.Indicator)]= ElementClass.Empty()
					.Add( "text-default-400" )
					.Add( "rotate-0" )
					.Add( "data-[opened]:-rotate-90" )
					.Add( "transition-transform" ),

				[nameof(AccordionItemSlots.Content)]= ElementClass.Empty()
					.Add( "pb-4" ),
			},

			Variants = new VariantCollection
			{
				[nameof(LumexAccordionItem.Disabled)] = new VariantValueCollection
				{
					[bool.TrueString] = new SlotCollection
					{
						[nameof(AccordionItemSlots.Base)] = "opacity-disabled pointer-events-none"
					}
				}
			}
		} );
	}
}
