// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;

using TailwindVariants.NET;

using TwVariants = TailwindVariants.NET.TwVariants;

namespace LumexUI.Styles;

[ExcludeFromCodeCoverage]
public static partial class Badge
{
	private static readonly TvDescriptor<LumexBadge, Slots> _descriptor = new
	(
		@base: "relative inline-flex shrink-0",
		slots: new()
		{
			[s => s.Badge] =
			[
				"absolute",
				"z-10",
				"flex",
				"flex-wrap",
				"rounded-full",
				"whitespace-nowrap",
				"place-content-center",
				"origin-center",
				"items-center",
				"text-inherit",
				"select-none",
				"scale-100",
				"opacity-100",
				"data-[invisible=true]:scale-0",
				"data-[invisible=true]:opacity-0",
				"transition-transform-opacity",
				"duration-300",
			]
		},
		variants: new()
		{
			[c => c.Size] = new Variant<Size, Slots>
			{
				[Size.Small] = new()
				{
					[s => s.Badge] = "px-1 text-tiny"
				},
				[Size.Medium] = new()
				{
					[s => s.Badge] = "px-1 text-small"
				},
				[Size.Large] = new()
				{
					[s => s.Badge] = "px-1 text-small"
				},
			},
			[c => c.ShowOutline] = new Variant<bool, Slots>
			{
				[true] = new()
				{
					[s => s.Badge] = "border-2 border-background"
				},
				[false] = new()
				{
					[s => s.Badge] = "border-transparent border-0"
				},
			}
		},
		compoundVariants:
		[
			// solid & color
			new(c => c.Variant is BadgeVariant.Solid && c.Color is ThemeColor.Default)
			{
				[s => s.Badge] = ColorVariants.Solid[ThemeColor.Default]
			},
			new(c => c.Variant is BadgeVariant.Solid && c.Color is ThemeColor.Primary)
			{
				[s => s.Badge] = ColorVariants.Solid[ThemeColor.Primary]
			},
			new(c => c.Variant is BadgeVariant.Solid && c.Color is ThemeColor.Secondary)
			{
				[s => s.Badge] = ColorVariants.Solid[ThemeColor.Secondary]
			},
			new(c => c.Variant is BadgeVariant.Solid && c.Color is ThemeColor.Success)
			{
				[s => s.Badge] = ColorVariants.Solid[ThemeColor.Success]
			},
			new(c => c.Variant is BadgeVariant.Solid && c.Color is ThemeColor.Warning)
			{
				[s => s.Badge] = ColorVariants.Solid[ThemeColor.Warning]
			},
			new(c => c.Variant is BadgeVariant.Solid && c.Color is ThemeColor.Danger)
			{
				[s => s.Badge] = ColorVariants.Solid[ThemeColor.Danger]
			},
			new(c => c.Variant is BadgeVariant.Solid && c.Color is ThemeColor.Info)
			{
				[s => s.Badge] = ColorVariants.Solid[ThemeColor.Info]
			},

			// shadow & color
			new(c => c.Variant is BadgeVariant.Shadow && c.Color is ThemeColor.Default)
			{
				[s => s.Badge] = ColorVariants.Shadow[ThemeColor.Default]
			},
			new(c => c.Variant is BadgeVariant.Shadow && c.Color is ThemeColor.Primary)
			{
				[s => s.Badge] = ColorVariants.Shadow[ThemeColor.Primary]
			},
			new(c => c.Variant is BadgeVariant.Shadow && c.Color is ThemeColor.Secondary)
			{
				[s => s.Badge] = ColorVariants.Shadow[ThemeColor.Secondary]
			},
			new(c => c.Variant is BadgeVariant.Shadow && c.Color is ThemeColor.Success)
			{
				[s => s.Badge] = ColorVariants.Shadow[ThemeColor.Success]
			},
			new(c => c.Variant is BadgeVariant.Shadow && c.Color is ThemeColor.Warning)
			{
				[s => s.Badge] = ColorVariants.Shadow[ThemeColor.Warning]
			},
			new(c => c.Variant is BadgeVariant.Shadow && c.Color is ThemeColor.Danger)
			{
				[s => s.Badge] = ColorVariants.Shadow[ThemeColor.Danger]
			},
			new(c => c.Variant is BadgeVariant.Shadow && c.Color is ThemeColor.Info)
			{
				[s => s.Badge] = ColorVariants.Shadow[ThemeColor.Info]
			},

			// flat & color
			new(c => c.Variant is BadgeVariant.Flat && c.Color is ThemeColor.Default)
			{
				[s => s.Badge] = ColorVariants.Flat[ThemeColor.Default]
			},
			new(c => c.Variant is BadgeVariant.Flat && c.Color is ThemeColor.Primary)
			{
				[s => s.Badge] = ColorVariants.Flat[ThemeColor.Primary]
			},
			new(c => c.Variant is BadgeVariant.Flat && c.Color is ThemeColor.Secondary)
			{
				[s => s.Badge] = ColorVariants.Flat[ThemeColor.Secondary]
			},
			new(c => c.Variant is BadgeVariant.Flat && c.Color is ThemeColor.Success)
			{
				[s => s.Badge] = ColorVariants.Flat[ThemeColor.Success]
			},
			new(c => c.Variant is BadgeVariant.Flat && c.Color is ThemeColor.Warning)
			{
				[s => s.Badge] = ColorVariants.Flat[ThemeColor.Warning]
			},
			new(c => c.Variant is BadgeVariant.Flat && c.Color is ThemeColor.Danger)
			{
				[s => s.Badge] = ColorVariants.Flat[ThemeColor.Danger]
			},
			new(c => c.Variant is BadgeVariant.Flat && c.Color is ThemeColor.Info)
			{
				[s => s.Badge] = ColorVariants.Flat[ThemeColor.Info]
			},

			// isOneChar / size
			new(c => c.IsOneChar && c.Size is Size.Small)
			{
				[s => s.Badge] = "w-4 h-4 min-w-4 min-h-4"
			},
			new(c => c.IsOneChar && c.Size is Size.Medium)
			{
				[s => s.Badge] = "w-5 h-5 min-w-5 min-h-5"
			},
			new(c => c.IsOneChar && c.Size is Size.Large)
			{
				[s => s.Badge] = "w-6 h-6 min-w-6 min-h-6"
			},

			// isDot / size
			new(c => c.IsDot && c.Size is Size.Small)
			{
				[s => s.Badge] = "w-3 h-3 min-w-3 min-h-3"
			},
			new(c => c.IsDot && c.Size is Size.Medium)
			{
				[s => s.Badge] = "w-3.5 h-3.5 min-w-3.5 min-h-3.5"
			},
			new(c => c.IsDot && c.Size is Size.Large)
			{
				[s => s.Badge] = "w-4 h-4 min-w-4 min-h-4"
			},

			// placement
			new(c => c.Placement is BadgePlacement.TopStart)
			{
				[s => s.Badge] = "top-[10%] left-[10%] -translate-x-1/2 -translate-y-1/2"
			},
			new(c => c.Placement is BadgePlacement.TopEnd)
			{
				[s => s.Badge] = "top-[10%] right-[10%] translate-x-1/2 -translate-y-1/2"
			},
			new(c => c.Placement is BadgePlacement.BottomStart)
			{
				[s => s.Badge] = "bottom-[10%] left-[10%] -translate-x-1/2 translate-y-1/2"
			},
			new(c => c.Placement is BadgePlacement.BottomEnd)
			{
				[s => s.Badge] = "bottom-[10%] right-[10%] translate-x-1/2 translate-y-1/2"
			},
		]
	);

	public static SlotsMap<Slots> Style( LumexBadge component, TwVariants variants )
	{
		return variants.Invoke( component, _descriptor );
	}

	public sealed partial class Slots : ISlots
	{
		public string? Base { get; set; }
		public string? Badge { get; set; }
	}
}