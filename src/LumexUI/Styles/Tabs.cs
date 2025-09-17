// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;
using LumexUI.Utilities;

using TailwindMerge;

namespace LumexUI.Styles;

[ExcludeFromCodeCoverage]
internal static class Tabs
{
	private static ComponentVariant? _variant;

	public static ComponentVariant Style( TwMerge twMerge )
	{
		var twVariants = new TwVariants( twMerge );

		return _variant ??= twVariants.Create( new VariantConfig()
		{
			Slots = new SlotCollection
			{
				[nameof( TabsSlots.Base )] = ElementClass.Empty()
					.Add( "inline-flex" ),

				[nameof( TabsSlots.TabList )] = ElementClass.Empty()
					.Add( "flex" )
					.Add( "h-fit" )
					.Add( "p-1" )
					.Add( "gap-2" )
					.Add( "items-center" )
					.Add( "flex-nowrap" )
					.Add( "overflow-x-scroll" )
					.Add( "scrollbar-hide" )
					.Add( "bg-default-100" ),

				[nameof( TabsSlots.Tab )] = ElementClass.Empty()
					.Add( "z-0" )
					.Add( "group" )
					.Add( "relative" )
					.Add( "w-full" )
					.Add( "flex" )
					.Add( "px-3" )
					.Add( "py-1" )
					.Add( "justify-center" )
					.Add( "items-center" )
					.Add( "cursor-pointer" )
					.Add( "data-[disabled=true]:!opacity-disabled" )
					.Add( "data-[disabled=true]:cursor-not-allowed" )
					.Add( "data-[selected=false]:hover:opacity-hover" )
					// transition
					.Add( "transition-opacity" )
					// focus ring
					.Add( Utils.FocusVisible ),

				[nameof( TabsSlots.TabContent )] = ElementClass.Empty()
					.Add( "z-10" )
					.Add( "relative" )
					.Add( "text-inherit" )
					.Add( "whitespace-nowrap" )
					.Add( "text-default-500" )
					.Add( "group-data-[selected=true]:text-foreground" )
					// transition
					.Add( "transition-colors" ),

				[nameof( TabsSlots.TabPanel )] = ElementClass.Empty()
					.Add( "px-1" )
					.Add( "py-3" )
					// focus ring
					.Add( Utils.FocusVisible ),

				[nameof( TabsSlots.Cursor )] = ElementClass.Empty()
					.Add( "z-0" )
					.Add( "absolute" )
					.Add( "bg-white" )
			},

			Variants = new VariantCollection
			{
				[nameof( LumexTabs.FullWidth )] = new VariantValueCollection
				{
					[bool.TrueString] = new SlotCollection
					{
						[nameof( TabsSlots.Base )] = "w-full",
						[nameof( TabsSlots.TabList )] = "w-full",
					}
				},

				[nameof( LumexTabs.Disabled )] = new VariantValueCollection
				{
					[bool.TrueString] = new SlotCollection
					{
						[nameof( TabsSlots.TabList )] = Utils.Disabled,
					}
				},

				[nameof( LumexTabs.Size )] = new VariantValueCollection
				{
					[nameof( Size.Small )] = new SlotCollection
					{
						[nameof( TabsSlots.TabList )] = "rounded-medium",
						[nameof( TabsSlots.Tab )] = "h-7 text-tiny rounded-small",
						[nameof( TabsSlots.Cursor )] = "rounded-small",
					},
					[nameof( Size.Medium )] = new SlotCollection
					{
						[nameof( TabsSlots.TabList )] = "rounded-medium",
						[nameof( TabsSlots.Tab )] = "h-8 text-small rounded-small",
						[nameof( TabsSlots.Cursor )] = "rounded-small",
					},
					[nameof( Size.Large )] = new SlotCollection
					{
						[nameof( TabsSlots.TabList )] = "rounded-large",
						[nameof( TabsSlots.Tab )] = "h-9 text-medium rounded-medium",
						[nameof( TabsSlots.Cursor )] = "rounded-medium",
					},
				},

				[nameof( LumexTabs.Variant )] = new VariantValueCollection
				{
					[nameof( TabVariant.Solid )] = new SlotCollection
					{
						[nameof( TabsSlots.Cursor )] = "inset-0"
					},
					[nameof( TabVariant.Outlined )] = new SlotCollection
					{
						[nameof( TabsSlots.TabList )] = "bg-transparent border-2 border-default-200 shadow-xs",
						[nameof( TabsSlots.Cursor )] = "inset-0"
					},
					[nameof( TabVariant.Underlined )] = new SlotCollection
					{
						[nameof( TabsSlots.TabList )] = "bg-transparent",
						[nameof( TabsSlots.Cursor )] = "h-[2px] w-[80%] bottom-0 shadow-[0_1px_0px_0_rgba(0,0,0,0.05)]"
					},
					[nameof( TabVariant.Light )] = new SlotCollection
					{
						[nameof( TabsSlots.TabList )] = "bg-transparent",
						[nameof( TabsSlots.Cursor )] = "inset-0"
					},
				},

				[nameof( LumexTabs.Radius )] = new VariantValueCollection
				{
					[nameof( Radius.None )] = new SlotCollection
					{
						[nameof( TabsSlots.TabList )] = "rounded-none",
						[nameof( TabsSlots.Tab )] = "rounded-none",
						[nameof( TabsSlots.Cursor )] = "rounded-none",
					},
					[nameof( Radius.Small )] = new SlotCollection
					{
						[nameof( TabsSlots.TabList )] = "rounded-small",
						[nameof( TabsSlots.Tab )] = "rounded-small",
						[nameof( TabsSlots.Cursor )] = "rounded-small",
					},
					[nameof( Radius.Medium )] = new SlotCollection
					{
						[nameof( TabsSlots.TabList )] = "rounded-medium",
						[nameof( TabsSlots.Tab )] = "rounded-medium",
						[nameof( TabsSlots.Cursor )] = "rounded-medium",
					},
					[nameof( Radius.Large )] = new SlotCollection
					{
						[nameof( TabsSlots.TabList )] = "rounded-large",
						[nameof( TabsSlots.Tab )] = "rounded-large",
						[nameof( TabsSlots.Cursor )] = "rounded-large",
					},
					[nameof( Radius.Full )] = new SlotCollection
					{
						[nameof( TabsSlots.TabList )] = "rounded-full",
						[nameof( TabsSlots.Tab )] = "rounded-full",
						[nameof( TabsSlots.Cursor )] = "rounded-full",
					}
				}
			},

			CompoundVariants =
			[
				// Solid
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexTabs.Variant)] = nameof(TabVariant.Solid),
						[nameof(LumexTabs.Color)] = nameof(ThemeColor.Default),
					},
					Classes = new SlotCollection
					{
						[nameof(TabsSlots.Cursor)] = "bg-background dark:bg-default shadow-small",
						[nameof(TabsSlots.TabContent)] = "group-data-[selected=true]:text-default-foreground",
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexTabs.Variant)] = nameof(TabVariant.Solid),
						[nameof(LumexTabs.Color)] = nameof(ThemeColor.Primary),
					},
					Classes = new SlotCollection
					{
						[nameof(TabsSlots.Cursor)] = ColorVariants.Solid[ThemeColor.Primary],
						[nameof(TabsSlots.TabContent)] = "group-data-[selected=true]:text-primary-foreground",
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexTabs.Variant)] = nameof(TabVariant.Solid),
						[nameof(LumexTabs.Color)] = nameof(ThemeColor.Secondary),
					},
					Classes = new SlotCollection
					{
						[nameof(TabsSlots.Cursor)] = ColorVariants.Solid[ThemeColor.Secondary],
						[nameof(TabsSlots.TabContent)] = "group-data-[selected=true]:text-secondary-foreground",
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexTabs.Variant)] = nameof(TabVariant.Solid),
						[nameof(LumexTabs.Color)] = nameof(ThemeColor.Success),
					},
					Classes = new SlotCollection
					{
						[nameof(TabsSlots.Cursor)] = ColorVariants.Solid[ThemeColor.Success],
						[nameof(TabsSlots.TabContent)] = "group-data-[selected=true]:text-success-foreground",
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexTabs.Variant)] = nameof(TabVariant.Solid),
						[nameof(LumexTabs.Color)] = nameof(ThemeColor.Warning),
					},
					Classes = new SlotCollection
					{
						[nameof(TabsSlots.Cursor)] = ColorVariants.Solid[ThemeColor.Warning],
						[nameof(TabsSlots.TabContent)] = "group-data-[selected=true]:text-warning-foreground",
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexTabs.Variant)] = nameof(TabVariant.Solid),
						[nameof(LumexTabs.Color)] = nameof(ThemeColor.Danger),
					},
					Classes = new SlotCollection
					{
						[nameof(TabsSlots.Cursor)] = ColorVariants.Solid[ThemeColor.Danger],
						[nameof(TabsSlots.TabContent)] = "group-data-[selected=true]:text-danger-foreground",
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexTabs.Variant)] = nameof(TabVariant.Solid),
						[nameof(LumexTabs.Color)] = nameof(ThemeColor.Info),
					},
					Classes = new SlotCollection
					{
						[nameof(TabsSlots.Cursor)] = ColorVariants.Solid[ThemeColor.Info],
						[nameof(TabsSlots.TabContent)] = "group-data-[selected=true]:text-info-foreground",
					}
				},

				// Outlined
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexTabs.Variant)] = nameof(TabVariant.Outlined),
						[nameof(LumexTabs.Color)] = nameof(ThemeColor.Default),
					},
					Classes = new SlotCollection
					{
						[nameof(TabsSlots.Cursor)] = "bg-background dark:bg-default shadow-small",
						[nameof(TabsSlots.TabContent)] = "group-data-[selected=true]:text-default-foreground",
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexTabs.Variant)] = nameof(TabVariant.Outlined),
						[nameof(LumexTabs.Color)] = nameof(ThemeColor.Primary),
					},
					Classes = new SlotCollection
					{
						[nameof(TabsSlots.Cursor)] = ColorVariants.Solid[ThemeColor.Primary],
						[nameof(TabsSlots.TabContent)] = "group-data-[selected=true]:text-primary-foreground",
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexTabs.Variant)] = nameof(TabVariant.Outlined),
						[nameof(LumexTabs.Color)] = nameof(ThemeColor.Secondary),
					},
					Classes = new SlotCollection
					{
						[nameof(TabsSlots.Cursor)] = ColorVariants.Solid[ThemeColor.Secondary],
						[nameof(TabsSlots.TabContent)] = "group-data-[selected=true]:text-secondary-foreground",
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexTabs.Variant)] = nameof(TabVariant.Outlined),
						[nameof(LumexTabs.Color)] = nameof(ThemeColor.Success),
					},
					Classes = new SlotCollection
					{
						[nameof(TabsSlots.Cursor)] = ColorVariants.Solid[ThemeColor.Success],
						[nameof(TabsSlots.TabContent)] = "group-data-[selected=true]:text-success-foreground",
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexTabs.Variant)] = nameof(TabVariant.Outlined),
						[nameof(LumexTabs.Color)] = nameof(ThemeColor.Warning),
					},
					Classes = new SlotCollection
					{
						[nameof(TabsSlots.Cursor)] = ColorVariants.Solid[ThemeColor.Warning],
						[nameof(TabsSlots.TabContent)] = "group-data-[selected=true]:text-warning-foreground",
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexTabs.Variant)] = nameof(TabVariant.Outlined),
						[nameof(LumexTabs.Color)] = nameof(ThemeColor.Danger),
					},
					Classes = new SlotCollection
					{
						[nameof(TabsSlots.Cursor)] = ColorVariants.Solid[ThemeColor.Danger],
						[nameof(TabsSlots.TabContent)] = "group-data-[selected=true]:text-danger-foreground",
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexTabs.Variant)] = nameof(TabVariant.Outlined),
						[nameof(LumexTabs.Color)] = nameof(ThemeColor.Info),
					},
					Classes = new SlotCollection
					{
						[nameof(TabsSlots.Cursor)] = ColorVariants.Solid[ThemeColor.Info],
						[nameof(TabsSlots.TabContent)] = "group-data-[selected=true]:text-info-foreground",
					}
				},

				// Light
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexTabs.Variant)] = nameof(TabVariant.Light),
						[nameof(LumexTabs.Color)] = nameof(ThemeColor.Default),
					},
					Classes = new SlotCollection
					{
						[nameof(TabsSlots.Cursor)] = "bg-background dark:bg-default shadow-small",
						[nameof(TabsSlots.TabContent)] = "group-data-[selected=true]:text-default-foreground",
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexTabs.Variant)] = nameof(TabVariant.Light),
						[nameof(LumexTabs.Color)] = nameof(ThemeColor.Primary),
					},
					Classes = new SlotCollection
					{
						[nameof(TabsSlots.Cursor)] = ColorVariants.Solid[ThemeColor.Primary],
						[nameof(TabsSlots.TabContent)] = "group-data-[selected=true]:text-primary-foreground",
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexTabs.Variant)] = nameof(TabVariant.Light),
						[nameof(LumexTabs.Color)] = nameof(ThemeColor.Secondary),
					},
					Classes = new SlotCollection
					{
						[nameof(TabsSlots.Cursor)] = ColorVariants.Solid[ThemeColor.Secondary],
						[nameof(TabsSlots.TabContent)] = "group-data-[selected=true]:text-secondary-foreground",
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexTabs.Variant)] = nameof(TabVariant.Light),
						[nameof(LumexTabs.Color)] = nameof(ThemeColor.Success),
					},
					Classes = new SlotCollection
					{
						[nameof(TabsSlots.Cursor)] = ColorVariants.Solid[ThemeColor.Success],
						[nameof(TabsSlots.TabContent)] = "group-data-[selected=true]:text-success-foreground",
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexTabs.Variant)] = nameof(TabVariant.Light),
						[nameof(LumexTabs.Color)] = nameof(ThemeColor.Warning),
					},
					Classes = new SlotCollection
					{
						[nameof(TabsSlots.Cursor)] = ColorVariants.Solid[ThemeColor.Warning],
						[nameof(TabsSlots.TabContent)] = "group-data-[selected=true]:text-warning-foreground",
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexTabs.Variant)] = nameof(TabVariant.Light),
						[nameof(LumexTabs.Color)] = nameof(ThemeColor.Danger),
					},
					Classes = new SlotCollection
					{
						[nameof(TabsSlots.Cursor)] = ColorVariants.Solid[ThemeColor.Danger],
						[nameof(TabsSlots.TabContent)] = "group-data-[selected=true]:text-danger-foreground",
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexTabs.Variant)] = nameof(TabVariant.Light),
						[nameof(LumexTabs.Color)] = nameof(ThemeColor.Info),
					},
					Classes = new SlotCollection
					{
						[nameof(TabsSlots.Cursor)] = ColorVariants.Solid[ThemeColor.Info],
						[nameof(TabsSlots.TabContent)] = "group-data-[selected=true]:text-info-foreground",
					}
				},

				// Underlined
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexTabs.Variant)] = nameof(TabVariant.Underlined),
						[nameof(LumexTabs.Color)] = nameof(ThemeColor.Default),
					},
					Classes = new SlotCollection
					{
						[nameof(TabsSlots.Cursor)] = "bg-foreground",
						[nameof(TabsSlots.TabContent)] = "group-data-[selected=true]:text-foreground",
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexTabs.Variant)] = nameof(TabVariant.Underlined),
						[nameof(LumexTabs.Color)] = nameof(ThemeColor.Primary),
					},
					Classes = new SlotCollection
					{
						[nameof(TabsSlots.Cursor)] = "bg-primary",
						[nameof(TabsSlots.TabContent)] = "group-data-[selected=true]:text-primary",
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexTabs.Variant)] = nameof(TabVariant.Underlined),
						[nameof(LumexTabs.Color)] = nameof(ThemeColor.Secondary),
					},
					Classes = new SlotCollection
					{
						[nameof(TabsSlots.Cursor)] = "bg-secondary",
						[nameof(TabsSlots.TabContent)] = "group-data-[selected=true]:text-secondary",
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexTabs.Variant)] = nameof(TabVariant.Underlined),
						[nameof(LumexTabs.Color)] = nameof(ThemeColor.Success),
					},
					Classes = new SlotCollection
					{
						[nameof(TabsSlots.Cursor)] = "bg-success",
						[nameof(TabsSlots.TabContent)] = "group-data-[selected=true]:text-success",
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexTabs.Variant)] = nameof(TabVariant.Underlined),
						[nameof(LumexTabs.Color)] = nameof(ThemeColor.Warning),
					},
					Classes = new SlotCollection
					{
						[nameof(TabsSlots.Cursor)] = "bg-warning",
						[nameof(TabsSlots.TabContent)] = "group-data-[selected=true]:text-warning",
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexTabs.Variant)] = nameof(TabVariant.Underlined),
						[nameof(LumexTabs.Color)] = nameof(ThemeColor.Danger),
					},
					Classes = new SlotCollection
					{
						[nameof(TabsSlots.Cursor)] = "bg-danger",
						[nameof(TabsSlots.TabContent)] = "group-data-[selected=true]:text-danger",
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexTabs.Variant)] = nameof(TabVariant.Underlined),
						[nameof(LumexTabs.Color)] = nameof(ThemeColor.Info),
					},
					Classes = new SlotCollection
					{
						[nameof(TabsSlots.Cursor)] = "bg-info",
						[nameof(TabsSlots.TabContent)] = "group-data-[selected=true]:text-info",
					}
				}
			]
		} );
	}
}