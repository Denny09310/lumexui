// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;
using LumexUI.Utilities;

using TailwindMerge;

namespace LumexUI.Styles;

[ExcludeFromCodeCoverage]
internal static class Checkbox
{
	private static ComponentVariant? _variant;

	public static ComponentVariant Style( TwMerge twMerge )
	{
		var twVariants = new TwVariants( twMerge );

		return _variant ??= twVariants.Create( new VariantConfig()
		{
			Slots = new SlotCollection
			{
				[nameof( CheckboxSlots.Base )] = ElementClass.Empty()
					.Add( "p-2" )
					.Add( "-m-2" )
					.Add( "group" )
					.Add( "max-w-fit" )
					.Add( "inline-flex" )
					.Add( "items-center" )
					.Add( "justify-start" )
					.Add( "outline-hidden" )
					.Add( "cursor-pointer" ),

				[nameof( CheckboxSlots.Wrapper )] = ElementClass.Empty()
					.Add( "mr-2" )
					.Add( "relative" )
					.Add( "inline-flex" )
					.Add( "items-center" )
					.Add( "justify-center" )
					.Add( "flex-shrink-0" )
					.Add( "overflow-hidden" )
					.Add( "transition-transform" )
					.Add( "motion-reduce:transition-none" )
					.Add( "group-active:scale-95" )
					// before
					.Add( "before:absolute" )
					.Add( "before:inset-0" )
					.Add( "before:border-2" )
					.Add( "before:border-solid" )
					.Add( "before:border-default" )
					.Add( "before:transition-colors" )
					// after
					.Add( "after:absolute" )
					.Add( "after:inset-0" )
					.Add( "after:scale-50" )
					.Add( "after:opacity-0" )
					.Add( "after:origin-center" )
					.Add( "after:transition[transform,opacity]" )
					.Add( "after:!duration-200" )
					.Add( "group-data-[checked=true]:after:scale-100" )
					.Add( "group-data-[checked=true]:after:opacity-100" )
					// hover
					.Add( "group-hover:before:bg-default-100" )
					// focus ring
					.Add( Utils.GroupFocusVisible ),

				[nameof( CheckboxSlots.Icon )] = ElementClass.Empty()
					.Add( "contents" )
					.Add( "*:z-10" )
					.Add( "*:opacity-0" )
					.Add( "*:transition-opacity" )
					.Add( "*:motion-reduce:transition-none" )
					.Add( "*:group-data-[checked=true]:opacity-100" ),

				[nameof( CheckboxSlots.Label )] = ElementClass.Empty()
					.Add( "text-foreground" )
					.Add( "select-none" )
					.Add( "transition-colors-opacity" )
					.Add( "motion-reduce:transition-none" )
			},

			Variants = new VariantCollection
			{
				[nameof( LumexCheckbox.Disabled )] = new VariantValueCollection
				{
					[bool.TrueString] = new SlotCollection
					{
						[nameof( CheckboxSlots.Base )] = Utils.Disabled
					}
				},

				[nameof( LumexCheckbox.Radius )] = new VariantValueCollection
				{
					[nameof( Radius.None )] = new SlotCollection
					{
						[nameof( CheckboxSlots.Wrapper )] = "rounded-none before:rounded-none after:rounded-none"
					},
					[nameof( Radius.Small )] = new SlotCollection
					{
						[nameof( CheckboxSlots.Wrapper )] = ElementClass.Empty()
							.Add( "rounded-[calc(var(--radius-small)*0.5)]" )
							.Add( "before:rounded-[calc(var(--radius-small)*0.5)]" )
							.Add( "after:rounded-[calc(var(--radius-small)*0.5)]" )
					},
					[nameof( Radius.Medium )] = new SlotCollection
					{
						[nameof( CheckboxSlots.Wrapper )] = ElementClass.Empty()
							.Add( "rounded-[calc(var(--radius-medium)*0.5)]" )
							.Add( "before:rounded-[calc(var(--radius-medium)*0.5)]" )
							.Add( "after:rounded-[calc(var(--radius-medium)*0.5)]" )
					},
					[nameof( Radius.Large )] = new SlotCollection
					{
						[nameof( CheckboxSlots.Wrapper )] = ElementClass.Empty()
							.Add( "rounded-[calc(var(--radius-large)*0.5)]" )
							.Add( "before:rounded-[calc(var(--radius-large)*0.5)]" )
							.Add( "after:rounded-[calc(var(--radius-large)*0.5)]" ),
					}
				},

				[nameof( LumexCheckbox.Size )] = new VariantValueCollection
				{
					[nameof( Size.Small )] = new SlotCollection
					{
						[nameof( CheckboxSlots.Wrapper )] = "w-4 h-4",
						[nameof( CheckboxSlots.Icon )] = "*:w-3 *:h-2",
						[nameof( CheckboxSlots.Label )] = "text-small",
					},
					[nameof( Size.Medium )] = new SlotCollection
					{
						[nameof( CheckboxSlots.Wrapper )] = "w-5 h-5",
						[nameof( CheckboxSlots.Icon )] = "*:w-4 *:h-3",
						[nameof( CheckboxSlots.Label )] = "text-medium",
					},
					[nameof( Size.Large )] = new SlotCollection
					{
						[nameof( CheckboxSlots.Wrapper )] = "w-6 h-6",
						[nameof( CheckboxSlots.Icon )] = "*:w-5 *:h-4",
						[nameof( CheckboxSlots.Label )] = "text-large",
					},
				},

				[nameof( LumexCheckbox.Color )] = new VariantValueCollection
				{
					[nameof( ThemeColor.Default )] = new SlotCollection
					{
						[nameof( CheckboxSlots.Wrapper )] = "after:bg-default text-default-foreground"
					},
					[nameof( ThemeColor.Primary )] = new SlotCollection
					{
						[nameof( CheckboxSlots.Wrapper )] = "after:bg-primary text-primary-foreground"
					},
					[nameof( ThemeColor.Secondary )] = new SlotCollection
					{
						[nameof( CheckboxSlots.Wrapper )] = "after:bg-secondary text-secondary-foreground"
					},
					[nameof( ThemeColor.Success )] = new SlotCollection
					{
						[nameof( CheckboxSlots.Wrapper )] = "after:bg-success text-success-foreground"
					},
					[nameof( ThemeColor.Warning )] = new SlotCollection
					{
						[nameof( CheckboxSlots.Wrapper )] = "after:bg-warning text-warning-foreground"
					},
					[nameof( ThemeColor.Danger )] = new SlotCollection
					{
						[nameof( CheckboxSlots.Wrapper )] = "after:bg-danger text-danger-foreground"
					},
					[nameof( ThemeColor.Info )] = new SlotCollection
					{
						[nameof( CheckboxSlots.Wrapper )] = "after:bg-info text-info-foreground"
					}
				}
			},
		} );
	}
}

[ExcludeFromCodeCoverage]
internal static class CheckboxGroup
{
	private static ComponentVariant? _variant;

	public static ComponentVariant Style( TwMerge twMerge )
	{
		var twVariants = new TwVariants( twMerge );

		return _variant ??= twVariants.Create( new VariantConfig()
		{
			Slots = new SlotCollection
			{
				[nameof( CheckboxGroupSlots.Base )] = "flex flex-col gap-2",
				[nameof( CheckboxGroupSlots.Label )] = "text-medium text-foreground-500",
				[nameof( CheckboxGroupSlots.Wrapper )] = "flex flex-col flex-wrap gap-2",
				[nameof( CheckboxGroupSlots.Description )] = "text-small text-foreground-400"
			}
		} );
	}
}
