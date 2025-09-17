// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;
using LumexUI.Utilities;

using TailwindMerge;

namespace LumexUI.Styles;

[ExcludeFromCodeCoverage]
internal static class Navbar
{
	private static ComponentVariant? _variant;

	public static ComponentVariant Style( TwMerge twMerge )
	{
		var twVariant = new TwVariants( twMerge );

		return _variant ??= twVariant.Create( new VariantConfig()
		{
			Slots = new SlotCollection
			{
				[nameof( NavbarSlots.Base )] = ElementClass.Empty()
					.Add( "z-40" )
					.Add( "relative" )
					.Add( "flex" )
					.Add( "w-full" )
					.Add( "items-center" )
					.Add( "justify-center" ),

				[nameof( NavbarSlots.Wrapper )] = ElementClass.Empty()
					.Add( "z-40" )
					.Add( "flex" )
					.Add( "px-6" )
					.Add( "gap-8" )
					.Add( "w-full" )
					.Add( "items-center" )
					.Add( "h-[var(--navbar-height)]" ),

				[nameof( NavbarSlots.Toggle )] = ElementClass.Empty()
					.Add( "group" )
					.Add( "w-6" )
					.Add( "h-full" )
					.Add( "rounded-small" )
					.Add( "cursor-pointer" )
					// focus
					.Add( Utils.FocusVisible ),

				[nameof( NavbarSlots.ToggleIcon )] = ElementClass.Empty()
					.Add( "w-full" )
					.Add( "h-full" )
					.Add( "pointer-events-none" )
					.Add( "flex" )
					.Add( "flex-col" )
					.Add( "items-center" )
					.Add( "justify-center" )
					.Add( "text-inherit" )
					.Add( "group-active:opacity-focus" )
					.Add( "transition-opacity" )
					// before - first line
					.Add( "before:h-px" )
					.Add( "before:w-6" )
					.Add( "before:bg-current" )
					.Add( "before:transition-transform" )
					.Add( "before:duration-150" )
					.Add( "before:-translate-y-1" )
					.Add( "before:rotate-0" )
					.Add( "group-data-[expanded]:before:translate-y-px" )
					.Add( "group-data-[expanded]:before:rotate-45" )
					// after - second line
					.Add( "after:h-px" )
					.Add( "after:w-6" )
					.Add( "after:bg-current" )
					.Add( "after:transition-transform" )
					.Add( "after:duration-150" )
					.Add( "after:translate-y-1" )
					.Add( "after:rotate-0" )
					.Add( "group-data-[expanded]:after:translate-y-0" )
					.Add( "group-data-[expanded]:after:-rotate-45" ),

				[nameof( NavbarSlots.Brand )] = ElementClass.Empty()
					.Add( "flex" )
					.Add( "items-center" )
					.Add( "justify-start" )
					.Add( "text-medium" ),

				[nameof( NavbarSlots.Content )] = ElementClass.Empty()
					.Add( "flex" )
					.Add( "gap-6" )
					.Add( "h-full" )
					.Add( "flex-nowrap" )
					.Add( "items-center" ),

				[nameof( NavbarSlots.Item )] = ElementClass.Empty()
					.Add( "leading-medium" )
					.Add( "text-small" )
					.Add( "font-semibold" )
					.Add( "list-none" ),

				[nameof( NavbarSlots.Menu )] = ElementClass.Empty()
					.Add( "z-30" )
					.Add( "px-6" )
					.Add( "pt-2" )
					.Add( "flex" )
					.Add( "flex-col" )
					.Add( "gap-2" )
					.Add( "fixed" )
					.Add( "top-[var(--navbar-height)]" )
					.Add( "bottom-0" )
					.Add( "inset-x-0" )
					.Add( "overflow-y-auto" ),

				[nameof( NavbarSlots.MenuItem )] = ElementClass.Empty()
					.Add( "text-large" ),
			},

			Variants = new VariantCollection
			{
				[nameof( LumexNavbar.Sticky )] = new VariantValueCollection
				{
					[bool.TrueString] = new SlotCollection
					{
						[nameof( NavbarSlots.Base )] = "sticky top-0 inset-x-0"
					}
				},

				[nameof( LumexNavbar.Bordered )] = new VariantValueCollection
				{
					[bool.TrueString] = new SlotCollection
					{
						[nameof( NavbarSlots.Base )] = "border-b border-divider"
					}
				},

				[nameof( LumexNavbar.Blurred )] = new VariantValueCollection
				{
					[bool.FalseString] = new SlotCollection
					{
						[nameof( NavbarSlots.Base )] = "bg-background",
						[nameof( NavbarSlots.Menu )] = "bg-background"
					},
					[bool.TrueString] = new SlotCollection
					{
						[nameof( NavbarSlots.Base )] = ElementClass.Empty()
							.Add( "before:-z-10" )
							.Add( "before:absolute" )
							.Add( "before:inset-0" )
							.Add( "before:backdrop-blur-lg" )
							.Add( "before:backdrop-saturate-150" )
							.Add( "before:bg-background/70" ),

						[nameof( NavbarSlots.Menu )] = ElementClass.Empty()
							.Add( "backdrop-blur-lg" )
							.Add( "backdrop-saturate-150" )
							.Add( "bg-background/70" )
					}
				},

				[nameof( LumexNavbar.MaxWidth )] = new VariantValueCollection
				{
					[nameof( MaxWidth.Small )] = new SlotCollection
					{
						[nameof( NavbarSlots.Wrapper )] = "max-w-screen-sm",
					},
					[nameof( MaxWidth.Medium )] = new SlotCollection
					{
						[nameof( NavbarSlots.Wrapper )] = "max-w-screen-md",
					},
					[nameof( MaxWidth.Large )] = new SlotCollection
					{
						[nameof( NavbarSlots.Wrapper )] = "max-w-screen-lg",
					},
					[nameof( MaxWidth.XLarge )] = new SlotCollection
					{
						[nameof( NavbarSlots.Wrapper )] = "max-w-screen-xl",
					},
					[nameof( MaxWidth.XXLarge )] = new SlotCollection
					{
						[nameof( NavbarSlots.Wrapper )] = "max-w-screen-2xl",
					},
				},

				[nameof( LumexNavbarContent.Align )] = new VariantValueCollection
				{
					[nameof( Align.Start )] = new SlotCollection
					{
						[nameof( NavbarSlots.Content )] = "me-auto"
					},
					[nameof( Align.End )] = new SlotCollection
					{
						[nameof( NavbarSlots.Content )] = "ms-auto"
					},
				}
			}
		} );
	}
}