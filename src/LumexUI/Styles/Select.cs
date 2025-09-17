using System.Diagnostics.CodeAnalysis;
using System.Reflection.Emit;

using LumexUI.Common;
using LumexUI.Utilities;

using TailwindMerge;

namespace LumexUI.Styles;

[ExcludeFromCodeCoverage]
internal static class Select
{
	private static ComponentVariant? _variant;

	public static ComponentVariant Styles( TwMerge twMerge )
	{
		var twVariant = new TwVariants( twMerge );

		return _variant ??= twVariant.Create( new VariantConfig()
		{
			Slots = new SlotCollection
			{
				[nameof( SelectSlots.Base )] = ElementClass.Empty()
					.Add( "relative" )
					.Add( "group" )
					.Add( "flex" )
					.Add( "flex-col" ),

				[nameof( SelectSlots.Label )] = ElementClass.Empty()
					.Add( "z-10" )
					.Add( "block" )
					.Add( "absolute" )
					.Add( "origin-top-left" )
					.Add( "text-small" )
					.Add( "text-foreground-500" )
					.Add( "pointer-events-none" )
					// transition
					.Add( "will-change-auto" )
					.Add( "origin-top-left" )
					.Add( "transition-[transform,color,left,opacity,translate,scale]" )
					.Add( "motion-reduce:transition-none" ),

				[nameof( SelectSlots.MainWrapper )] = ElementClass.Empty()
					.Add( "w-full" )
					.Add( "flex" )
					.Add( "flex-col" ),

				[nameof( SelectSlots.Trigger )] = ElementClass.Empty()
					.Add( "relative" )
					.Add( "w-full" )
					.Add( "inline-flex" )
					.Add( "items-center" )
					.Add( "gap-3" )
					.Add( "px-3" )
					.Add( "shadow-xs" )
					.Add( "outline-hidden" )
					.Add( "cursor-pointer" )
					// transition
					.Add( "transition-[background]" )
					.Add( "motion-reduce:transition-none" ),

				[nameof( SelectSlots.InnerWrapper )] = ElementClass.Empty()
					.Add( "h-full" )
					.Add( "min-h-4" )
					.Add( "w-[calc(100%_-_--spacing(6))]" )
					.Add( "gap-1.5" )
					.Add( "inline-flex" )
					.Add( "items-center" ),

				[nameof( SelectSlots.SelectorIcon )] = ElementClass.Empty()
					.Add( "absolute" )
					.Add( "w-4" )
					.Add( "h-4" )
					.Add( "end-3" )
					.Add( "data-[open=true]:rotate-180" )
					// transition
					.Add( "duration-200" )
					.Add( "ease-out" )
					.Add( "transition-colors-transform-opacity" )
					.Add( "motion-reduce:transition-none" ),

				[nameof( SelectSlots.Value )] = ElementClass.Empty()
					.Add( "w-full" )
					.Add( "text-left" )
					.Add( "text-foreground-500" )
					.Add( "truncate" )
					// transition
					.Add( "transition-colors" )
					.Add( "motion-reduce:transition-none" ),

				[nameof( SelectSlots.Listbox )] = ElementClass.Empty()
					.Add( "overflow-y-auto" )
					.Add( "scrollbar-hide" ),

				[nameof( SelectSlots.PopoverContent )] = ElementClass.Empty()
					.Add( "w-full" )
					.Add( "p-1" )
					.Add( "overflow-hidden" ),

				[nameof( SelectSlots.HelperWrapper )] = ElementClass.Empty()
					.Add( "relative" )
					.Add( "flex" )
					.Add( "flex-col" )
					.Add( "gap-1.5" )
					.Add( "p-1" ),

				[nameof( SelectSlots.Description )] = ElementClass.Empty()
					.Add( "text-tiny" )
					.Add( "text-foreground-400" ),

				[nameof( SelectSlots.ErrorMessage )] = ElementClass.Empty()
					.Add( "text-tiny" )
					.Add( "text-danger" )
			},

			Variants = new VariantCollection
			{
				[nameof( LumexSelect<object>.FullWidth )] = new VariantValueCollection
				{
					[bool.TrueString] = new SlotCollection
					{
						[nameof( SelectSlots.Base )] = "w-full"
					}
				},

				[nameof( LumexSelect<object>.Disabled )] = new VariantValueCollection
				{
					[bool.TrueString] = new SlotCollection
					{
						[nameof( SelectSlots.Base )] = Utils.Disabled,
						[nameof( SelectSlots.Trigger )] = "pointer-events-none"
					}
				},

				[nameof( LumexSelect<object>.Required )] = new VariantValueCollection
				{
					[bool.TrueString] = new SlotCollection
					{
						[nameof( SelectSlots.Label )] = "after:content-['*'] after:text-danger after:ms-0.5",
					}
				},

				[nameof( LumexSelect<object>.LabelPlacement )] = new VariantValueCollection
				{
					[nameof( LabelPlacement.Outside )] = new SlotCollection
					{
						[nameof( SelectSlots.Base )] = "flex flex-col"
					},
					[nameof( LabelPlacement.Inside )] = new SlotCollection
					{
						[nameof( SelectSlots.Label )] = "cursor-pointer group-data-[filled=true]:scale-[0.85]",
						[nameof( SelectSlots.Trigger )] = "flex-col items-start justify-center gap-0",
					},
				},


				[nameof( LumexSelect<object>.Size )] = new VariantValueCollection
				{
					[nameof( Size.Small )] = new SlotCollection
					{
						[nameof( SelectSlots.Label )] = "text-tiny",
						[nameof( SelectSlots.Trigger )] = "h-8 min-h-8 rounded-small",
						[nameof( SelectSlots.Value )] = "text-small",
					},
					[nameof( Size.Medium )] = new SlotCollection
					{
						[nameof( SelectSlots.Trigger )] = "h-10 min-h-10 rounded-medium",
						[nameof( SelectSlots.Value )] = "text-small",
					},
					[nameof( Size.Large )] = new SlotCollection
					{
						[nameof( SelectSlots.Trigger )] = "h-12 min-h-12 rounded-large",
						[nameof( SelectSlots.Value )] = "text-medium",
					}
				},

				[nameof( LumexSelect<object>.Radius )] = new VariantValueCollection
				{
					[nameof( Radius.None )] = new SlotCollection
					{
						[nameof( SelectSlots.Trigger )] = "rounded-none"
					},
					[nameof( Radius.Small )] = new SlotCollection
					{
						[nameof( SelectSlots.Trigger )] = "rounded-small"
					},
					[nameof( Radius.Medium )] = new SlotCollection
					{
						[nameof( SelectSlots.Trigger )] = "rounded-medium"
					},
					[nameof( Radius.Large )] = new SlotCollection
					{
						[nameof( SelectSlots.Trigger )] = "rounded-large"
					},
				},

				[nameof( LumexSelect<object>.Variant )] = new VariantValueCollection
				{
					[nameof( InputVariant.Flat )] = new SlotCollection
					{
						[nameof( SelectSlots.Trigger )] = "bg-default-100 group-hover:bg-default-200",
					},
					[nameof( InputVariant.Outlined )] = new SlotCollection
					{
						[nameof( SelectSlots.Value )] = "group-data-[has-value=true]:text-default-foreground",

						[nameof( SelectSlots.Trigger )] = ElementClass.Empty()
							.Add( "border-2" )
							.Add( "border-default-200" )
							.Add( "data-[open=true]:border-default-foreground" )
							.Add( "group-data-[focus=true]:border-default-foreground" )
							.Add( "group-data-[focus=false]:hover:border-default-400" )
							.Add( "transition-colors" )
							.Add( "motion-reduce:transition-none" ),
					},
					[nameof( InputVariant.Underlined )] = new SlotCollection
					{
						[nameof( SelectSlots.Value )] = "group-data-[has-value=true]:text-default-foreground",

						[nameof( SelectSlots.Trigger )] = ElementClass.Empty()
							.Add( "!px-1" )
							.Add( "!pb-0" )
							.Add( "!gap-0" )
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
							.Add( "data-[open=true]:after:w-full" )
							.Add( "group-data-[focus=true]:after:w-full" )
							.Add( "after:transition-[width]" )
							.Add( "motion-reduce:after:transition-none" )
							.Add( "motion-reduce:after:transition-none" ),
					},
				}
			},

			CompoundVariants =
			[
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexSelect<object>.Variant)] = nameof(InputVariant.Flat),
						[nameof(LumexSelect<object>.Color)] = nameof(ThemeColor.Default),
					},
					Classes = new()
					{
						[nameof( SelectSlots.Value )] = "group-data-[has-value=true]:text-default-foreground",
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexSelect<object>.Variant)] = nameof(InputVariant.Flat),
						[nameof(LumexSelect<object>.Color)] = nameof(ThemeColor.Primary),
					},
					Classes = new()
					{
						[nameof( SelectSlots.Trigger )] = "bg-primary/20 group-hover:bg-primary/10 group-data-[focus=true]:bg-primary/10",
						[nameof( SelectSlots.Value )] = "text-primary dark:text-primary-500",
						[nameof( SelectSlots.Label )] = "text-primary dark:text-primary-500",
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexSelect<object>.Variant)] = nameof(InputVariant.Flat),
						[nameof(LumexSelect<object>.Color)] = nameof(ThemeColor.Secondary),
					},
					Classes = new()
					{
						[nameof( SelectSlots.Trigger )] = "bg-secondary/20 group-hover:bg-secondary/10 group-data-[focus=true]:bg-secondary/10",
						[nameof( SelectSlots.Value )] = "text-secondary dark:text-secondary-500",
						[nameof( SelectSlots.Label )] = "text-secondary dark:text-secondary-500",
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexSelect<object>.Variant)] = nameof(InputVariant.Flat),
						[nameof(LumexSelect<object>.Color)] = nameof(ThemeColor.Success),
					},
					Classes = new()
					{
						[nameof( SelectSlots.Trigger )] = "bg-success/20 group-hover:bg-success/10 group-data-[focus=true]:bg-success/10",
						[nameof( SelectSlots.Value )] = "text-success-700 dark:text-success",
						[nameof( SelectSlots.Label )] = "text-success-700 dark:text-success",
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexSelect<object>.Variant)] = nameof(InputVariant.Flat),
						[nameof(LumexSelect<object>.Color)] = nameof(ThemeColor.Warning),
					},
					Classes = new()
					{
						[nameof( SelectSlots.Trigger )] = "bg-warning/20 group-hover:bg-warning/10 group-data-[focus=true]:bg-warning/10",
						[nameof( SelectSlots.Value )] = "text-warning-700 dark:text-warning",
						[nameof( SelectSlots.Label )] = "text-warning-700 dark:text-warning",
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexSelect<object>.Variant)] = nameof(InputVariant.Flat),
						[nameof(LumexSelect<object>.Color)] = nameof(ThemeColor.Danger),
					},
					Classes = new()
					{
						[nameof( SelectSlots.Trigger )] = "bg-danger/20 group-hover:bg-danger/10 group-data-[focus=true]:bg-danger/10",
						[nameof( SelectSlots.Value )] = "text-danger-700 dark:text-danger-500",
						[nameof( SelectSlots.Label )] = "text-danger-700 dark:text-danger-500",
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexSelect<object>.Variant)] = nameof(InputVariant.Flat),
						[nameof(LumexSelect<object>.Color)] = nameof(ThemeColor.Info),
					},
					Classes = new()
					{
						[nameof( SelectSlots.Trigger )] = "bg-info/20 group-hover:bg-info/10 group-data-[focus=true]:bg-info/10",
						[nameof( SelectSlots.Value )] = "text-info-700 dark:text-info-500",
						[nameof( SelectSlots.Label )] = "text-info-700 dark:text-info-500",
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexSelect<object>.Variant)] = nameof(InputVariant.Underlined),
						[nameof(LumexSelect<object>.Color)] = nameof(ThemeColor.Default),
					},
					Classes = new()
					{
						[nameof( SelectSlots.Value )] = "group-data-[has-value=true]:text-foreground",
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexSelect<object>.Variant)] = nameof(InputVariant.Underlined),
						[nameof(LumexSelect<object>.Color)] = nameof(ThemeColor.Primary),
					},
					Classes = new()
					{
						[nameof(SelectSlots.Trigger)] = "after:bg-primary",
						[nameof(SelectSlots.Label)] = "text-primary",
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexSelect<object>.Variant)] = nameof(InputVariant.Underlined),
						[nameof(LumexSelect<object>.Color)] = nameof(ThemeColor.Secondary),
					},
					Classes = new()
					{
						[nameof(SelectSlots.Trigger)] = "after:bg-secondary",
						[nameof(SelectSlots.Label)] = "text-secondary",
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexSelect<object>.Variant)] = nameof(InputVariant.Underlined),
						[nameof(LumexSelect<object>.Color)] = nameof(ThemeColor.Success),
					},
					Classes = new()
					{
						[nameof(SelectSlots.Trigger)] = "after:bg-success",
						[nameof(SelectSlots.Label)] = "text-success",
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexSelect<object>.Variant)] = nameof(InputVariant.Underlined),
						[nameof(LumexSelect<object>.Color)] = nameof(ThemeColor.Warning),
					},
					Classes = new()
					{
						[nameof(SelectSlots.Trigger)] = "after:bg-warning",
						[nameof(SelectSlots.Label)] = "text-warning",
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexSelect<object>.Variant)] = nameof(InputVariant.Underlined),
						[nameof(LumexSelect<object>.Color)] = nameof(ThemeColor.Danger),
					},
					Classes = new()
					{
						[nameof(SelectSlots.Trigger)] = "after:bg-danger",
						[nameof(SelectSlots.Label)] = "text-danger",
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexSelect<object>.Variant)] = nameof(InputVariant.Underlined),
						[nameof(LumexSelect<object>.Color)] = nameof(ThemeColor.Info),
					},
					Classes = new()
					{
						[nameof(SelectSlots.Trigger)] = "after:bg-info",
						[nameof(SelectSlots.Label)] = "text-info",
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexSelect<object>.Variant)] = nameof(InputVariant.Outlined),
						[nameof(LumexSelect<object>.Color)] = nameof(ThemeColor.Primary),
					},
					Classes = new()
					{
						[nameof(SelectSlots.Trigger)] = "data-[open=true]:border-primary group-data-[focus=true]:border-primary",
						[nameof(SelectSlots.Label)] = "text-primary",
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexSelect<object>.Variant)] = nameof(InputVariant.Outlined),
						[nameof(LumexSelect<object>.Color)] = nameof(ThemeColor.Secondary),
					},
					Classes = new()
					{
						[nameof(SelectSlots.Trigger)] = "data-[open=true]:border-secondary group-data-[focus=true]:border-secondary",
						[nameof(SelectSlots.Label)] = "text-secondary",
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexSelect<object>.Variant)] = nameof(InputVariant.Outlined),
						[nameof(LumexSelect<object>.Color)] = nameof(ThemeColor.Success),
					},
					Classes = new()
					{
						[nameof(SelectSlots.Trigger)] = "data-[open=true]:border-success group-data-[focus=true]:border-success",
						[nameof(SelectSlots.Label)] = "text-success",
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexSelect<object>.Variant)] = nameof(InputVariant.Outlined),
						[nameof(LumexSelect<object>.Color)] = nameof(ThemeColor.Warning),
					},
					Classes = new()
					{
						[nameof(SelectSlots.Trigger)] = "data-[open=true]:border-warning group-data-[focus=true]:border-warning",
						[nameof(SelectSlots.Label)] = "text-warning",
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexSelect<object>.Variant)] = nameof(InputVariant.Outlined),
						[nameof(LumexSelect<object>.Color)] = nameof(ThemeColor.Danger),
					},
					Classes = new()
					{
						[nameof(SelectSlots.Trigger)] = "data-[open=true]:border-danger group-data-[focus=true]:border-danger",
						[nameof(SelectSlots.Label)] = "text-danger",
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexSelect<object>.Variant)] = nameof(InputVariant.Outlined),
						[nameof(LumexSelect<object>.Color)] = nameof(ThemeColor.Info),
					},
					Classes = new()
					{
						[nameof(SelectSlots.Trigger)] = "data-[open=true]:border-info group-data-[focus=true]:border-info",
						[nameof(SelectSlots.Label)] = "text-info",
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexSelect<object>.Color)] = nameof(ThemeColor.Default),
						[nameof(LumexSelect<object>.LabelPlacement)] = nameof(LabelPlacement.Inside),
					},
					Classes = new()
					{
						[nameof(SelectSlots.Label)] = "group-data-[filled=true]:text-default-600",
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexSelect<object>.Color)] = nameof(ThemeColor.Default),
						[nameof(LumexSelect<object>.LabelPlacement)] = nameof(LabelPlacement.Outside),
					},
					Classes = new()
					{
						[nameof(SelectSlots.Label)] = "group-data-[filled=true]:text-foreground",
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexSelect<object>.LabelPlacement)] = nameof(LabelPlacement.Inside),
						[nameof(LumexSelect<object>.Size)] = nameof(Size.Small),
					},
					Classes = new()
					{
						[nameof(SelectSlots.Label)] = "text-small",
						[nameof(SelectSlots.Trigger)] = "h-12 min-h-12 py-1.5",
						[nameof(SelectSlots.InnerWrapper)] = "group-has-[label]:pt-4",
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexSelect<object>.LabelPlacement)] = nameof(LabelPlacement.Inside),
						[nameof(LumexSelect<object>.Size)] = nameof(Size.Medium),
					},
					Classes = new()
					{
						[nameof(SelectSlots.Label)] = "text-small",
						[nameof(SelectSlots.Trigger)] = "h-14 min-h-14 py-2",
						[nameof(SelectSlots.InnerWrapper)] = "group-has-[label]:pt-4",
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexSelect<object>.LabelPlacement)] = nameof(LabelPlacement.Inside),
						[nameof(LumexSelect<object>.Size)] = nameof(Size.Large),
					},
					Classes = new()
					{
						[nameof(SelectSlots.Label)] = "text-medium",
						[nameof(SelectSlots.Trigger)] = "h-16 min-h-16 py-2.5",
						[nameof(SelectSlots.InnerWrapper)] = "group-has-[label]:pt-4",
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexSelect<object>.LabelPlacement)] = nameof(LabelPlacement.Outside),
						[nameof(LumexSelect<object>.Size)] = nameof(Size.Small),
					},
					Classes = new()
					{
						[nameof(SelectSlots.Base)] = "justify-end has-[label]:mt-[calc(var(--text-small)_+_8px)]",
						[nameof(SelectSlots.Label)] = ElementClass.Empty()
							.Add( "text-tiny" )
							.Add( "z-20" )
							.Add( "top-1/2" )
							.Add( "start-2" )
							.Add( "-translate-y-1/2" )
							.Add( "group-data-[filled=true]:start-0" )
							.Add( "group-data-[filled=true]:-translate-y-[calc(100%_+_var(--text-tiny)/2_+_16px)]" )
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexSelect<object>.LabelPlacement)] = nameof(LabelPlacement.Outside),
						[nameof(LumexSelect<object>.Size)] = nameof(Size.Medium),
					},
					Classes = new()
					{
						[nameof(SelectSlots.Base)] = "justify-end has-[label]:mt-[calc(var(--text-small)_+_10px)]",
						[nameof(SelectSlots.Label)] = ElementClass.Empty()
							.Add( "text-small" )
							.Add( "z-20" )
							.Add( "top-1/2" )
							.Add( "start-3" )
							.Add( "-translate-y-1/2" )
							.Add( "group-data-[filled=true]:start-0" )
							.Add( "group-data-[filled=true]:-translate-y-[calc(100%_+_var(--text-small)/2_+_20px)]" )
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexSelect<object>.LabelPlacement)] = nameof(LabelPlacement.Outside),
						[nameof(LumexSelect<object>.Size)] = nameof(Size.Large),
					},
					Classes = new()
					{
						[nameof(SelectSlots.Base)] = "justify-end has-[label]:mt-[calc(var(--text-small)_+_12px)]",
						[nameof(SelectSlots.Label)] = ElementClass.Empty()
							.Add( "text-medium" )
							.Add( "z-20" )
							.Add( "top-1/2" )
							.Add( "start-3" )
							.Add( "-translate-y-1/2" )
							.Add( "group-data-[filled=true]:start-0" )
							.Add( "group-data-[filled=true]:-translate-y-[calc(100%_+_var(--text-small)/2_+_24px)]" ),
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexSelect<object>.LabelPlacement)] = nameof(LabelPlacement.Inside),
						[nameof(LumexSelect<object>.Variant)] = nameof(InputVariant.Flat),
						[nameof(LumexSelect<object>.Size)] = nameof(Size.Small),
					},
					Classes = new()
					{
						[nameof(SelectSlots.Label)] = "group-data-[filled=true]:-translate-y-[calc(50%_+_var(--text-tiny)/2_-_8px)]",
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexSelect<object>.LabelPlacement)] = nameof(LabelPlacement.Inside),
						[nameof(LumexSelect<object>.Variant)] = nameof(InputVariant.Flat),
						[nameof(LumexSelect<object>.Size)] = nameof(Size.Medium),
					},
					Classes = new()
					{
						[nameof(SelectSlots.Label)] = "group-data-[filled=true]:-translate-y-[calc(50%_+_var(--text-small)/2_-_6px)]",
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexSelect<object>.LabelPlacement)] = nameof(LabelPlacement.Inside),
						[nameof(LumexSelect<object>.Variant)] = nameof(InputVariant.Flat),
						[nameof(LumexSelect<object>.Size)] = nameof(Size.Large),
					},
					Classes = new()
					{
						[nameof(SelectSlots.Label)] = "group-data-[filled=true]:-translate-y-[calc(50%_+_var(--text-small)/2_-_8px)]",
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexSelect<object>.LabelPlacement)] = nameof(LabelPlacement.Inside),
						[nameof(LumexSelect<object>.Variant)] = nameof(InputVariant.Outlined),
						[nameof(LumexSelect<object>.Size)] = nameof(Size.Small),
					},
					Classes = new()
					{
						[nameof(SelectSlots.Label)] = "group-data-[filled=true]:-translate-y-[calc(50%_+_var(--text-tiny)/2_-_8px_-_--spacing(0.5))]",
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexSelect<object>.LabelPlacement)] = nameof(LabelPlacement.Inside),
						[nameof(LumexSelect<object>.Variant)] = nameof(InputVariant.Outlined),
						[nameof(LumexSelect<object>.Size)] = nameof(Size.Medium),
					},
					Classes = new()
					{
						[nameof(SelectSlots.Label)] = "group-data-[filled=true]:-translate-y-[calc(50%_+_var(--text-small)/2_-_6px_-_--spacing(0.5))]",
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexSelect<object>.LabelPlacement)] = nameof(LabelPlacement.Inside),
						[nameof(LumexSelect<object>.Variant)] = nameof(InputVariant.Outlined),
						[nameof(LumexSelect<object>.Size)] = nameof(Size.Large),
					},
					Classes = new()
					{
						[nameof(SelectSlots.Label)] = "group-data-[filled=true]:-translate-y-[calc(50%_+_var(--text-small)/2_-_8px_-_--spacing(0.5))]",
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexSelect<object>.LabelPlacement)] = nameof(LabelPlacement.Inside),
						[nameof(LumexSelect<object>.Variant)] = nameof(InputVariant.Underlined),
						[nameof(LumexSelect<object>.Size)] = nameof(Size.Small),
					},
					Classes = new()
					{
						[nameof(SelectSlots.Label)] = "group-data-[filled=true]:-translate-y-[calc(50%_+_var(--text-tiny)/2_-_5px)]",
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexSelect<object>.LabelPlacement)] = nameof(LabelPlacement.Inside),
						[nameof(LumexSelect<object>.Variant)] = nameof(InputVariant.Underlined),
						[nameof(LumexSelect<object>.Size)] = nameof(Size.Medium),
					},
					Classes = new()
					{
						[nameof(SelectSlots.Label)] = "group-data-[filled=true]:-translate-y-[calc(50%_+_var(--text-small)/2_-_3.5px)]",
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexSelect<object>.LabelPlacement)] = nameof(LabelPlacement.Inside),
						[nameof(LumexSelect<object>.Variant)] = nameof(InputVariant.Underlined),
						[nameof(LumexSelect<object>.Size)] = nameof(Size.Large),
					},
					Classes = new()
					{
						[nameof(SelectSlots.Label)] = "group-data-[filled=true]:-translate-y-[calc(50%_+_var(--text-small)/2_-_4px)]",
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexSelect<object>.Invalid)] = bool.TrueString,
						[nameof(LumexSelect<object>.Variant)] = nameof(InputVariant.Flat),
					},
					Classes = new()
					{
						[nameof(SelectSlots.Trigger)] = "bg-danger/20 group-hover:bg-danger/10 group-data-[focus=true]:bg-danger/10",
						[nameof(SelectSlots.Label)] = "text-danger-700! dark:text-danger-500!",
						[nameof(SelectSlots.Value)] = "text-danger-700! dark:text-danger-500!",
						[nameof(SelectSlots.SelectorIcon)] = "text-danger-700! dark:text-danger-500!",
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexSelect<object>.Invalid)] = bool.TrueString,
						[nameof(LumexSelect<object>.Variant)] = nameof(InputVariant.Outlined),
					},
					Classes = new()
					{
						[nameof(SelectSlots.Trigger)] = "border-danger group-data-[focus=true]:border-danger",
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexSelect<object>.Invalid)] = bool.TrueString,
						[nameof(LumexSelect<object>.Variant)] = nameof(InputVariant.Underlined),
					},
					Classes = new()
					{
						[nameof(SelectSlots.Trigger)] = "after:bg-danger",
					}
				},
			]
		} );
	}
}