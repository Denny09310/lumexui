// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;
using LumexUI.Utilities;

using TailwindMerge;

namespace LumexUI.Styles;

[ExcludeFromCodeCoverage]
internal static class Link
{
	private static ComponentVariant? _variant;

	public static ComponentVariant Style(TwMerge twMerge)
	{
		var twVariants = new TwVariants( twMerge );

		return _variant ??= twVariants.Create( new VariantConfig()
		{
			Base = ElementClass.Empty()
				.Add( "inline-flex" )
				.Add( "items-center" )
				.Add( "hover:opacity-hover" )
				.Add( "active:opacity-60" )
				.Add( "transition-opacity" )
				// active
				.Add( "data-[active=true]:font-semibold" ),

			Variants = new VariantCollection
			{
				[nameof(LumexLink.Disabled)] = new VariantValueCollection
				{
					[bool.TrueString] = new SlotCollection
					{
						[nameof(SlotBase.Base)] = ElementClass.Empty()
							.Add( "opacity-disabled" )
							.Add( "pointer-events-none" )
					}
				},

				[nameof(LumexLink.Color)] = new VariantValueCollection
				{
					[nameof(ThemeColor.Default)] = new SlotCollection
					{
						[nameof(SlotBase.Base)] = "text-default"
					},
					[nameof(ThemeColor.Primary)] = new SlotCollection
					{
						[nameof(SlotBase.Base)] = "text-primary"
					},
					[nameof(ThemeColor.Secondary)] = new SlotCollection
					{
						[nameof(SlotBase.Base)] = "text-secondary"
					},
					[nameof(ThemeColor.Success)] = new SlotCollection
					{
						[nameof(SlotBase.Base)] = "text-success"
					},
					[nameof(ThemeColor.Warning)] = new SlotCollection
					{
						[nameof(SlotBase.Base)] = "text-warning"
					},
					[nameof(ThemeColor.Danger)] = new SlotCollection
					{
						[nameof(SlotBase.Base)] = "text-danger"
					},
					[nameof(ThemeColor.Info)] = new SlotCollection
					{
						[nameof(SlotBase.Base)] = "text-info"
					},
				},

				[nameof(LumexLink.Underline)] = new VariantValueCollection
				{
					[nameof(Underline.None)] = new SlotCollection
					{
						[nameof( SlotBase.Base )] = "no-underline"
					},
					[nameof(Underline.Hover)] = new SlotCollection
					{
						[nameof( SlotBase.Base )] = "hover:underline underline-offset-4"
					},
					[nameof(Underline.Always)] = new SlotCollection
					{
						[nameof( SlotBase.Base )] = "underline underline-offset-4"
					},
				}
			}
		} );
	}
}
