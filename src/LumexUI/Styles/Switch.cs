// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;
using LumexUI.Utilities;

using TailwindMerge;

namespace LumexUI.Styles;

[ExcludeFromCodeCoverage]
internal static class Switch
{
	private static ComponentVariant? _variant;

	public static ComponentVariant Style( TwMerge twMerge )
	{
		var twVariants = new TwVariants( twMerge );

		return _variant ??= twVariants.Create( new VariantConfig()
		{
			Slots = new SlotCollection
			{
				[nameof( SwitchSlots.Base )] = ElementClass.Empty()
					.Add( "group" )
					.Add( "relative" )
					.Add( "max-w-fit" )
					.Add( "inline-flex" )
					.Add( "items-center" )
					.Add( "justify-start" )
					.Add( "outline-hidden" )
					.Add( "cursor-pointer" )
					.Add( "touch-none" ),

				[nameof( SwitchSlots.Wrapper )] = ElementClass.Empty()
					.Add( "px-1" )
					.Add( "mr-2" )
					.Add( "relative" )
					.Add( "inline-flex" )
					.Add( "items-center" )
					.Add( "justify-start" )
					.Add( "flex-shrink-0" )
					.Add( "overflow-hidden" )
					.Add( "bg-default-200" )
					.Add( "rounded-full" )
					//transition
					.Add( "transition-background" )
					// focus ring
					.Add( Utils.GroupFocusVisible ),

				[nameof( SwitchSlots.Thumb )] = ElementClass.Empty()
					.Add( "z-10" )
					.Add( "flex" )
					.Add( "items-center" )
					.Add( "justify-center" )
					.Add( "bg-white" )
					.Add( "shadow-small" )
					.Add( "rounded-full" )
					.Add( "origin-right" )
					// transition
					.Add( "transition-all" ),

				[nameof( SwitchSlots.ThumbIcon )] = ElementClass.Empty()
					.Add( "contents" )
					.Add( "*:p-0.5" )
					.Add( "*:text-black" ),

				[nameof( SwitchSlots.StartIcon )] = ElementClass.Empty()
					.Add( "contents" )
					.Add( "*:z-0" )
					.Add( "*:absolute" )
					.Add( "*:left-1.5" )
					.Add( "*:size-[1em]" )
					.Add( "*:text-current" )
					// transition
					.Add( "*:opacity-0" )
					.Add( "*:scale-50" )
					.Add( "*:transition-transform-opacity" )
					.Add( "*:group-data-[checked=true]:scale-100" )
					.Add( "*:group-data-[checked=true]:opacity-100" ),

				[nameof( SwitchSlots.EndIcon )] = ElementClass.Empty()
					.Add( "contents" )
					.Add( "*:z-0" )
					.Add( "*:absolute" )
					.Add( "*:right-1.5" )
					.Add( "*:size-[1em]" )
					.Add( "*:text-default-600" )
					// transition
					.Add( "*:opacity-100" )
					.Add( "*:transition-transform-opacity" )
					.Add( "*:group-data-[checked=true]:translate-x-3" )
					.Add( "*:group-data-[checked=true]:opacity-0" ),

				[nameof( SwitchSlots.Label )] = ElementClass.Empty()
					.Add( "relative" )
					.Add( "text-foreground" )
					.Add( "select-none" )
			},

			Variants = new VariantCollection
			{
				[nameof( LumexSwitch.Disabled )] = new VariantValueCollection
				{
					[bool.TrueString] = new SlotCollection
					{
						[nameof( SwitchSlots.Base )] = Utils.Disabled
					}
				},

				[nameof( LumexSwitch.Color )] = new VariantValueCollection
				{
					[nameof( ThemeColor.Default )] = new SlotCollection
					{
						[nameof(SwitchSlots.Wrapper)] = "group-data-[checked=true]:bg-default-400 group-data-[checked=true]:text-default-foreground"
					},
					[nameof( ThemeColor.Primary )] = new SlotCollection
					{
						[nameof(SwitchSlots.Wrapper)] = "group-data-[checked=true]:bg-primary group-data-[checked=true]:text-primary-foreground"
					},
					[nameof( ThemeColor.Secondary )] = new SlotCollection
					{
						[nameof(SwitchSlots.Wrapper)] = "group-data-[checked=true]:bg-secondary group-data-[checked=true]:text-secondary-foreground"
					},
					[nameof( ThemeColor.Success )] = new SlotCollection
					{
						[nameof(SwitchSlots.Wrapper)] = "group-data-[checked=true]:bg-success group-data-[checked=true]:text-success-foreground"
					},
					[nameof( ThemeColor.Warning )] = new SlotCollection
					{
						[nameof(SwitchSlots.Wrapper)] = "group-data-[checked=true]:bg-warning group-data-[checked=true]:text-warning-foreground"
					},
					[nameof( ThemeColor.Danger )] = new SlotCollection
					{
						[nameof(SwitchSlots.Wrapper)] = "group-data-[checked=true]:bg-danger group-data-[checked=true]:text-danger-foreground"
					},
					[nameof( ThemeColor.Info )] = new SlotCollection
					{
						[nameof(SwitchSlots.Wrapper)] = "group-data-[checked=true]:bg-info group-data-[checked=true]:text-info-foreground"
					},
				},

				[nameof( LumexSwitch.Size )] = new VariantValueCollection
				{
					[nameof( Size.Small )] = new SlotCollection
					{
						[nameof( SwitchSlots.Wrapper )] = "w-10 h-5",
						[nameof( SwitchSlots.Thumb )] = "w-3 h-3 text-tiny group-data-[checked=true]:ml-5 group-active:w-4 group-data-[checked=true]:group-active:ml-4",
						[nameof( SwitchSlots.StartIcon )] = "text-tiny",
						[nameof( SwitchSlots.EndIcon )] = "text-tiny",
						[nameof( SwitchSlots.Label )] = "text-small",
					},
					[nameof( Size.Medium )] = new SlotCollection
					{
						[nameof( SwitchSlots.Wrapper )] = "w-12 h-6",
						[nameof( SwitchSlots.Thumb )] = "w-4 h-4 text-small group-data-[checked=true]:ml-6 group-active:w-5 group-data-[checked=true]:group-active:ml-5",
						[nameof( SwitchSlots.StartIcon )] = "text-small",
						[nameof( SwitchSlots.EndIcon )] = "text-small",
						[nameof( SwitchSlots.Label )] = "text-medium",
					},
					[nameof( Size.Large )] = new SlotCollection
					{
						[nameof( SwitchSlots.Wrapper )] = "w-14 h-7",
						[nameof( SwitchSlots.Thumb )] = "w-5 h-5 text-medium group-data-[checked=true]:ml-7 group-active:w-6 group-data-[checked=true]:group-active:ml-6",
						[nameof( SwitchSlots.StartIcon )] = "text-medium",
						[nameof( SwitchSlots.EndIcon )] = "text-medium",
						[nameof( SwitchSlots.Label )] = "text-large",
					},
				}
			}
		} );
	}
}
