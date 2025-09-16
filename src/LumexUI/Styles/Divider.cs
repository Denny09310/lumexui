// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;
using LumexUI.Utilities;

using TailwindMerge;

namespace LumexUI.Styles;

[ExcludeFromCodeCoverage]
internal static class Divider
{
	private static ComponentVariant? _variant;

	public static ComponentVariant Style( TwMerge twMerge )
	{
		var twVariants = new TwVariants( twMerge );

		return _variant ??= twVariants.Create( new VariantConfig()
		{
			Base = ElementClass.Empty()
				.Add( "bg-divider" )
				.Add( "border-none" ),

			Variants = new VariantCollection
			{
				[nameof( LumexDivider.Orientation )] = new VariantValueCollection
				{
					[nameof( Orientation.Horizontal )] = new SlotCollection
					{
						[nameof( SlotBase.Base )] = "w-full h-px"
					},
					[nameof( Orientation.Vertical )] = new SlotCollection
					{
						[nameof( SlotBase.Base )] = "h-full w-px"
					}
				}
			}
		} );
	}
}
