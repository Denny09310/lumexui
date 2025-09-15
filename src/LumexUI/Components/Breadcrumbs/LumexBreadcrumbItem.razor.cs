// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;
using LumexUI.Shared.Icons;
using LumexUI.Utilities;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

[CompositionComponent( typeof( LumexBreadcrumbs ) )]
public partial class LumexBreadcrumbItem : LumexComponentBase, 
	ISlotComponent<BreadcrumbItemSlots>,
	IDisposable
{
	/// <summary>
	/// Gets or sets content to be rendered inside the component.
	/// </summary>
	[Parameter] public RenderFragment? ChildContent { get; set; }

	/// <summary>
	/// Gets or sets content to be rendered inside the component.
	/// </summary>
	[Parameter] public RenderFragment? StartContent { get; set; }

	/// <summary>
	/// Gets or sets content to be rendered inside the component.
	/// </summary>
	[Parameter] public RenderFragment? EndContent { get; set; }

	/// <summary>
	/// Gets or sets content to be rendered inside the component.
	/// </summary>
	[Parameter] public RenderFragment? SeparatorContent { get; set; } = _renderDefaultSeparator;

	/// <summary>
	/// Gets or sets a value indicating whether the <see cref="LumexBreadcrumbItem"/> is the selected item.
	/// </summary>
	[Parameter] public bool IsCurrent { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether the <see cref="LumexBreadcrumbItem"/> is the last item.
	/// </summary>
	[Parameter] public bool IsLast { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether the <see cref="LumexBreadcrumbItem"/> is disabled.
	/// </summary>
	[Parameter] public bool IsDisabled { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether the <see cref="LumexBreadcrumbItem"/> separator is visible.
	/// </summary>
	[Parameter] public bool HideSeparator { get; set; }

	/// <summary>
	/// Gets or sets the color of the breadcrumb item.
	/// </summary>
	/// <remarks>
	/// The default value is <see cref="ThemeColor.Default"/>.
	/// </remarks>
	[Parameter] public ThemeColor Color { get; set; }

	/// <summary>
	/// Gets or sets the size of the breadcrumb item.
	/// </summary>
	/// <remarks>
	/// The default value is <see cref="Size.Medium"/>.
	/// </remarks>
	[Parameter] public Size Size { get; set; } = Size.Medium;

	/// <summary>
	/// Gets or sets the underline style for the breadcrumb item.
	/// </summary>
	/// <remarks>
	/// The default value is <see cref="Underline.None"/>.
	/// </remarks>
	[Parameter] public Underline Underline { get; set; } = Underline.None;

	/// <summary>
	/// Gets or sets the CSS class names for the breadcrumb item slots.
	/// </summary>
	[Parameter] public BreadcrumbItemSlots? Classes { get; set; }

	[CascadingParameter] internal BreadcrumbsContext Context { get; set; } = default!;

	private static readonly RenderFragment _renderDefaultSeparator = builder =>
	{
		builder.OpenComponent<ChevronRightIcon>( 0 );
		builder.AddComponentParameter( 1, nameof( ChevronLeftIcon.Size ), "1em" );
		builder.CloseComponent();
	};
	
	private bool _disposed;

	private Dictionary<string, ComponentSlot> _slots = [];

	/// <summary>
	/// Initializes a new instance of the <see cref="LumexBreadcrumbItem"/>.
	/// </summary>
	public LumexBreadcrumbItem()
	{
		As = "li";
	}

	/// <inheritdoc/>
	protected override void OnInitialized()
	{
		ContextNullException.ThrowIfNull( Context, nameof( LumexBreadcrumbItem ) );

		Context.OnChange += OnContextChange;
		Context.Register( this );
	}

	/// <inheritdoc/>
	protected override void OnParametersSet()
	{
		var breadcrumbItem = Styles.BreadcrumbItem.Style( TwMerge );
		_slots = breadcrumbItem( new()
		{
			[nameof( IsCurrent )] = IsCurrent.ToString(),
			[nameof( IsLast )] = IsLast.ToString(),
			[nameof( IsDisabled )] = IsDisabled.ToString(),
			[nameof( Color )] = Color.ToString(),
			[nameof( Size )] = Size.ToString(),
			[nameof( Underline )] = Underline.ToString(),
		} );

		IsDisabled = Context.Owner.IsDisabled ?? IsDisabled;
		HideSeparator = Context.Owner.HideSeparator ?? HideSeparator;

		Color = Context.Owner.Color != BreadcrumbsConstants.DefaultColor ? Context.Owner.Color : Color;
		Size = Context.Owner.Size != BreadcrumbsConstants.DefaultSize ? Context.Owner.Size : Size;
	}

	[ExcludeFromCodeCoverage]
	private string? GetStyles( string slot )
	{
		if( !_slots.TryGetValue( slot, out var styles ) )
		{
			throw new NotImplementedException();
		}

		return slot switch
		{
			nameof( BreadcrumbItemSlots.Base ) => styles( Class ),
			nameof( BreadcrumbItemSlots.Item ) => styles( Class ),
			nameof( BreadcrumbItemSlots.Separator ) => styles( Class ),
			_ => throw new NotImplementedException()
		};
	}

	private void OnContextChange()
	{
		IsLast = Context.IsLast( this );
		StateHasChanged();
	}

	/// <inheritdoc />
	public void Dispose()
	{
		Dispose( disposing: true );
		GC.SuppressFinalize( this );
	}

	/// <inheritdoc cref="IDisposable.Dispose" />
	protected virtual void Dispose( bool disposing )
	{
		if( !_disposed )
		{
			if( disposing )
			{
				Context.Unregister( this );
				Context.OnChange -= OnContextChange;
			}

			_disposed = true;
		}
	}
}