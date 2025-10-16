// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;
using LumexUI.Styles;

using TailwindVariants.NET;

namespace LumexUI;

public partial class LumexButton
{
	private static readonly TvDescriptor<LumexButton, Slots> _descriptor = new
	(
		@base:
		[
			"inline-flex",
			"items-center",
			"justify-center",
			"min-w-max",
			"font-normal",
			"appearance-none",
			"select-none",
			"whitespace-nowrap",
			"subpixel-antialiased",
			"overflow-hidden",
			"cursor-pointer",
			"active:scale-[0.97]",
			"transition-colors-transform-opacity",
			"motion-reduce:transition-none",
			Utils.FocusVisible
		],
		variants: new()
		{
			[c => c.Size] = new Variant<Size, Slots>
			{
				[Size.Small] = "min-w-16 h-8 px-3 gap-2 text-tiny rounded-small",
				[Size.Medium] = "min-w-20 h-10 px-4 gap-2 text-small rounded-medium",
				[Size.Large] = "min-w-24 h-12 px-6 gap-2 text-medium rounded-large",
			},

			[c => c.Radius] = new Variant<Radius, Slots>
			{
				[Radius.None] = "rounded-none",
				[Radius.Small] = "rounded-small",
				[Radius.Medium] = "rounded-medium",
				[Radius.Large] = "rounded-large",
				[Radius.Full] = "rounded-full",
			},

			[c => c.Variant] = new Variant<Variant, Slots>
			{
				[Variant.Outlined] = "border-2 bg-transparent hover:opacity-hover",
				[Variant.Ghost] = "border-2 bg-transparent",
				[Variant.Light] = "bg-transparent",
				[Variant.Solid] = "hover:opacity-hover",
				[Variant.Flat] = "hover:opacity-hover",
				[Variant.Shadow] = "hover:opacity-hover",
			},

			[c => c.IconOnly] = new Variant<bool, Slots>
			{
				[true] = "px-0 !gap-0",
				[false] = "[&>svg]:max-w-8",
			},

			[c => c.Disabled] = new Variant<bool, Slots>
			{
				[true] = Utils.Disabled,
			},

			[c => c.FullWidth] = new Variant<bool, Slots>
			{
				[true] = "w-full",
			},
		},

		compoundVariants:
		[
			// Solid
			new( c => c.Variant is Variant.Solid && c.Color is ThemeColor.Default )
			{
				Class = ColorVariants.Solid[ThemeColor.Default]
			},
			new( c => c.Variant is Variant.Solid && c.Color is ThemeColor.Primary )
			{
				Class = ColorVariants.Solid[ThemeColor.Primary]
			},
			new( c => c.Variant is Variant.Solid && c.Color is ThemeColor.Secondary )
			{
				Class = ColorVariants.Solid[ThemeColor.Secondary]
			},
			new( c => c.Variant is Variant.Solid && c.Color is ThemeColor.Success )
			{
				Class = ColorVariants.Solid[ThemeColor.Success]
			},
			new( c => c.Variant is Variant.Solid && c.Color is ThemeColor.Warning )
			{
				Class = ColorVariants.Solid[ThemeColor.Warning] },
			new( c => c.Variant is Variant.Solid && c.Color is ThemeColor.Danger )
			{
				Class = ColorVariants.Solid[ThemeColor.Danger]
			},
			new( c => c.Variant is Variant.Solid && c.Color is ThemeColor.Info )
			{
				Class = ColorVariants.Solid[ThemeColor.Info]
			},

			// Outlined
			new( c => c.Variant is Variant.Outlined && c.Color is ThemeColor.Default )
			{
				Class = ColorVariants.Outlined[ThemeColor.Default]
			},
			new( c => c.Variant is Variant.Outlined && c.Color is ThemeColor.Primary )
			{
				Class = ColorVariants.Outlined[ThemeColor.Primary]
			},
			new( c => c.Variant is Variant.Outlined && c.Color is ThemeColor.Secondary )
			{
				Class = ColorVariants.Outlined[ThemeColor.Secondary]
			},
			new( c => c.Variant is Variant.Outlined && c.Color is ThemeColor.Success )
			{
				Class = ColorVariants.Outlined[ThemeColor.Success]
			},
			new( c => c.Variant is Variant.Outlined && c.Color is ThemeColor.Warning )
			{
				Class = ColorVariants.Outlined[ThemeColor.Warning]
			},
			new( c => c.Variant is Variant.Outlined && c.Color is ThemeColor.Danger )
			{
				Class = ColorVariants.Outlined[ThemeColor.Danger]
			},
			new( c => c.Variant is Variant.Outlined && c.Color is ThemeColor.Info )
			{
				Class = ColorVariants.Outlined[ThemeColor.Info]
			},

			// Flat
			new( c => c.Variant is Variant.Flat && c.Color is ThemeColor.Default )
			{
				Class = ColorVariants.Flat[ThemeColor.Default]
			},
			new( c => c.Variant is Variant.Flat && c.Color is ThemeColor.Primary )
			{
				Class = ColorVariants.Flat[ThemeColor.Primary]
			},
			new( c => c.Variant is Variant.Flat && c.Color is ThemeColor.Secondary )
			{
				Class = ColorVariants.Flat[ThemeColor.Secondary]
			},
			new( c => c.Variant is Variant.Flat && c.Color is ThemeColor.Success )
			{
				Class = ColorVariants.Flat[ThemeColor.Success]
			},
			new( c => c.Variant is Variant.Flat && c.Color is ThemeColor.Warning )
			{
				Class = ColorVariants.Flat[ThemeColor.Warning]
			},
			new( c => c.Variant is Variant.Flat && c.Color is ThemeColor.Danger )
			{
				Class = ColorVariants.Flat[ThemeColor.Danger]
			},
			new( c => c.Variant is Variant.Flat && c.Color is ThemeColor.Info )
			{
				Class = ColorVariants.Flat[ThemeColor.Info]
			},

			// Shadow
			new( c => c.Variant is Variant.Shadow && c.Color is ThemeColor.Default )
			{
				Class = ColorVariants.Shadow[ThemeColor.Default]
			},
			new( c => c.Variant is Variant.Shadow && c.Color is ThemeColor.Primary )
			{
				Class = ColorVariants.Shadow[ThemeColor.Primary]
			},
			new( c => c.Variant is Variant.Shadow && c.Color is ThemeColor.Secondary )
			{
				Class = ColorVariants.Shadow[ThemeColor.Secondary]
			},
			new( c => c.Variant is Variant.Shadow && c.Color is ThemeColor.Success )
			{
				Class = ColorVariants.Shadow[ThemeColor.Success]
			},
			new( c => c.Variant is Variant.Shadow && c.Color is ThemeColor.Warning )
			{
				Class = ColorVariants.Shadow[ThemeColor.Warning]
			},
			new( c => c.Variant is Variant.Shadow && c.Color is ThemeColor.Danger )
			{
				Class = ColorVariants.Shadow[ThemeColor.Danger]
			},
			new( c => c.Variant is Variant.Shadow && c.Color is ThemeColor.Info )
			{
				Class = ColorVariants.Shadow[ThemeColor.Info]
			},

			// Ghost
			new( c => c.Variant is Variant.Ghost && c.Color is ThemeColor.Default )
			{
				Class = ColorVariants.Ghost[ThemeColor.Default]
			},
			new( c => c.Variant is Variant.Ghost && c.Color is ThemeColor.Primary )
			{
				Class = ColorVariants.Ghost[ThemeColor.Primary]
			},
			new( c => c.Variant is Variant.Ghost && c.Color is ThemeColor.Secondary )
			{
				Class = ColorVariants.Ghost[ThemeColor.Secondary]
			},
			new( c => c.Variant is Variant.Ghost && c.Color is ThemeColor.Success )
			{
				Class = ColorVariants.Ghost[ThemeColor.Success]
			},
			new( c => c.Variant is Variant.Ghost && c.Color is ThemeColor.Warning )
			{
				Class = ColorVariants.Ghost[ThemeColor.Warning]
			},
			new( c => c.Variant is Variant.Ghost && c.Color is ThemeColor.Danger )
			{
				Class = ColorVariants.Ghost[ThemeColor.Danger]
			},
			new( c => c.Variant is Variant.Ghost && c.Color is ThemeColor.Info )
			{
				Class = ColorVariants.Ghost[ThemeColor.Info]
			},

			// Light
			new( c => c.Variant is Variant.Light && c.Color is ThemeColor.Default )
			{
				Class = ColorVariants.Light[ThemeColor.Default]
			},
			new( c => c.Variant is Variant.Light && c.Color is ThemeColor.Primary )
			{
				Class = ColorVariants.Light[ThemeColor.Primary]
			},
			new( c => c.Variant is Variant.Light && c.Color is ThemeColor.Secondary )
			{
				Class= ColorVariants.Light[ThemeColor.Secondary]
			},
			new( c => c.Variant is Variant.Light && c.Color is ThemeColor.Success )
			{
				Class = ColorVariants.Light[ThemeColor.Success]
			},
			new( c => c.Variant is Variant.Light && c.Color is ThemeColor.Warning )
			{
				Class = ColorVariants.Light[ThemeColor.Warning]
			},
			new( c => c.Variant is Variant.Light && c.Color is ThemeColor.Danger )
			{
				Class = ColorVariants.Light[ThemeColor.Danger]
			},
			new( c => c.Variant is Variant.Light && c.Color is ThemeColor.Info )
			{
				Class = ColorVariants.Light[ThemeColor.Info]
			},

			new( c => c.Variant is Variant.Light && c.Color is ThemeColor.Default )
			{
				Class = "hover:bg-default/40"
			},
			new( c => c.Variant is Variant.Light && c.Color is ThemeColor.Primary )
			{
				Class = "hover:bg-primary/20"
			},
			new( c => c.Variant is Variant.Light && c.Color is ThemeColor.Secondary )
			{
				Class = "hover:bg-secondary/20"
			},
			new( c => c.Variant is Variant.Light && c.Color is ThemeColor.Success )
			{
				Class = "hover:bg-success/20"
			},
			new( c => c.Variant is Variant.Light && c.Color is ThemeColor.Warning )
			{
				Class = "hover:bg-warning/20"
			},
			new( c => c.Variant is Variant.Light && c.Color is ThemeColor.Danger )
			{
				Class = "hover:bg-danger/20"
			},
			new( c => c.Variant is Variant.Light && c.Color is ThemeColor.Info )
			{
				Class = "hover:bg-info/20"
			},

			new( c => c.Variant is Variant.Ghost && c.Color is ThemeColor.Default )
			{
				Class = "hover:!bg-default hover:!text-default-foreground"
			},
			new( c => c.Variant is Variant.Ghost && c.Color is ThemeColor.Primary )
			{
				Class = "hover:!bg-primary hover:!text-primary-foreground"
			},
			new( c => c.Variant is Variant.Ghost && c.Color is ThemeColor.Secondary )
			{
				Class = "hover:!bg-secondary hover:!text-secondary-foreground"
			},
			new( c => c.Variant is Variant.Ghost && c.Color is ThemeColor.Success )
			{
				Class = "hover:!bg-success hover:!text-success-foreground"
			},
			new( c => c.Variant is Variant.Ghost && c.Color is ThemeColor.Warning )
			{
				Class = "hover:!bg-warning hover:!text-warning-foreground"
			},
			new( c => c.Variant is Variant.Ghost && c.Color is ThemeColor.Danger )
			{
				Class = "hover:!bg-danger hover:!text-danger-foreground"
			},
			new( c => c.Variant is Variant.Ghost && c.Color is ThemeColor.Info )
			{
				Class = "hover:!bg-info hover:!text-info-foreground"
			},

			new( c => c.IconOnly && c.Size is Size.Small )
			{
				Class = "min-w-8 w-8 h-8"
			},
			new( c => c.IconOnly && c.Size is Size.Medium )
			{
				Class = "min-w-10 w-10 h-10"
			},
			new( c => c.IconOnly && c.Size is Size.Large )
			{
				Class = "min-w-12 w-12 h-12"
			},
		]
	);

	public sealed partial class Slots : ISlots
	{
		public string? Base { get; set; }
	}
}