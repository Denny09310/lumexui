// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;
using LumexUI.Utilities;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace LumexUI;

/// <summary>
/// A component representing a collapsible menu for the <see cref="LumexNavbar"/>.
/// </summary>
[CompositionComponent( typeof( LumexNavbar ) )]
public partial class LumexNavbarMenu : LumexComponentBase, IDisposable
{
	/// <summary>
	/// Gets or sets content to be rendered inside the navbar menu.
	/// </summary>
	[Parameter] public RenderFragment? ChildContent { get; set; }

	[CascadingParameter] internal NavbarContext Context { get; set; } = default!;

	[Inject] private NavigationManager NavigationManager { get; set; } = default!;

	internal bool Expanded { get; private set; }

	private protected override string? RootStyle =>
		ElementStyle.Empty()
			.Add( "--navbar-height", $"{Context.Owner.Height}" )
			.Add( base.RootStyle )
			.ToString();

	private Dictionary<string, ComponentSlot> _slots = [];

	/// <summary>
	/// Initializes a new instance of the <see cref="LumexNavbarMenu"/>.
	/// </summary>
	public LumexNavbarMenu()
	{
		As = "ul";
	}

	/// <inheritdoc />
	protected override void OnInitialized()
	{
		ContextNullException.ThrowIfNull( Context, nameof( LumexNavbarMenu ) );

		Context.RegisterMenu( this );
		NavigationManager.LocationChanged += HandleLocationChanged;
	}

	internal void Toggle()
	{
		Expanded = !Expanded;
		StateHasChanged();
	}

	private void HandleLocationChanged( object? sender, LocationChangedEventArgs e )
	{
		if( Expanded )
		{
			Toggle();
		}
	}

	/// <inheritdoc />
	protected override void OnParametersSet()
	{
		var navbar = Styles.Navbar.Style( TwMerge );
		_slots = navbar( new()
		{
			[nameof( Context.Owner.Blurred )] = Context.Owner.Blurred.ToString(),
		} );
	}

	[ExcludeFromCodeCoverage]
	private string? GetStyles( string slot )
	{
		if( !_slots.TryGetValue( slot, out var styles ) )
		{
			throw new NotImplementedException();
		}

		var classes = Context.Owner.Classes;

		return slot switch
		{
			nameof( NavbarSlots.Menu ) => styles( classes?.Menu, Class ),
			_ => throw new NotImplementedException()
		};
	}

	/// <inheritdoc />
	public void Dispose()
	{
		NavigationManager.LocationChanged -= HandleLocationChanged;
	}
}