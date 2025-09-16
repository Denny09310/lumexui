using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;
using LumexUI.Utilities;

using TailwindMerge;

namespace LumexUI.Styles;

[ExcludeFromCodeCoverage]
internal static class DataGrid
{
	private static ComponentVariant? _variant;

	public static ComponentVariant Style( TwMerge twMerge )
	{
		var twVariants = new TwVariants( twMerge );

		return _variant ??= twVariants.Create( new VariantConfig()
		{
			Slots = new SlotCollection
			{
				[nameof( DataGridSlots.Base )] = ElementClass.Empty()
					.Add( "relative" )
					.Add( "w-full" )
					.Add( "flex" )
					.Add( "flex-col" )
					.Add( "gap-4" ),

				[nameof( DataGridSlots.Wrapper )] = ElementClass.Empty()
					.Add( "relative" )
					.Add( "p-4" )
					.Add( "flex" )
					.Add( "flex-col" )
					.Add( "justify-between" )
					.Add( "gap-4" )
					.Add( "bg-surface1" )
					.Add( "overflow-auto" ),

				[nameof( DataGridSlots.EmptyWrapper )] = ElementClass.Empty()
					.Add( "h-40" )
					.Add( "align-middle" )
					.Add( "text-small" )
					.Add( "text-center" )
					.Add( "text-foreground-400" ),

				[nameof( DataGridSlots.LoadingWrapper )] = ElementClass.Empty()
					.Add( "absolute" )
					.Add( "inset-0" )
					.Add( "flex" )
					.Add( "items-center" )
					.Add( "justify-center" )
					.Add( "text-small" )
					.Add( "bg-surface1/70" )
					.Add( "backdrop-blur-[2px]" ),

				[nameof( DataGridSlots.Table )] = ElementClass.Empty()
					.Add( "min-w-full" ),

				[nameof( DataGridSlots.Thead )] = ElementClass.Empty()
					.Add( "[&>tr]:first:rounded-lg" ),

				[nameof( DataGridSlots.Tbody )] = ElementClass.Empty(),

				[nameof( DataGridSlots.Tr )] = ElementClass.Empty()
					.Add( "group" )
					// focus
					.Add( Utils.FocusVisible ),

				[nameof( DataGridSlots.Th )] = ElementClass.Empty()
					.Add( "group/th" )
					.Add( "px-3" )
					.Add( "h-10" )
					.Add( "align-middle" )
					.Add( "bg-default-100" )
					.Add( "text-foreground-500" )
					.Add( "text-tiny" )
					.Add( "font-semibold" )
					.Add( "whitespace-nowrap" )
					.Add( "first:rounded-s-lg" )
					.Add( "last:rounded-e-lg" )
					.Add( "hover:text-foreground-400" )
					.Add( "data-[sortable=true]:cursor-pointer" )
					.Add( "data-[align=start]:text-start" )
					.Add( "data-[align=center]:text-center" )
					.Add( "data-[align=end]:text-end" )
					// focus
					.Add( Utils.FocusVisible ),

				[nameof( DataGridSlots.Td )] = ElementClass.Empty()
					.Add( "relative" )
					.Add( "py-2" )
					.Add( "px-3" )
					.Add( "align-middle" )
					.Add( "text-small" )
					.Add( "data-[align=start]:text-start" )
					.Add( "data-[align=center]:text-center" )
					.Add( "data-[align=end]:text-end" )
					// disabled
					.Add( "group-data-[disabled=true]:text-foreground-300" )
					.Add( "group-data-[disabled=true]:cursor-not-allowed" )
					// focus
					.Add( Utils.FocusVisible ),

				[nameof( DataGridSlots.Placeholder )] = ElementClass.Empty()
					.Add( "before:block" )
					.Add( "before:w-3/4" )
					.Add( "before:h-4" )
					.Add( "before:rounded-md" )
					.Add( "before:bg-default-100" ),

				[nameof( DataGridSlots.SortIcon )] = ElementClass.Empty()
					 .Add( "inline-block" )
					 .Add( "ms-2" )
					 .Add( "opacity-0" )
					 .Add( "-rotate-90" )
					 .Add( "transition-transform-opacity" )
					 .Add( "data-[visible=true]:opacity-100" )
					 .Add( "group-hover/th:opacity-100" )
					 .Add( "group-aria-[sort=ascending]/th:rotate-90" ),
			},

			Variants = new VariantCollection
			{
				[nameof( LumexDataGrid<object>.Radius )] = new VariantValueCollection
				{
					[nameof( Radius.None )] = new SlotCollection
					{
						[nameof( DataGridSlots.Wrapper )] = "rounded-none"
					},
					[nameof( Radius.Small )] = new SlotCollection
					{
						[nameof( DataGridSlots.Wrapper )] = "rounded-small"
					},
					[nameof( Radius.Medium )] = new SlotCollection
					{
						[nameof( DataGridSlots.Wrapper )] = "rounded-medium"
					},
					[nameof( Radius.Large )] = new SlotCollection
					{
						[nameof( DataGridSlots.Wrapper )] = "rounded-large"
					},
				},

				[nameof( LumexDataGrid<object>.Shadow )] = new VariantValueCollection
				{
					[nameof( Shadow.None )] = new SlotCollection
					{
						[nameof( DataGridSlots.Wrapper )] = "shadow-none"
					},
					[nameof( Shadow.Small )] = new SlotCollection
					{
						[nameof( DataGridSlots.Wrapper )] = "shadow-small"
					},
					[nameof( Shadow.Medium )] = new SlotCollection
					{
						[nameof( DataGridSlots.Wrapper )] = "shadow-medium"
					},
					[nameof( Shadow.Large )] = new SlotCollection
					{
						[nameof( DataGridSlots.Wrapper )] = "shadow-large"
					},
				},

				[nameof( LumexDataGrid<object>.Layout )] = new VariantValueCollection
				{
					[nameof( Layout.Fixed )] = new SlotCollection
					{
						[nameof( DataGridSlots.Table )] = "table-fixed"
					},
					[nameof( Layout.Auto )] = new SlotCollection
					{
						[nameof( DataGridSlots.Table )] = "table-auto"
					}
				},

				[nameof( LumexDataGrid<object>.Hoverable )] = new VariantValueCollection
				{
					[bool.TrueString] = new SlotCollection
					{
						[nameof( DataGridSlots.Tr )] = ElementClass.Empty()
							.Add( "cursor-default" )
							.Add( "group-aria-[selected=false]:group-data-[disabled=false]:group-hover:bg-default-100/70" ),

						[nameof( DataGridSlots.Td )] = ElementClass.Empty()
							.Add( "group-aria-[selected=false]:group-data-[disabled=false]:group-hover:bg-default-100/70" )
							.Add( "first:rounded-s-lg last:rounded-e-lg" ),
					}
				},

				[nameof( LumexDataGrid<object>.Striped )] = new VariantValueCollection
				{
					[bool.TrueString] = new SlotCollection
					{
						[nameof(DataGridSlots.Td)] = "group-even:bg-default-100",
					}
				},

				[nameof( LumexDataGrid<object>.StickyHeader )] = new VariantValueCollection
				{
					[bool.TrueString] = new SlotCollection
					{
						[nameof( DataGridSlots.Thead )] = "sticky top-0 z-20 [&>tr]:first:shadow-small"
					}
				},

				[nameof( LumexDataGrid<object>.Color )] = new VariantValueCollection
				{
					[nameof( ThemeColor.Default )] = new SlotCollection
					{
						[nameof( DataGridSlots.Td )] = "data-[selected=true]:bg-default/60 data-[selected=true]:text-default-foreground"
					},
					[nameof( ThemeColor.Primary )] = new SlotCollection
					{
						[nameof( DataGridSlots.Td )] = "data-[selected=true]:bg-primary/20 data-[selected=true]:text-primary-600"
					},
					[nameof( ThemeColor.Secondary )] = new SlotCollection
					{
						[nameof( DataGridSlots.Td )] = "data-[selected=true]:bg-secondary/20 data-[selected=true]:text-secondary-600"
					},
					[nameof( ThemeColor.Success )] = new SlotCollection
					{
						[nameof( DataGridSlots.Td )] = "data-[selected=true]:bg-success/20 data-[selected=true]:text-success-800 dark:data-[selected=true]:text-success-600"
					},
					[nameof( ThemeColor.Warning )] = new SlotCollection
					{
						[nameof( DataGridSlots.Td )] = "data-[selected=true]:bg-warning/20 data-[selected=true]:text-warning-800 dark:data-[selected=true]:text-warning-700"
					},
					[nameof( ThemeColor.Danger )] = new SlotCollection
					{
						[nameof( DataGridSlots.Td )] = "data-[selected=true]:bg-danger/20 data-[selected=true]:text-danger-600"
					},
					[nameof( ThemeColor.Info )] = new SlotCollection
					{
						[nameof( DataGridSlots.Td )] = "data-[selected=true]:bg-info/20 data-[selected=true]:text-info-600"
					},
				},

				[nameof( LumexDataGrid<object>.SelectionMode )] = new VariantValueCollection
				{
					[nameof( SelectionMode.None )] = new SlotCollection
					{
						[nameof( DataGridSlots.Td )] = "first:rounded-s-lg last:rounded-e-lg"
					},
					[nameof( SelectionMode.Single )] = new SlotCollection
					{
						[nameof( DataGridSlots.Td )] = "first:rounded-s-lg last:rounded-e-lg"
					},
					[nameof( SelectionMode.Multiple )] = new SlotCollection
					{
						[nameof( DataGridSlots.Td )] = ElementClass.Empty()
							.Add( "group-first:first:rounded-tl-lg" )
							.Add( "group-first:last:rounded-tr-lg" )
							.Add( "first:rounded-none" )
							.Add( "last:rounded-none" )
							.Add( "group-last:first:rounded-bl-lg" )
							.Add( "group-last:last:rounded-br-lg" ),
					}
				},
			},

			CompoundVariants =
			[
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof( LumexDataGrid<object>.Striped )] = bool.TrueString,
						[nameof( LumexDataGrid<object>.Color )] = nameof(ThemeColor.Default)
					},
					Classes = new SlotCollection
					{
						[nameof(DataGridSlots.Td)] = "group-even:data-[selected=true]:bg-default-100"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof( LumexDataGrid<object>.Striped )] = bool.TrueString,
						[nameof( LumexDataGrid<object>.Color )] = nameof(ThemeColor.Primary)
					},
					Classes = new SlotCollection
					{
						[nameof(DataGridSlots.Td)] = "group-even:data-[selected=true]:bg-primary-100"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof( LumexDataGrid<object>.Striped )] = bool.TrueString,
						[nameof( LumexDataGrid<object>.Color )] = nameof(ThemeColor.Secondary)
					},
					Classes = new SlotCollection
					{
						[nameof(DataGridSlots.Td)] = "group-even:data-[selected=true]:bg-secondary-100"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof( LumexDataGrid<object>.Striped )] = bool.TrueString,
						[nameof( LumexDataGrid<object>.Color )] = nameof(ThemeColor.Success)
					},
					Classes = new SlotCollection
					{
						[nameof(DataGridSlots.Td)] = "group-even:data-[selected=true]:bg-success-100"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof( LumexDataGrid<object>.Striped )] = bool.TrueString,
						[nameof( LumexDataGrid<object>.Color )] = nameof(ThemeColor.Warning)
					},
					Classes = new SlotCollection
					{
						[nameof(DataGridSlots.Td)] = "group-even:data-[selected=true]:bg-warning-100"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof( LumexDataGrid<object>.Striped )] = bool.TrueString,
						[nameof( LumexDataGrid<object>.Color )] = nameof(ThemeColor.Danger)
					},
					Classes = new SlotCollection
					{
						[nameof(DataGridSlots.Td)] = "group-even:data-[selected=true]:bg-danger-100"
					}
				},
				new CompoundVariant
				{
					Conditions = new()
					{
						[nameof( LumexDataGrid<object>.Striped )] = bool.TrueString,
						[nameof( LumexDataGrid<object>.Color )] = nameof(ThemeColor.Info)
					},
					Classes = new SlotCollection
					{
						[nameof(DataGridSlots.Td)] = "group-even:data-[selected=true]:bg-info-100"
					}
				},
			]
		} );
	}
}
