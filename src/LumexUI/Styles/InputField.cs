// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;
using System.Reflection.Emit;

using LumexUI.Common;
using LumexUI.Utilities;

using TailwindMerge;

namespace LumexUI.Styles;

[ExcludeFromCodeCoverage]
internal static class InputField
{
	private static ComponentVariant? _variant;

	public static ComponentVariant Style( TwMerge twMerge )
	{
		var twVariants = new TwVariants( twMerge );

		return _variant ??= twVariants.Create( new VariantConfig()
		{
			Slots = new SlotCollection
			{
				[nameof( InputFieldSlots.Base )] = ElementClass.Empty()
					.Add( "group" )
					.Add( "relative" )
					.Add( "flex" )
					.Add( "flex-col" )
					.Add( "data-[hidden=true]:hidden" ),

				[nameof( InputFieldSlots.Label )] = ElementClass.Empty()
					.Add( "absolute" )
					.Add( "z-10" )
					.Add( "block" )
					.Add( "text-small" )
					.Add( "text-foreground-500" )
					.Add( "origin-top-left" )
					.Add( "pointer-events-none" )
					.Add( "subpixel-antialiased" )
					.Add( "pe-2" )
					.Add( "max-w-full" )
					.Add( "text-ellipsis" )
					.Add( "overflow-hidden" )
					.Add( "group-data-[filled-focused=true]:pointer-events-auto" )
					// transition
					.Add( "will-change-auto" )
					.Add( "transition-[transform,color,left,opacity,translate,scale]" )
					.Add( "motion-reduce:transition-none" ),

				[nameof( InputFieldSlots.MainWrapper )] = ElementClass.Empty()
					.Add( "h-full" ),

				[nameof( InputFieldSlots.InputWrapper )] = ElementClass.Empty()
					.Add( "relative" )
					.Add( "inline-flex" )
					.Add( "items-center" )
					.Add( "px-3" )
					.Add( "gap-3" )
					.Add( "w-full" )
					.Add( "shadow-xs" )
					.Add( "cursor-text" )
					// transition
					.Add( "transition-[background]" )
					.Add( "motion-reduce:transition-none" ),

				[nameof( InputFieldSlots.InnerWrapper )] = ElementClass.Empty()
					.Add( "inline-flex" )
					.Add( "items-center" )
					.Add( "w-full" )
					.Add( "h-full" )
					.Add( "data-[has-clear-button=true]:pe-7" ),

				[nameof( InputFieldSlots.Input )] = ElementClass.Empty()
					.Add( "w-full" )
					.Add( "font-normal" )
					.Add( "bg-transparent" )
					.Add( "focus-visible:outline-hidden" )
					.Add( "placeholder:text-foreground-500" )
					.Add( "autofill:bg-transparent" )
					.Add( "data-[has-start-content=true]:ps-1.5" )
					.Add( "data-[has-end-content=true]:pe-1.5" ),

				[nameof( InputFieldSlots.ClearButton )] = ElementClass.Empty()
					.Add( "p-0.5" )
					.Add( "z-10" )
					.Add( "absolute" )
					.Add( "end-1.5" )
					.Add( "select-none" )
					.Add( "hover:!opacity-100" )
					.Add( "active:!opacity-focus" )
					.Add( "rounded-full" )
					.Add( "cursor-pointer" )
					// transition
					.Add( "transition-opacity" )
					.Add( "motion-reduce:transition-none" )
					// focus ring
					.Add( Utils.FocusVisible ),

				[nameof( InputFieldSlots.HelperWrapper )] = ElementClass.Empty()
					.Add( "relative" )
					.Add( "flex" )
					.Add( "flex-col" )
					.Add( "gap-1.5" )
					.Add( "p-1" ),

				[nameof( InputFieldSlots.Description )] = ElementClass.Empty()
					.Add( "text-tiny" )
					.Add( "text-foreground-400" ),

				[nameof( InputFieldSlots.ErrorMessage )] = ElementClass.Empty()
					.Add( "text-tiny" )
					.Add( "text-danger" ),
			},

			Variants = new VariantCollection
			{
				[nameof( LumexInputFieldBase<object>.Size )] = new VariantValueCollection
				{
					[nameof( Size.Small )] = new SlotCollection
					{
						[nameof( InputFieldSlots.InputWrapper )] = "h-8 min-h-8 rounded-small",
						[nameof( InputFieldSlots.Input )] = "text-small",
						[nameof( InputFieldSlots.ClearButton )] = "text-medium",
					},
					[nameof( Size.Medium )] = new SlotCollection
					{
						[nameof( InputFieldSlots.InputWrapper )] = "h-10 min-h-10 rounded-medium",
						[nameof( InputFieldSlots.Input )] = "text-small",
						[nameof( InputFieldSlots.ClearButton )] = "text-large",
					},
					[nameof( Size.Large )] = new SlotCollection
					{
						[nameof( InputFieldSlots.InputWrapper )] = "h-12 min-h-12 rounded-large",
						[nameof( InputFieldSlots.Input )] = "text-medium",
						[nameof( InputFieldSlots.ClearButton )] = "text-large",
					},
				},

				[nameof( LumexInputFieldBase<object>.Radius )] = new VariantValueCollection
				{
					[nameof( Radius.None )] = new SlotCollection
					{
						[nameof( InputFieldSlots.InputWrapper )] = "rounded-none"
					},
					[nameof( Radius.Small )] = new SlotCollection
					{
						[nameof( InputFieldSlots.InputWrapper )] = "rounded-small"
					},
					[nameof( Radius.Medium )] = new SlotCollection
					{
						[nameof( InputFieldSlots.InputWrapper )] = "rounded-medium"
					},
					[nameof( Radius.Large )] = new SlotCollection
					{
						[nameof( InputFieldSlots.InputWrapper )] = "rounded-large"
					},
				},

				[nameof( LumexInputFieldBase<object>.Disabled )] = new VariantValueCollection
				{
					[bool.TrueString] = new SlotCollection
					{
						[nameof( InputFieldSlots.Base )] = Utils.Disabled
					}
				},

				[nameof( LumexInputFieldBase<object>.FullWidth )] = new VariantValueCollection
				{
					[bool.TrueString] = new SlotCollection
					{
						[nameof( InputFieldSlots.Base )] = "w-full"
					}
				},

				[nameof( LumexInputFieldBase<object>.Clearable )] = new VariantValueCollection
				{
					[bool.TrueString] = new SlotCollection
					{
						[nameof( InputFieldSlots.Input )] = "peer",
						[nameof( InputFieldSlots.ClearButton )] = "peer-data-[filled=true]:opacity-focus"
					}
				},

				[nameof( LumexInputFieldBase<object>.Required )] = new VariantValueCollection
				{
					[bool.TrueString] = new SlotCollection
					{
						[nameof( InputFieldSlots.Label )] = "after:content-['*'] after:text-danger after:ms-0.5"
					}
				},

				[nameof( LumexInputFieldBase<object>.Variant )] = new VariantValueCollection
				{
					[nameof( InputVariant.Flat )] = new SlotCollection
					{
						[nameof( InputFieldSlots.InputWrapper )] = "bg-default-100 group-hover:bg-default-200"
					},
					[nameof( InputVariant.Outlined )] = new SlotCollection
					{
						[nameof( InputFieldSlots.InputWrapper )] = ElementClass.Empty()
							.Add( "border-2" )
							.Add( "border-default-200" )
							.Add( "group-data-[focus=true]:border-default-foreground" )
							.Add( "group-data-[focus=false]:hover:border-default-400" )
							.Add( "transition-colors" )
					},
					[nameof( InputVariant.Underlined )] = new SlotCollection
					{
						[nameof( InputFieldSlots.InputWrapper )] = ElementClass.Empty()
							.Add( "!px-1" )
							.Add( "!pb-0" )
							.Add( "!rounded-none" )
							.Add( "relative" )
							.Add( "border-b-2" )
							.Add( "border-default-200" )
							.Add( "shadow-[0_1px_0px_0_rgba(0,0,0,0.05)]" )
							.Add( "hover:border-default-300" )
							.Add( "after:w-0" )
							.Add( "after:origin-center" )
							.Add( "after:bg-default-foreground" )
							.Add( "after:absolute" )
							.Add( "after:left-1/2" )
							.Add( "after:-translate-x-1/2" )
							.Add( "after:-bottom-[2px]" )
							.Add( "after:h-[2px]" )
							.Add( "after:transition-[width]" )
							.Add( "group-data-[focus=true]:after:w-full" )
					},
				},

				[nameof( LumexInputFieldBase<object>.LabelPlacement )] = new VariantValueCollection
				{
					[nameof(LabelPlacement.Inside)] = new SlotCollection
					{
						[nameof(InputFieldSlots.InputWrapper)] = "flex-col items-start justify-center",
						[nameof(InputFieldSlots.InnerWrapper)] = "group-has-[label]:items-end",
						[nameof(InputFieldSlots.Label)] = "cursor-text group-data-[filled-focused=true]:scale-[0.85]",
					},
					[nameof(LabelPlacement.Outside)] = new SlotCollection
					{
						[nameof(InputFieldSlots.Base)] = "justify-end",
						[nameof(InputFieldSlots.MainWrapper)] = "flex flex-col",
						[nameof(InputFieldSlots.Label)] = ElementClass.Empty()
							.Add( "z-20" )
							.Add( "top-1/2" )
							.Add( "-translate-y-1/2" )
							.Add( "group-data-[filled-focused=true]:left-0" ),
					},
				}
			},

			CompoundVariants =
			[
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexInputFieldBase<object>.Variant)] = nameof(InputVariant.Flat),
						[nameof(LumexInputFieldBase<object>.Color)] = nameof(ThemeColor.Default),
					},
					Classes = new SlotCollection
					{
						[nameof(InputFieldSlots.Input)] = "[&:not(placeholder-shown)]:text-default-foreground"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexInputFieldBase<object>.Variant)] = nameof(InputVariant.Flat),
						[nameof(LumexInputFieldBase<object>.Color)] = nameof(ThemeColor.Primary),
					},
					Classes = new SlotCollection
					{
						[nameof(InputFieldSlots.InputWrapper)] = "bg-primary/20 group-hover:bg-primary/10 group-data-[focus=true]:bg-primary/10",
						[nameof(InputFieldSlots.Input)] = "text-primary placeholder:text-primary dark:text-primary-500 dark:placeholder:text-primary-500",
						[nameof(InputFieldSlots.Label)] = "text-primary dark:text-primary-500"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexInputFieldBase<object>.Variant)] = nameof(InputVariant.Flat),
						[nameof(LumexInputFieldBase<object>.Color)] = nameof(ThemeColor.Secondary),
					},
					Classes = new SlotCollection
					{
						[nameof(InputFieldSlots.InputWrapper)] = "bg-secondary/20 group-hover:bg-secondary/10 group-data-[focus=true]:bg-secondary/10",
						[nameof(InputFieldSlots.Input)] = "text-secondary placeholder:text-secondary dark:text-secondary-500 dark:placeholder:text-secondary-500",
						[nameof(InputFieldSlots.Label)] = "text-secondary dark:text-secondary-500"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexInputFieldBase<object>.Variant)] = nameof(InputVariant.Flat),
						[nameof(LumexInputFieldBase<object>.Color)] = nameof(ThemeColor.Success),
					},
					Classes = new SlotCollection
					{
						[nameof(InputFieldSlots.InputWrapper)] = "bg-success/20 group-hover:bg-success/10 group-data-[focus=true]:bg-success/10",
						[nameof(InputFieldSlots.Input)] = "text-success-700 placeholder:text-success-700 dark:text-success dark:placeholder:text-success",
						[nameof(InputFieldSlots.Label)] = "text-success-700 dark:text-success"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexInputFieldBase<object>.Variant)] = nameof(InputVariant.Flat),
						[nameof(LumexInputFieldBase<object>.Color)] = nameof(ThemeColor.Warning),
					},
					Classes = new SlotCollection
					{
						[nameof(InputFieldSlots.InputWrapper)] = "bg-warning/20 group-hover:bg-warning/10 group-data-[focus=true]:bg-warning/10",
						[nameof(InputFieldSlots.Input)] = "text-warning-700 placeholder:text-warning-700 dark:text-warning dark:placeholder:text-warning",
						[nameof(InputFieldSlots.Label)] = "text-warning-700 dark:text-warning"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexInputFieldBase<object>.Variant)] = nameof(InputVariant.Flat),
						[nameof(LumexInputFieldBase<object>.Color)] = nameof(ThemeColor.Danger),
					},
					Classes = new SlotCollection
					{
						[nameof(InputFieldSlots.InputWrapper)] = "bg-danger/20 group-hover:bg-danger/10 group-data-[focus=true]:bg-danger/10",
						[nameof(InputFieldSlots.Input)] = "text-danger-700 placeholder:text-danger-700 dark:text-danger-500 dark:placeholder:text-danger-500",
						[nameof(InputFieldSlots.Label)] = "text-danger-700 dark:text-danger-500"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexInputFieldBase<object>.Variant)] = nameof(InputVariant.Flat),
						[nameof(LumexInputFieldBase<object>.Color)] = nameof(ThemeColor.Info),
					},
					Classes = new SlotCollection
					{
						[nameof(InputFieldSlots.InputWrapper)] = "bg-info/20 group-hover:bg-info/10 group-data-[focus=true]:bg-info/10",
						[nameof(InputFieldSlots.Input)] = "text-info placeholder:text-info dark:text-info-500 dark:placeholder:text-info-500",
						[nameof(InputFieldSlots.Label)] = "text-info dark:text-info-500"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexInputFieldBase<object>.Variant)] = nameof(InputVariant.Outlined),
						[nameof(LumexInputFieldBase<object>.Color)] = nameof(ThemeColor.Primary),
					},
					Classes = new SlotCollection
					{
						[nameof(InputFieldSlots.InputWrapper)] = "group-data-[focus=true]:border-primary",
						[nameof(InputFieldSlots.Label)] = "text-primary"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexInputFieldBase<object>.Variant)] = nameof(InputVariant.Outlined),
						[nameof(LumexInputFieldBase<object>.Color)] = nameof(ThemeColor.Secondary),
					},
					Classes = new SlotCollection
					{
						[nameof(InputFieldSlots.InputWrapper)] = "group-data-[focus=true]:border-secondary",
						[nameof(InputFieldSlots.Label)] = "text-secondary"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexInputFieldBase<object>.Variant)] = nameof(InputVariant.Outlined),
						[nameof(LumexInputFieldBase<object>.Color)] = nameof(ThemeColor.Success),
					},
					Classes = new SlotCollection
					{
						[nameof(InputFieldSlots.InputWrapper)] = "group-data-[focus=true]:border-success",
						[nameof(InputFieldSlots.Label)] = "text-success"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexInputFieldBase<object>.Variant)] = nameof(InputVariant.Outlined),
						[nameof(LumexInputFieldBase<object>.Color)] = nameof(ThemeColor.Warning),
					},
					Classes = new SlotCollection
					{
						[nameof(InputFieldSlots.InputWrapper)] = "group-data-[focus=true]:border-warning",
						[nameof(InputFieldSlots.Label)] = "text-warning"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexInputFieldBase<object>.Variant)] = nameof(InputVariant.Outlined),
						[nameof(LumexInputFieldBase<object>.Color)] = nameof(ThemeColor.Danger),
					},
					Classes = new SlotCollection
					{
						[nameof(InputFieldSlots.InputWrapper)] = "group-data-[focus=true]:border-danger",
						[nameof(InputFieldSlots.Label)] = "text-danger"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexInputFieldBase<object>.Variant)] = nameof(InputVariant.Outlined),
						[nameof(LumexInputFieldBase<object>.Color)] = nameof(ThemeColor.Info),
					},
					Classes = new SlotCollection
					{
						[nameof(InputFieldSlots.InputWrapper)] = "group-data-[focus=true]:border-info",
						[nameof(InputFieldSlots.Label)] = "text-info"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexInputFieldBase<object>.Variant)] = nameof(InputVariant.Underlined),
						[nameof(LumexInputFieldBase<object>.Color)] = nameof(ThemeColor.Default),
					},
					Classes = new SlotCollection
					{
						[nameof(InputFieldSlots.Input)] = "[&:not(placeholder-shown)]:text-foreground"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexInputFieldBase<object>.Variant)] = nameof(InputVariant.Underlined),
						[nameof(LumexInputFieldBase<object>.Color)] = nameof(ThemeColor.Primary),
					},
					Classes = new SlotCollection
					{
						[nameof(InputFieldSlots.InputWrapper)] = "after:bg-primary",
						[nameof(InputFieldSlots.Label)] = "text-primary"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexInputFieldBase<object>.Variant)] = nameof(InputVariant.Underlined),
						[nameof(LumexInputFieldBase<object>.Color)] = nameof(ThemeColor.Secondary),
					},
					Classes = new SlotCollection
					{
						[nameof(InputFieldSlots.InputWrapper)] = "after:bg-secondary",
						[nameof(InputFieldSlots.Label)] = "text-secondary"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexInputFieldBase<object>.Variant)] = nameof(InputVariant.Underlined),
						[nameof(LumexInputFieldBase<object>.Color)] = nameof(ThemeColor.Success),
					},
					Classes = new SlotCollection
					{
						[nameof(InputFieldSlots.InputWrapper)] = "after:bg-success",
						[nameof(InputFieldSlots.Label)] = "text-success"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexInputFieldBase<object>.Variant)] = nameof(InputVariant.Underlined),
						[nameof(LumexInputFieldBase<object>.Color)] = nameof(ThemeColor.Warning),
					},
					Classes = new SlotCollection
					{
						[nameof(InputFieldSlots.InputWrapper)] = "after:bg-warning",
						[nameof(InputFieldSlots.Label)] = "text-warning"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexInputFieldBase<object>.Variant)] = nameof(InputVariant.Underlined),
						[nameof(LumexInputFieldBase<object>.Color)] = nameof(ThemeColor.Danger),
					},
					Classes = new SlotCollection
					{
						[nameof(InputFieldSlots.InputWrapper)] = "after:bg-danger",
						[nameof(InputFieldSlots.Label)] = "text-danger"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexInputFieldBase<object>.Variant)] = nameof(InputVariant.Underlined),
						[nameof(LumexInputFieldBase<object>.Color)] = nameof(ThemeColor.Info),
					},
					Classes = new SlotCollection
					{
						[nameof(InputFieldSlots.InputWrapper)] = "after:bg-info",
						[nameof(InputFieldSlots.Label)] = "text-info"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexInputFieldBase<object>.LabelPlacement)] = nameof(LabelPlacement.Inside),
						[nameof(LumexInputFieldBase<object>.Size)] = nameof(Size.Small),
					},
					Classes = new SlotCollection
					{
						[nameof(InputFieldSlots.InputWrapper)] = "h-12 py-1.5",
						[nameof(InputFieldSlots.Label)] = "text-small group-data-[filled-focused=true]:-translate-y-[calc(50%_+_var(--text-tiny)/2_-_8px)]"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexInputFieldBase<object>.LabelPlacement)] = nameof(LabelPlacement.Inside),
						[nameof(LumexInputFieldBase<object>.Size)] = nameof(Size.Medium),
					},
					Classes = new SlotCollection
					{
						[nameof(InputFieldSlots.InputWrapper)] = "h-14 py-2",
						[nameof(InputFieldSlots.Label)] = "text-small group-data-[filled-focused=true]:-translate-y-[calc(50%_+_var(--text-small)/2_-_6px)]"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexInputFieldBase<object>.LabelPlacement)] = nameof(LabelPlacement.Inside),
						[nameof(LumexInputFieldBase<object>.Size)] = nameof(Size.Large),
					},
					Classes = new SlotCollection
					{
						[nameof(InputFieldSlots.InputWrapper)] = "h-16 py-2.5",
						[nameof(InputFieldSlots.Label)] = "text-medium group-data-[filled-focused=true]:-translate-y-[calc(50%_+_var(--text-small)/2_-_8px)]"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexInputFieldBase<object>.LabelPlacement)] = nameof(LabelPlacement.Outside),
						[nameof(LumexInputFieldBase<object>.Size)] = nameof(Size.Small),
					},
					Classes = new SlotCollection
					{
						[nameof(InputFieldSlots.Base)] = "has-[label]:mt-[calc(var(--text-small))_+_8px)]",
						[nameof(InputFieldSlots.Label)] = "text-tiny left-2 group-data-[filled-focused=true]:-translate-y-[calc(100%_+_var(--text-tiny)/2_+_16px)]",
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexInputFieldBase<object>.LabelPlacement)] = nameof(LabelPlacement.Outside),
						[nameof(LumexInputFieldBase<object>.Size)] = nameof(Size.Medium),
					},
					Classes = new SlotCollection
					{
						[nameof(InputFieldSlots.Base)] = "has-[label]:mt-[calc(var(--text-small)_+_10px)]",
						[nameof(InputFieldSlots.Label)] = "text-small left-3 group-data-[filled-focused=true]:-translate-y-[calc(100%_+_var(--text-small)/2_+_20px)]",
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexInputFieldBase<object>.LabelPlacement)] = nameof(LabelPlacement.Outside),
						[nameof(LumexInputFieldBase<object>.Size)] = nameof(Size.Large),
					},
					Classes = new SlotCollection
					{
						[nameof(InputFieldSlots.Base)] = "has-[label]:mt-[calc(var(--text-small)_+_12px)]",
						[nameof(InputFieldSlots.Label)] = "text-medium left-3 group-data-[filled-focused=true]:-translate-y-[calc(100%_+_var(--text-small)/2_+_24px)]",
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexInputFieldBase<object>.Invalid)] = bool.TrueString,
						[nameof(LumexInputFieldBase<object>.Variant)] = nameof(InputVariant.Flat),
					},
					Classes = new SlotCollection
					{
						[nameof(InputFieldSlots.InputWrapper)] = "bg-danger/20! group-hover:bg-danger/10! group-data-[focus=true]:bg-danger/10!",
						[nameof(InputFieldSlots.Input)] = "text-danger-700! placeholder:text-danger-500!",
						[nameof(InputFieldSlots.Label)] = "text-danger-700!"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexInputFieldBase<object>.Invalid)] = bool.TrueString,
						[nameof(LumexInputFieldBase<object>.Variant)] = nameof(InputVariant.Outlined),
					},
					Classes = new SlotCollection
					{
						[nameof(InputFieldSlots.InputWrapper)] = "border-danger! group-data-[focus=true]:border-danger!"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexInputFieldBase<object>.Invalid)] = bool.TrueString,
						[nameof(LumexInputFieldBase<object>.Variant)] = nameof(InputVariant.Underlined),
					},
					Classes = new SlotCollection
					{
						[nameof(InputFieldSlots.InputWrapper)] = "after:bg-danger!"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexInputFieldBase<object>.Variant)] = nameof(InputVariant.Outlined),
						[nameof(LumexInputFieldBase<object>.Size)] = nameof(Size.Small),
					},
					Classes = new SlotCollection
					{
						[nameof(InputFieldSlots.InputWrapper)] = "py-1"
					}
				},
			]
		} );
	}
}