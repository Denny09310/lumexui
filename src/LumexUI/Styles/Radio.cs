// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;
using LumexUI.Utilities;

using TailwindMerge;

namespace LumexUI.Styles;

[ExcludeFromCodeCoverage]
internal static class Radio
{
	private static ComponentVariant? _variant;

	public static ComponentVariant Style( TwMerge twMerge )
	{
		var twVariant = new TwVariants( twMerge );

		return _variant ??= twVariant.Create( new VariantConfig()
		{
			Slots = new SlotCollection
			{
				[nameof( RadioSlots.Base )] = ElementClass.Empty()
					.Add( "group" )
					.Add( "relative" )
					.Add( "max-w-fit" )
					.Add( "inline-flex" )
					.Add( "items-center" )
					.Add( "justify-start" )
					.Add( "cursor-pointer" )
					.Add( "p-2" )
					.Add( "-m-2" )
					.Add( "select-none" ),

				[nameof( RadioSlots.ControlWrapper )] = ElementClass.Empty()
					.Add( "relative" )
					.Add( "inline-flex" )
					.Add( "items-center" )
					.Add( "justify-center" )
					.Add( "shrink-0" )
					.Add( "overflow-hidden" )
					.Add( "border-2" )
					.Add( "border-default" )
					.Add( "rounded-full" )
					.Add( "group-hover:bg-default-100" )
					.Add( "group-active:scale-95" )
					.Add( "transition-colors-transform" )
					.Add( Utils.ReduceMotion )
					.Add( Utils.GroupFocusVisible ),

				[nameof( RadioSlots.Control )] = ElementClass.Empty()
					.Add( "z-10" )
					.Add( "w-2" )
					.Add( "h-2" )
					.Add( "opacity-0" )
					.Add( "scale-0" )
					.Add( "origin-center" )
					.Add( "rounded-full" )
					.Add( "group-data-[selected=true]:opacity-100" )
					.Add( "group-data-[selected=true]:scale-100" )
					.Add( "transition-transform-opacity" )
					.Add( Utils.ReduceMotion ),

				[nameof( RadioSlots.LabelWrapper )] = ElementClass.Empty()
					.Add( "flex" )
					.Add( "flex-col" ),

				[nameof( RadioSlots.Label )] = ElementClass.Empty()
					.Add( "group" )
					.Add( "text-foreground" )
					.Add( "select-none" )
					.Add( "transition-colors-opacity" )
					.Add( Utils.ReduceMotion ),

				[nameof( RadioSlots.Description )] = ElementClass.Empty()
					.Add( "relative" )
					.Add( "text-foreground-400" )
					.Add( "transition-colors" )
					.Add( Utils.ReduceMotion ),
			},

			Variants = new VariantCollection
			{
				[nameof( LumexRadio<object>.Disabled )] = new VariantValueCollection
				{
					[nameof( bool.TrueString )] = new SlotCollection
					{
						[nameof( RadioSlots.Base )] = "opacity-disabled pointer-events-none"
					}
				},

				[nameof( LumexRadio<object>.Color )] = new VariantValueCollection
				{
					[nameof( ThemeColor.Default )] = new SlotCollection
					{
						[nameof( RadioSlots.Control )] = "bg-default-500 text-default-foreground",
						[nameof( RadioSlots.ControlWrapper )] = "group-data-[selected=true]:border-default-500"
					},
					[nameof( ThemeColor.Primary )] = new SlotCollection
					{
						[nameof( RadioSlots.Control )] = "bg-primary text-primary-foreground",
						[nameof( RadioSlots.ControlWrapper )] = "group-data-[selected=true]:border-primary"
					},
					[nameof( ThemeColor.Secondary )] = new SlotCollection
					{
						[nameof( RadioSlots.Control )] = "bg-secondary text-secondary-foreground",
						[nameof( RadioSlots.ControlWrapper )] = "group-data-[selected=true]:border-secondary"
					},
					[nameof( ThemeColor.Success )] = new SlotCollection
					{
						[nameof( RadioSlots.Control )] = "bg-success text-success-foreground",
						[nameof( RadioSlots.ControlWrapper )] = "group-data-[selected=true]:border-success"
					},
					[nameof( ThemeColor.Warning )] = new SlotCollection
					{
						[nameof( RadioSlots.Control )] = "bg-warning text-warning-foreground",
						[nameof( RadioSlots.ControlWrapper )] = "group-data-[selected=true]:border-warning"
					},
					[nameof( ThemeColor.Danger )] = new SlotCollection
					{
						[nameof( RadioSlots.Control )] = "bg-danger text-danger-foreground",
						[nameof( RadioSlots.ControlWrapper )] = "group-data-[selected=true]:border-danger"
					},
					[nameof( ThemeColor.Info )] = new SlotCollection
					{
						[nameof( RadioSlots.Control )] = "bg-info text-info-foreground",
						[nameof( RadioSlots.ControlWrapper )] = "group-data-[selected=true]:border-info"
					}
				},

				[nameof( LumexRadio<object>.Size )] = new VariantValueCollection
				{
					[nameof( Size.Small )] = new SlotCollection
					{
						[nameof( RadioSlots.ControlWrapper )] = "w-4 h-4",
						[nameof( RadioSlots.Control )] = "w-1.5 h-1.5",
						[nameof( RadioSlots.LabelWrapper )] = "ml-1",
						[nameof( RadioSlots.Label )] = "text-small",
						[nameof( RadioSlots.Description )] = "text-tiny",
					},
					[nameof( Size.Medium )] = new SlotCollection
					{
						[nameof( RadioSlots.ControlWrapper )] = "w-5 h-5",
						[nameof( RadioSlots.Control )] = "w-2 h-2",
						[nameof( RadioSlots.LabelWrapper )] = "ms-2",
						[nameof( RadioSlots.Label )] = "text-medium",
						[nameof( RadioSlots.Description )] = "text-small",
					},
					[nameof( Size.Large )] = new SlotCollection
					{
						[nameof( RadioSlots.ControlWrapper )] = "w-6 h-6",
						[nameof( RadioSlots.Control )] = "w-2.5 h-2.5",
						[nameof( RadioSlots.LabelWrapper )] = "ms-2",
						[nameof( RadioSlots.Label )] = "text-large",
						[nameof( RadioSlots.Description )] = "text-medium",
					}
				}
			}
		} );
	}
}

[ExcludeFromCodeCoverage]
internal static class RadioGroup
{
	private static ComponentVariant? _variant;

	public static ComponentVariant Style( TwMerge twMerge )
	{
		var twVariant = new TwVariants( twMerge );

		return _variant ??= twVariant.Create( new VariantConfig()
		{
			Slots = new SlotCollection
			{
				[nameof( RadioGroupSlots.Base )] = ElementClass.Empty()
					.Add( "relative" )
					.Add( "flex" )
					.Add( "flex-col" )
					.Add( "gap-2" ),

				[nameof( RadioGroupSlots.Label )] = ElementClass.Empty()
					.Add( "text-medium" )
					.Add( "text-foreground-500" ),

				[nameof( RadioGroupSlots.Wrapper )] = ElementClass.Empty()
					.Add( "flex" )
					.Add( "flex-col" )
					.Add( "flex-wrap" )
					.Add( "gap-2" )
					.Add( "data-[orientation=horizontal]:flex-row" ),

				[nameof( RadioGroupSlots.Description )] = ElementClass.Empty()
					.Add( "text-tiny" )
					.Add( "text-foreground-400" ),
			}
		} );
	}
}
