// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;
using LumexUI.Utilities;

using TailwindMerge;

namespace LumexUI.Styles;

[ExcludeFromCodeCoverage]
internal static class Card
{
	private static ComponentVariant? _variant;

	public static ComponentVariant Style( TwMerge twMerge )
	{
		var twVariants = new TwVariants( twMerge );

		return _variant ??= twVariants.Create( new VariantConfig
		{
			Slots = new SlotCollection
			{
				[nameof( CardSlots.Base )] = ElementClass.Empty()
					.Add( "flex" )
					.Add( "flex-col" )
					.Add( "relative" )
					.Add( "text-foreground" )
					.Add( "overflow-hidden" )
					.Add( "bg-surface1" ),

				[nameof( CardSlots.Header )] = ElementClass.Empty()
					.Add( "z-10" )
					.Add( "flex" )
					.Add( "px-4" )
					.Add( "py-3" )
					.Add( "w-full" )
					.Add( "justify-start" )
					.Add( "items-center" )
					.Add( "overflow-hidden" ),

				[nameof( CardSlots.Body )] = ElementClass.Empty()
					.Add( "flex" )
					.Add( "flex-col" )
					.Add( "relative" )
					.Add( "px-4" )
					.Add( "py-3" )
					.Add( "w-full" )
					.Add( "text-left" )
					.Add( "break-words" ),

				[nameof( CardSlots.Footer )] = ElementClass.Empty()
					.Add( "flex" )
					.Add( "px-4" )
					.Add( "py-3" )
					.Add( "w-full" )
					.Add( "items-center" )
					.Add( "overflow-hidden" )
			},

			Variants = new VariantCollection
			{
				[nameof( LumexCard.Blurred )] = new VariantValueCollection
				{
					[bool.TrueString] = new SlotCollection
					{
						[nameof( CardSlots.Base )] = ElementClass.Empty()
							.Add( "bg-background/80" )
							.Add( "dark:bg-background/20" )
							.Add( "backdrop-blur-md" )
							.Add( "backdrop-saturate-150" ),

						[nameof( CardSlots.Footer )] = ElementClass.Empty()
							.Add( "bg-background/10" )
							.Add( "backdrop-blur-md" )
							.Add( "backdrop-saturate-150" )
					}
				},

				[nameof( LumexCard.FullWidth )] = new VariantValueCollection
				{
					[bool.TrueString] = new SlotCollection
					{
						[nameof( CardSlots.Base )] = "w-full"
					}
				},

				[nameof( LumexCard.Shadow )] = new VariantValueCollection
				{
					[nameof( Shadow.None )] = new SlotCollection
					{
						[nameof( CardSlots.Base )] = "shadow-none"
					},
					[nameof( Shadow.Small )] = new SlotCollection
					{
						[nameof( CardSlots.Base )] = "shadow-small"
					},
					[nameof( Shadow.Medium )] = new SlotCollection
					{
						[nameof( CardSlots.Base )] = "shadow-medium"
					},
					[nameof( Shadow.Large )] = new SlotCollection
					{
						[nameof( CardSlots.Base )] = "shadow-large"
					},
				},

				[nameof( LumexCard.Radius )] = new VariantValueCollection
				{
					[nameof( Radius.None )] = new SlotCollection
					{
						[nameof( CardSlots.Base )] = "rounded-none",
						[nameof( CardSlots.Header )] = "rounded-none",
						[nameof( CardSlots.Footer )] = "rounded-none",
					},
					[nameof( Radius.Small )] = new SlotCollection
					{
						[nameof( CardSlots.Base )] = "rounded-small",
						[nameof( CardSlots.Header )] = "rounded-t-small",
						[nameof( CardSlots.Footer )] = "rounded-b-small",
					},
					[nameof( Radius.Medium )] = new SlotCollection
					{
						[nameof( CardSlots.Base )] = "rounded-medium",
						[nameof( CardSlots.Header )] = "rounded-t-medium",
						[nameof( CardSlots.Footer )] = "rounded-b-medium",
					},
					[nameof( Radius.Large )] = new SlotCollection
					{
						[nameof( CardSlots.Base )] = "rounded-large",
						[nameof( CardSlots.Header )] = "rounded-t-large",
						[nameof( CardSlots.Footer )] = "rounded-b-large",
					},
				}
			}
		} );
	}
}