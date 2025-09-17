// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;
using LumexUI.Utilities;

using TailwindMerge;

namespace LumexUI.Styles;

[ExcludeFromCodeCoverage]
internal static class Button
{
	private static ComponentVariant? _variant;

	public static ComponentVariant Style( TwMerge twMerge )
	{
		var twVariants = new TwVariants( twMerge );

		return _variant ??= twVariants.Create( new VariantConfig()
		{
			Base = ElementClass.Empty()
				.Add( "inline-flex" )
				.Add( "items-center" )
				.Add( "justify-center" )
				.Add( "min-w-max" )
				.Add( "font-normal" )
				.Add( "appearance-none" )
				.Add( "select-none" )
				.Add( "whitespace-nowrap" )
				.Add( "subpixel-antialiased" )
				.Add( "overflow-hidden" )
				.Add( "cursor-pointer" )
				.Add( "active:scale-[0.97]" )
				// transition
				.Add( "transition-colors-transform-opacity" )
				.Add( "motion-reduce:transition-none" )
				// focus ring
				.Add( Utils.FocusVisible ),

			Variants = new VariantCollection
			{
				[nameof( LumexButton.Size )] = new VariantValueCollection
				{
					[nameof( Size.Small )] = new SlotCollection
					{
						[nameof( SlotBase.Base )] = "min-w-16 h-8 px-3 gap-2 text-tiny rounded-small",
					},
					[nameof( Size.Medium )] = new SlotCollection
					{
						[nameof( SlotBase.Base )] = "min-w-20 h-10 px-4 gap-2 text-small rounded-medium",
					},
					[nameof( Size.Large )] = new SlotCollection
					{
						[nameof( SlotBase.Base )] = "min-w-24 h-12 px-6 gap-2 text-medium rounded-large",
					},
				},

				[nameof( LumexButton.Radius )] = new VariantValueCollection
				{
					[nameof( Radius.None )] = new SlotCollection
					{
						[nameof( SlotBase.Base )] = "rounded-none",
					},
					[nameof( Radius.Small )] = new SlotCollection
					{
						[nameof( SlotBase.Base )] = "rounded-small",
					},
					[nameof( Radius.Medium )] = new SlotCollection
					{
						[nameof( SlotBase.Base )] = "rounded-medium",
					},
					[nameof( Radius.Large )] = new SlotCollection
					{
						[nameof( SlotBase.Base )] = "rounded-large",
					},
					[nameof( Radius.Full )] = new SlotCollection
					{
						[nameof( SlotBase.Base )] = "rounded-full",
					},
				},

				[nameof( LumexButton.Variant )] = new VariantValueCollection
				{
					[nameof( Variant.Outlined )] = new SlotCollection
					{
						[nameof( SlotBase.Base )] = "border-2 bg-transparent"
					},
					[nameof( Variant.Ghost )] = new SlotCollection
					{
						[nameof( SlotBase.Base )] = "border-2 bg-transparent"
					},
					[nameof( Variant.Light )] = new SlotCollection
					{
						[nameof( SlotBase.Base )] = "bg-transparent"
					},
				},

				[nameof( LumexButton.FullWidth )] = new VariantValueCollection
				{
					[bool.TrueString] = new SlotCollection
					{
						[nameof( SlotBase.Base )] = "w-full"
					}
				},

				[nameof( LumexButton.Disabled )] = new VariantValueCollection
				{
					[bool.TrueString] = new SlotCollection
					{
						[nameof( SlotBase.Base )] = Utils.Disabled
					}
				},

				[nameof( LumexButton.IconOnly )] = new VariantValueCollection
				{
					[bool.TrueString] = new SlotCollection
					{
						[nameof( SlotBase.Base )] = "px-0 !gap-0"
					},
					[bool.FalseString] = new SlotCollection
					{
						[nameof( SlotBase.Base )] = "[&>svg]:max-w-8"
					}
				}
			},
			CompoundVariants =
			[
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexButton.Variant)] = nameof(Variant.Solid),
						[nameof(LumexButton.Color)] = nameof(ThemeColor.Default)
					},
					Classes = new SlotCollection
					{
						[nameof(SlotBase.Base)] = $"{ColorVariants.Solid[ThemeColor.Default]} hover:opacity-hover"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexButton.Variant)] = nameof(Variant.Solid),
						[nameof(LumexButton.Color)] = nameof(ThemeColor.Primary)
					},
					Classes = new SlotCollection
					{
						[nameof(SlotBase.Base)] = $"{ColorVariants.Solid[ThemeColor.Primary]} hover:opacity-hover"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexButton.Variant)] = nameof(Variant.Solid),
						[nameof(LumexButton.Color)] = nameof(ThemeColor.Secondary)
					},
					Classes = new SlotCollection
					{
						[nameof(SlotBase.Base)] = $"{ColorVariants.Solid[ThemeColor.Secondary]} hover:opacity-hover"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexButton.Variant)] = nameof(Variant.Solid),
						[nameof(LumexButton.Color)] = nameof(ThemeColor.Success)
					},
					Classes = new SlotCollection
					{
						[nameof(SlotBase.Base)] = $"{ColorVariants.Solid[ThemeColor.Success]} hover:opacity-hover"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexButton.Variant)] = nameof(Variant.Solid),
						[nameof(LumexButton.Color)] = nameof(ThemeColor.Warning)
					},
					Classes = new SlotCollection
					{
						[nameof(SlotBase.Base)] = $"{ColorVariants.Solid[ThemeColor.Warning]} hover:opacity-hover"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexButton.Variant)] = nameof(Variant.Solid),
						[nameof(LumexButton.Color)] = nameof(ThemeColor.Danger)
					},
					Classes = new SlotCollection
					{
						[nameof(SlotBase.Base)] = $"{ColorVariants.Solid[ThemeColor.Danger]} hover:opacity-hover"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexButton.Variant)] = nameof(Variant.Solid),
						[nameof(LumexButton.Color)] = nameof(ThemeColor.Info)
					},
					Classes = new SlotCollection
					{
						[nameof(SlotBase.Base)] = $"{ColorVariants.Solid[ThemeColor.Info]} hover:opacity-hover"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexButton.Variant)] = nameof(Variant.Outlined),
						[nameof(LumexButton.Color)] = nameof(ThemeColor.Default)
					},
					Classes = new SlotCollection
					{
						[nameof(SlotBase.Base)] = $"{ColorVariants.Outlined[ThemeColor.Default]} hover:opacity-hover"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexButton.Variant)] = nameof(Variant.Outlined),
						[nameof(LumexButton.Color)] = nameof(ThemeColor.Primary)
					},
					Classes = new SlotCollection
					{
						[nameof(SlotBase.Base)] = $"{ColorVariants.Outlined[ThemeColor.Primary]} hover:opacity-hover"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexButton.Variant)] = nameof(Variant.Outlined),
						[nameof(LumexButton.Color)] = nameof(ThemeColor.Secondary)
					},
					Classes = new SlotCollection
					{
						[nameof(SlotBase.Base)] = $"{ColorVariants.Outlined[ThemeColor.Secondary]} hover:opacity-hover"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexButton.Variant)] = nameof(Variant.Outlined),
						[nameof(LumexButton.Color)] = nameof(ThemeColor.Success)
					},
					Classes = new SlotCollection
					{
						[nameof(SlotBase.Base)] = $"{ColorVariants.Outlined[ThemeColor.Success]} hover:opacity-hover"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexButton.Variant)] = nameof(Variant.Outlined),
						[nameof(LumexButton.Color)] = nameof(ThemeColor.Warning)
					},
					Classes = new SlotCollection
					{
						[nameof(SlotBase.Base)] = $"{ColorVariants.Outlined[ThemeColor.Warning]} hover:opacity-hover"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexButton.Variant)] = nameof(Variant.Outlined),
						[nameof(LumexButton.Color)] = nameof(ThemeColor.Danger)
					},
					Classes = new SlotCollection
					{
						[nameof(SlotBase.Base)] = $"{ColorVariants.Outlined[ThemeColor.Danger]} hover:opacity-hover"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexButton.Variant)] = nameof(Variant.Outlined),
						[nameof(LumexButton.Color)] = nameof(ThemeColor.Info)
					},
					Classes = new SlotCollection
					{
						[nameof(SlotBase.Base)] = $"{ColorVariants.Outlined[ThemeColor.Info]} hover:opacity-hover"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexButton.Variant)] = nameof(Variant.Flat),
						[nameof(LumexButton.Color)] = nameof(ThemeColor.Default)
					},
					Classes = new SlotCollection
					{
						[nameof(SlotBase.Base)] = $"{ColorVariants.Flat[ThemeColor.Default]} hover:opacity-hover"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexButton.Variant)] = nameof(Variant.Flat),
						[nameof(LumexButton.Color)] = nameof(ThemeColor.Primary)
					},
					Classes = new SlotCollection
					{
						[nameof(SlotBase.Base)] = $"{ColorVariants.Flat[ThemeColor.Primary]} hover:opacity-hover"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexButton.Variant)] = nameof(Variant.Flat),
						[nameof(LumexButton.Color)] = nameof(ThemeColor.Secondary)
					},
					Classes = new SlotCollection
					{
						[nameof(SlotBase.Base)] = $"{ColorVariants.Flat[ThemeColor.Secondary]} hover:opacity-hover"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexButton.Variant)] = nameof(Variant.Flat),
						[nameof(LumexButton.Color)] = nameof(ThemeColor.Success)
					},
					Classes = new SlotCollection
					{
						[nameof(SlotBase.Base)] = $"{ColorVariants.Flat[ThemeColor.Success]} hover:opacity-hover"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexButton.Variant)] = nameof(Variant.Flat),
						[nameof(LumexButton.Color)] = nameof(ThemeColor.Warning)
					},
					Classes = new SlotCollection
					{
						[nameof(SlotBase.Base)] = $"{ColorVariants.Flat[ThemeColor.Warning]} hover:opacity-hover"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexButton.Variant)] = nameof(Variant.Flat),
						[nameof(LumexButton.Color)] = nameof(ThemeColor.Danger)
					},
					Classes = new SlotCollection
					{
						[nameof(SlotBase.Base)] = $"{ColorVariants.Flat[ThemeColor.Danger]} hover:opacity-hover"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexButton.Variant)] = nameof(Variant.Flat),
						[nameof(LumexButton.Color)] = nameof(ThemeColor.Info)
					},
					Classes = new SlotCollection
					{
						[nameof(SlotBase.Base)] = $"{ColorVariants.Flat[ThemeColor.Info]} hover:opacity-hover"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexButton.Variant)] = nameof(Variant.Shadow),
						[nameof(LumexButton.Color)] = nameof(ThemeColor.Default)
					},
					Classes = new SlotCollection
					{
						[nameof(SlotBase.Base)] = $"{ColorVariants.Shadow[ThemeColor.Default]} hover:opacity-hover"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexButton.Variant)] = nameof(Variant.Shadow),
						[nameof(LumexButton.Color)] = nameof(ThemeColor.Primary)
					},
					Classes = new SlotCollection
					{
						[nameof(SlotBase.Base)] = $"{ColorVariants.Shadow[ThemeColor.Primary]} hover:opacity-hover"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexButton.Variant)] = nameof(Variant.Shadow),
						[nameof(LumexButton.Color)] = nameof(ThemeColor.Secondary)
					},
					Classes = new SlotCollection
					{
						[nameof(SlotBase.Base)] = $"{ColorVariants.Shadow[ThemeColor.Secondary]} hover:opacity-hover"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexButton.Variant)] = nameof(Variant.Shadow),
						[nameof(LumexButton.Color)] = nameof(ThemeColor.Success)
					},
					Classes = new SlotCollection
					{
						[nameof(SlotBase.Base)] = $"{ColorVariants.Shadow[ThemeColor.Success]} hover:opacity-hover"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexButton.Variant)] = nameof(Variant.Shadow),
						[nameof(LumexButton.Color)] = nameof(ThemeColor.Warning)
					},
					Classes = new SlotCollection
					{
						[nameof(SlotBase.Base)] = $"{ColorVariants.Shadow[ThemeColor.Warning]} hover:opacity-hover"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexButton.Variant)] = nameof(Variant.Shadow),
						[nameof(LumexButton.Color)] = nameof(ThemeColor.Danger)
					},
					Classes = new SlotCollection
					{
						[nameof(SlotBase.Base)] = $"{ColorVariants.Shadow[ThemeColor.Danger]} hover:opacity-hover"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexButton.Variant)] = nameof(Variant.Shadow),
						[nameof(LumexButton.Color)] = nameof(ThemeColor.Info)
					},
					Classes = new SlotCollection
					{
						[nameof(SlotBase.Base)] = $"{ColorVariants.Shadow[ThemeColor.Info]} hover:opacity-hover"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexButton.Variant)] = nameof(Variant.Ghost),
						[nameof(LumexButton.Color)] = nameof(ThemeColor.Default)
					},
					Classes = new SlotCollection
					{
						[nameof(SlotBase.Base)] = $"{ColorVariants.Ghost[ThemeColor.Default]} hover:!bg-default hover:!text-default-foreground"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexButton.Variant)] = nameof(Variant.Ghost),
						[nameof(LumexButton.Color)] = nameof(ThemeColor.Primary)
					},
					Classes = new SlotCollection
					{
						[nameof(SlotBase.Base)] = $"{ColorVariants.Ghost[ThemeColor.Primary]} hover:!bg-primary hover:!text-primary-foreground"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexButton.Variant)] = nameof(Variant.Ghost),
						[nameof(LumexButton.Color)] = nameof(ThemeColor.Secondary)
					},
					Classes = new SlotCollection
					{
						[nameof(SlotBase.Base)] = $"{ColorVariants.Ghost[ThemeColor.Secondary]} hover:!bg-secondary hover:!text-secondary-foreground"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexButton.Variant)] = nameof(Variant.Ghost),
						[nameof(LumexButton.Color)] = nameof(ThemeColor.Success)
					},
					Classes = new SlotCollection
					{
						[nameof(SlotBase.Base)] = $"{ColorVariants.Ghost[ThemeColor.Success]} hover:!bg-success hover:!text-success-foreground"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexButton.Variant)] = nameof(Variant.Ghost),
						[nameof(LumexButton.Color)] = nameof(ThemeColor.Warning)
					},
					Classes = new SlotCollection
					{
						[nameof(SlotBase.Base)] = $"{ColorVariants.Ghost[ThemeColor.Warning]} hover:!bg-warning hover:!text-warning-foreground"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexButton.Variant)] = nameof(Variant.Ghost),
						[nameof(LumexButton.Color)] = nameof(ThemeColor.Danger)
					},
					Classes = new SlotCollection
					{
						[nameof(SlotBase.Base)] = $"{ColorVariants.Ghost[ThemeColor.Danger]} hover:!bg-danger hover:!text-danger-foreground"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexButton.Variant)] = nameof(Variant.Ghost),
						[nameof(LumexButton.Color)] = nameof(ThemeColor.Info)
					},
					Classes = new SlotCollection
					{
						[nameof(SlotBase.Base)] = $"{ColorVariants.Ghost[ThemeColor.Info]} hover:!bg-info hover:!text-info-foreground"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexButton.Variant)] = nameof(Variant.Light),
						[nameof(LumexButton.Color)] = nameof(ThemeColor.Default)
					},
					Classes = new SlotCollection
					{
						[nameof(SlotBase.Base)] = $"{ColorVariants.Light[ThemeColor.Default]} hover:bg-default/40"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexButton.Variant)] = nameof(Variant.Light),
						[nameof(LumexButton.Color)] = nameof(ThemeColor.Primary)
					},
					Classes = new SlotCollection
					{
						[nameof(SlotBase.Base)] = $"{ColorVariants.Light[ThemeColor.Primary]} hover:bg-primary/20"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexButton.Variant)] = nameof(Variant.Light),
						[nameof(LumexButton.Color)] = nameof(ThemeColor.Secondary)
					},
					Classes = new SlotCollection
					{
						[nameof(SlotBase.Base)] = $"{ColorVariants.Light[ThemeColor.Secondary]} hover:bg-secondary/20"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexButton.Variant)] = nameof(Variant.Light),
						[nameof(LumexButton.Color)] = nameof(ThemeColor.Success)
					},
					Classes = new SlotCollection
					{
						[nameof(SlotBase.Base)] = $"{ColorVariants.Light[ThemeColor.Success]} hover:bg-success/20"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexButton.Variant)] = nameof(Variant.Light),
						[nameof(LumexButton.Color)] = nameof(ThemeColor.Warning)
					},
					Classes = new SlotCollection
					{
						[nameof(SlotBase.Base)] = $"{ColorVariants.Light[ThemeColor.Warning]} hover:bg-warning/20"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexButton.Variant)] = nameof(Variant.Light),
						[nameof(LumexButton.Color)] = nameof(ThemeColor.Danger)
					},
					Classes = new SlotCollection
					{
						[nameof(SlotBase.Base)] = $"{ColorVariants.Light[ThemeColor.Danger]} hover:bg-danger/20"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexButton.Variant)] = nameof(Variant.Light),
						[nameof(LumexButton.Color)] = nameof(ThemeColor.Info)
					},
					Classes = new SlotCollection
					{
						[nameof(SlotBase.Base)] = $"{ColorVariants.Light[ThemeColor.Info]} hover:bg-info/20"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexButton.IconOnly)] = bool.TrueString,
						[nameof(LumexButton.Size)] = nameof(Size.Small)
					},
					Classes = new SlotCollection
					{
						[nameof(SlotBase.Base)] = "min-w-8 w-8 h-8"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexButton.IconOnly)] = bool.TrueString,
						[nameof(LumexButton.Size)] = nameof(Size.Medium)
					},
					Classes = new SlotCollection
					{
						[nameof(SlotBase.Base)] = "min-w-10 w-10 h-10"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexButton.IconOnly)] = bool.TrueString,
						[nameof(LumexButton.Size)] = nameof(Size.Large)
					},
					Classes = new SlotCollection
					{
						[nameof(SlotBase.Base)] = "min-w-12 w-12 h-12"
					}
				}
			]
		} );
	}
}
