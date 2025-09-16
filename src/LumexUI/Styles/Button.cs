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
	private static readonly CompoundVariantCollection _themeVariants = [..Enum.GetValues<Variant>()
		.SelectMany( variant => Enum.GetValues<ThemeColor>()
			.Where( color => color != ThemeColor.None )
			.Select( color =>
			{
				var colorClass = GetColorClass( variant, color );
				var hoverClass = GetHoverClass( variant, color );

				var slotCollection = new SlotCollection
				{
					[nameof( SlotBase.Base )] = string.Join( " ",
						new[] { colorClass, hoverClass }.Where( s => !string.IsNullOrWhiteSpace( s ) ) )
				};

				return new CompoundVariant
				{
					Conditions = new()
					{
						[nameof( LumexButton.Variant )] = variant.ToString(),
						[nameof( LumexButton.Color )] = color.ToString()
					},
					Classes = slotCollection
				};
			} ) )
		.Where( cv => !string.IsNullOrEmpty( cv.Classes[nameof( SlotBase.Base )] ) )];

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
						[nameof( SlotBase.Base )] = "opacity-disabled pointer-events-none"
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

			CompoundVariants = [.. _themeVariants, ..new CompoundVariantCollection
			{
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof(LumexButton.IconOnly)] = bool.TrueString,
						[nameof(LumexButton.Size)] = nameof(Size.Small)
					},
					Classes = new SlotCollection
					{
						[nameof(SlotBase.Base)] = "min-w-8 w-8 h-8",
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
						[nameof(SlotBase.Base)] = "min-w-10 w-10 h-10",
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
						[nameof(SlotBase.Base)] = "min-w-12 w-12 h-12",
					}
				},
			}]
		} );
	}

	private static string GetColorClass( Variant variant, ThemeColor color )
	{
		var theme = variant switch
		{
			Variant.Solid => ColorVariants.Solid,
			Variant.Outlined => ColorVariants.Outlined,
			Variant.Flat => ColorVariants.Flat,
			Variant.Shadow => ColorVariants.Shadow,
			Variant.Ghost => ColorVariants.Ghost,
			Variant.Light => ColorVariants.Light,
			_ => []
		};

		return theme.TryGetValue( color, out var classes ) ? classes : "";
	}

	// Moved hover rules into a helper that returns the hover class snippet for a variant/color
	private static string GetHoverClass( Variant variant, ThemeColor color )
	{
		return variant switch
		{
			Variant.Light => color switch
			{
				ThemeColor.Default => "hover:bg-default/40",
				ThemeColor.Primary => "hover:bg-primary/20",
				ThemeColor.Secondary => "hover:bg-secondary/20",
				ThemeColor.Success => "hover:bg-success/20",
				ThemeColor.Warning => "hover:bg-warning/20",
				ThemeColor.Danger => "hover:bg-danger/20",
				ThemeColor.Info => "hover:bg-info/20",
				_ => ""
			},

			Variant.Ghost => color switch
			{
				ThemeColor.Default => "hover:!bg-default hover:!text-default-foreground",
				ThemeColor.Primary => "hover:!bg-primary hover:!text-primary-foreground",
				ThemeColor.Secondary => "hover:!bg-secondary hover:!text-secondary-foreground",
				ThemeColor.Success => "hover:!bg-success hover:!text-success-foreground",
				ThemeColor.Warning => "hover:!bg-warning hover:!text-warning-foreground",
				ThemeColor.Danger => "hover:!bg-danger hover:!text-danger-foreground",
				ThemeColor.Info => "hover:!bg-info hover:!text-info-foreground",
				_ => ""
			},

			_ => "hover:opacity-hover"
		};
	}
}
