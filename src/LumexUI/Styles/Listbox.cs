using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;
using LumexUI.Utilities;

using TailwindMerge;

namespace LumexUI.Styles;

[ExcludeFromCodeCoverage]
internal static class Listbox
{
	private static ComponentVariant? _variant;

	public static ComponentVariant Styles( TwMerge twMerge )
	{
		var twVariants = new TwVariants( twMerge );

		return _variant ??= twVariants.Create( new VariantConfig()
		{
			Slots = new SlotCollection
			{
				[nameof( ListboxSlots.Base )] = ElementClass.Empty()
					.Add( "relative" )
					.Add( "w-full" )
					.Add( "p-1" )
					.Add( "gap-1" )
					.Add( "flex" )
					.Add( "flex-col" ),

				[nameof( ListboxSlots.List )] = ElementClass.Empty()
					.Add( "w-full" )
					.Add( "gap-0.5" )
					.Add( "flex" )
					.Add( "flex-col" ),

				[nameof( ListboxSlots.EmptyContent )] = ElementClass.Empty()
					.Add( "w-full" )
					.Add( "h-10" )
					.Add( "px-2" )
					.Add( "py-1.5" )
					.Add( "text-start" )
					.Add( "text-foreground-400" )
			}
		} );
	}
}

[ExcludeFromCodeCoverage]
internal static class ListboxItem
{
	private static ComponentVariant? _variant;

	public static ComponentVariant Style( TwMerge twMerge )
	{
		var twVariants = new TwVariants( twMerge );

		return _variant ??= twVariants.Create( new VariantConfig()
		{
			Slots = new SlotCollection
			{
				[nameof( ListboxItemSlots.Base )] = ElementClass.Empty()
					.Add( "relative" )
					.Add( "group" )
					.Add( "w-full" )
					.Add( "h-full" )
					.Add( "px-2" )
					.Add( "py-1.5" )
					.Add( "gap-2" )
					.Add( "flex" )
					.Add( "items-center" )
					.Add( "justify-between" )
					.Add( "rounded-small" )
					.Add( "cursor-pointer" )
					// transition
					.Add( "hover:transition-colors-shadow" )
					// focus ring
					.Add( Utils.FocusVisible ),

				[nameof( ListboxItemSlots.Wrapper )] = ElementClass.Empty()
					.Add( "w-full" )
					.Add( "flex" )
					.Add( "flex-col" )
					.Add( "items-start" )
					.Add( "justify-center" ),

				[nameof( ListboxItemSlots.Title )] = ElementClass.Empty()
					.Add( "flex-1" )
					.Add( "text-small" )
					.Add( "truncate" ),

				[nameof( ListboxItemSlots.Description )] = ElementClass.Empty()
					.Add( "w-full" )
					.Add( "text-tiny" )
					.Add( "text-foreground-500" )
					.Add( "group-hover:text-current" ),

				[nameof( ListboxItemSlots.SelectedIcon )] = ElementClass.Empty()
					.Add( "w-3" )
					.Add( "h-3" )
					.Add( "flex-shrink-0" )
					.Add( "text-inherit" ),
			},

			Variants = new VariantCollection
			{
				[nameof( LumexListboxItem<object>.Disabled )] = new VariantValueCollection
				{
					[bool.TrueString] = new SlotCollection
					{
						[nameof( ListboxItemSlots.Base )] = Utils.Disabled
					}
				},

				[nameof( LumexListboxItem<object>.Variant )] = new VariantValueCollection
				{
					[nameof( ListboxVariant.Outlined )] = new SlotCollection
					{
						[nameof( ListboxItemSlots.Base )] = "border-2 border-transparent bg-transparent"
					},
					[nameof( ListboxVariant.Shadow )] = new SlotCollection
					{
						[nameof( ListboxItemSlots.Base )] = "hover:shadow-md"
					},
					[nameof( ListboxVariant.Light )] = new SlotCollection
					{
						[nameof( ListboxItemSlots.Base )] = "bg-transparent"
					},
				}
			},

			CompoundVariants =
			[
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexListboxItem<object>.Variant)] = nameof(ListboxVariant.Solid),
						[nameof(LumexListboxItem<object>.Color)] = nameof(ThemeColor.Default),
					},
					Classes = new SlotCollection
					{
						[nameof(ListboxSlots.Base)] = "hover:bg-default hover:text-default-foreground"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexListboxItem<object>.Variant)] = nameof(ListboxVariant.Solid),
						[nameof(LumexListboxItem<object>.Color)] = nameof(ThemeColor.Primary),
					},
					Classes = new SlotCollection
					{
						[nameof(ListboxSlots.Base)] = "hover:bg-primary hover:text-primary-foreground"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexListboxItem<object>.Variant)] = nameof(ListboxVariant.Solid),
						[nameof(LumexListboxItem<object>.Color)] = nameof(ThemeColor.Secondary),
					},
					Classes = new SlotCollection
					{
						[nameof(ListboxSlots.Base)] = "hover:bg-secondary hover:text-secondary-foreground"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexListboxItem<object>.Variant)] = nameof(ListboxVariant.Solid),
						[nameof(LumexListboxItem<object>.Color)] = nameof(ThemeColor.Success),
					},
					Classes = new SlotCollection
					{
						[nameof(ListboxSlots.Base)] = "hover:bg-success hover:text-success-foreground"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexListboxItem<object>.Variant)] = nameof(ListboxVariant.Solid),
						[nameof(LumexListboxItem<object>.Color)] = nameof(ThemeColor.Warning),
					},
					Classes = new SlotCollection
					{
						[nameof(ListboxSlots.Base)] = "hover:bg-warning hover:text-warning-foreground"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexListboxItem<object>.Variant)] = nameof(ListboxVariant.Solid),
						[nameof(LumexListboxItem<object>.Color)] = nameof(ThemeColor.Danger),
					},
					Classes = new SlotCollection
					{
						[nameof(ListboxSlots.Base)] = "hover:bg-danger hover:text-danger-foreground"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexListboxItem<object>.Variant)] = nameof(ListboxVariant.Solid),
						[nameof(LumexListboxItem<object>.Color)] = nameof(ThemeColor.Info),
					},
					Classes = new SlotCollection
					{
						[nameof(ListboxSlots.Base)] = "hover:bg-info hover:text-info-foreground"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexListboxItem<object>.Variant)] = nameof(ListboxVariant.Outlined),
						[nameof(LumexListboxItem<object>.Color)] = nameof(ThemeColor.Default),
					},
					Classes = new SlotCollection
					{
						[nameof(ListboxSlots.Base)] = "hover:border-default"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexListboxItem<object>.Variant)] = nameof(ListboxVariant.Outlined),
						[nameof(LumexListboxItem<object>.Color)] = nameof(ThemeColor.Primary),
					},
					Classes = new SlotCollection
					{
						[nameof(ListboxSlots.Base)] = "hover:border-primary hover:text-primary"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexListboxItem<object>.Variant)] = nameof(ListboxVariant.Outlined),
						[nameof(LumexListboxItem<object>.Color)] = nameof(ThemeColor.Secondary),
					},
					Classes = new SlotCollection
					{
						[nameof(ListboxSlots.Base)] = "hover:border-secondary hover:text-secondary"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexListboxItem<object>.Variant)] = nameof(ListboxVariant.Outlined),
						[nameof(LumexListboxItem<object>.Color)] = nameof(ThemeColor.Success),
					},
					Classes = new SlotCollection
					{
						[nameof(ListboxSlots.Base)] = "hover:border-success hover:text-success"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexListboxItem<object>.Variant)] = nameof(ListboxVariant.Outlined),
						[nameof(LumexListboxItem<object>.Color)] = nameof(ThemeColor.Warning),
					},
					Classes = new SlotCollection
					{
						[nameof(ListboxSlots.Base)] = "hover:border-warning hover:text-warning"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexListboxItem<object>.Variant)] = nameof(ListboxVariant.Outlined),
						[nameof(LumexListboxItem<object>.Color)] = nameof(ThemeColor.Danger),
					},
					Classes = new SlotCollection
					{
						[nameof(ListboxSlots.Base)] = "hover:border-danger hover:text-danger"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexListboxItem<object>.Variant)] = nameof(ListboxVariant.Outlined),
						[nameof(LumexListboxItem<object>.Color)] = nameof(ThemeColor.Info),
					},
					Classes = new SlotCollection
					{
						[nameof(ListboxSlots.Base)] = "hover:border-info hover:text-info"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexListboxItem<object>.Variant)] = nameof(ListboxVariant.Flat),
						[nameof(LumexListboxItem<object>.Color)] = nameof(ThemeColor.Default),
					},
					Classes = new SlotCollection
					{
						[nameof(ListboxSlots.Base)] = "hover:bg-default/40 hover:text-default-foreground"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexListboxItem<object>.Variant)] = nameof(ListboxVariant.Flat),
						[nameof(LumexListboxItem<object>.Color)] = nameof(ThemeColor.Primary),
					},
					Classes = new SlotCollection
					{
						[nameof(ListboxSlots.Base)] = "hover:bg-primary/20 hover:text-primary-600"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexListboxItem<object>.Variant)] = nameof(ListboxVariant.Flat),
						[nameof(LumexListboxItem<object>.Color)] = nameof(ThemeColor.Secondary),
					},
					Classes = new SlotCollection
					{
						[nameof(ListboxSlots.Base)] = "hover:bg-secondary/20 hover:text-secondary-600"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexListboxItem<object>.Variant)] = nameof(ListboxVariant.Flat),
						[nameof(LumexListboxItem<object>.Color)] = nameof(ThemeColor.Success),
					},
					Classes = new SlotCollection
					{
						[nameof(ListboxSlots.Base)] = "hover:bg-success/20 hover:text-success-800 dark:hover:text-success-600"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexListboxItem<object>.Variant)] = nameof(ListboxVariant.Flat),
						[nameof(LumexListboxItem<object>.Color)] = nameof(ThemeColor.Warning),
					},
					Classes = new SlotCollection
					{
						[nameof(ListboxSlots.Base)] = "hover:bg-warning/20 hover:text-warning-800 dark:hover:text-warning-700"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexListboxItem<object>.Variant)] = nameof(ListboxVariant.Flat),
						[nameof(LumexListboxItem<object>.Color)] = nameof(ThemeColor.Danger),
					},
					Classes = new SlotCollection
					{
						[nameof(ListboxSlots.Base)] = "hover:bg-danger/20 hover:text-danger-600"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexListboxItem<object>.Variant)] = nameof(ListboxVariant.Flat),
						[nameof(LumexListboxItem<object>.Color)] = nameof(ThemeColor.Info),
					},
					Classes = new SlotCollection
					{
						[nameof(ListboxSlots.Base)] = "hover:bg-info/20 hover:text-info-600"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexListboxItem<object>.Variant)] = nameof(ListboxVariant.Shadow),
						[nameof(LumexListboxItem<object>.Color)] = nameof(ThemeColor.Default),
					},
					Classes = new SlotCollection
					{
						[nameof(ListboxSlots.Base)] = "hover:shadow-default/40 hover:bg-default hover:text-default-foreground"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexListboxItem<object>.Variant)] = nameof(ListboxVariant.Shadow),
						[nameof(LumexListboxItem<object>.Color)] = nameof(ThemeColor.Primary),
					},
					Classes = new SlotCollection
					{
						[nameof(ListboxSlots.Base)] = "hover:shadow-primary/40 hover:bg-primary hover:text-primary-foreground"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexListboxItem<object>.Variant)] = nameof(ListboxVariant.Shadow),
						[nameof(LumexListboxItem<object>.Color)] = nameof(ThemeColor.Secondary),
					},
					Classes = new SlotCollection
					{
						[nameof(ListboxSlots.Base)] = "hover:shadow-secondary/40 hover:bg-secondary hover:text-secondary-foreground"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexListboxItem<object>.Variant)] = nameof(ListboxVariant.Shadow),
						[nameof(LumexListboxItem<object>.Color)] = nameof(ThemeColor.Success),
					},
					Classes = new SlotCollection
					{
						[nameof(ListboxSlots.Base)] = "hover:shadow-success/40 hover:bg-success hover:text-success-foreground"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexListboxItem<object>.Variant)] = nameof(ListboxVariant.Shadow),
						[nameof(LumexListboxItem<object>.Color)] = nameof(ThemeColor.Warning),
					},
					Classes = new SlotCollection
					{
						[nameof(ListboxSlots.Base)] = "hover:shadow-warning/40 hover:bg-warning hover:text-warning-foreground"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexListboxItem<object>.Variant)] = nameof(ListboxVariant.Shadow),
						[nameof(LumexListboxItem<object>.Color)] = nameof(ThemeColor.Danger),
					},
					Classes = new SlotCollection
					{
						[nameof(ListboxSlots.Base)] = "hover:shadow-danger/40 hover:bg-danger hover:text-danger-foreground"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexListboxItem<object>.Variant)] = nameof(ListboxVariant.Shadow),
						[nameof(LumexListboxItem<object>.Color)] = nameof(ThemeColor.Info),
					},
					Classes = new SlotCollection
					{
						[nameof(ListboxSlots.Base)] = "hover:shadow-info/40 hover:bg-info hover:text-info-foreground"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexListboxItem<object>.Variant)] = nameof(ListboxVariant.Light),
						[nameof(LumexListboxItem<object>.Color)] = nameof(ThemeColor.Default),
					},
					Classes = new SlotCollection
					{
						[nameof(ListboxSlots.Base)] = "hover:text-default-500"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexListboxItem<object>.Variant)] = nameof(ListboxVariant.Light),
						[nameof(LumexListboxItem<object>.Color)] = nameof(ThemeColor.Primary),
					},
					Classes = new SlotCollection
					{
						[nameof(ListboxSlots.Base)] = "hover:text-primary"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexListboxItem<object>.Variant)] = nameof(ListboxVariant.Light),
						[nameof(LumexListboxItem<object>.Color)] = nameof(ThemeColor.Secondary),
					},
					Classes = new SlotCollection
					{
						[nameof(ListboxSlots.Base)] = "hover:text-secondary"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexListboxItem<object>.Variant)] = nameof(ListboxVariant.Light),
						[nameof(LumexListboxItem<object>.Color)] = nameof(ThemeColor.Success),
					},
					Classes = new SlotCollection
					{
						[nameof(ListboxSlots.Base)] = "hover:text-success"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexListboxItem<object>.Variant)] = nameof(ListboxVariant.Light),
						[nameof(LumexListboxItem<object>.Color)] = nameof(ThemeColor.Warning),
					},
					Classes = new SlotCollection
					{
						[nameof(ListboxSlots.Base)] = "hover:text-warning"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexListboxItem<object>.Variant)] = nameof(ListboxVariant.Light),
						[nameof(LumexListboxItem<object>.Color)] = nameof(ThemeColor.Danger),
					},
					Classes = new SlotCollection
					{
						[nameof(ListboxSlots.Base)] = "hover:text-danger"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexListboxItem<object>.Variant)] = nameof(ListboxVariant.Light),
						[nameof(LumexListboxItem<object>.Color)] = nameof(ThemeColor.Info),
					},
					Classes = new SlotCollection
					{
						[nameof(ListboxSlots.Base)] = "hover:text-info"
					}
				}
			]
		} );
	}
}