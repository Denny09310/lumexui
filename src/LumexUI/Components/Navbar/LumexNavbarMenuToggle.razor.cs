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
/// A component representing a button that toggles the <see cref="LumexNavbarMenu"/>.
/// </summary>
[CompositionComponent( typeof( LumexNavbar ) )]
public partial class LumexNavbarMenuToggle : LumexComponentBase, IDisposable
{
	[CascadingParameter] internal NavbarContext Context { get; set; } = default!;

	[Inject] private NavigationManager NavigationManager { get; set; } = default!;

	private LumexNavbar Navbar => Context.Owner;

	/// <summary>
	/// Initializes a new instance of the <see cref="LumexNavbarMenuToggle"/>.
	/// </summary>
	public LumexNavbarMenuToggle()
	{
		As = "button";
	}

	/// <inheritdoc />
	protected override void OnInitialized()
	{
		ContextNullException.ThrowIfNull( Context, nameof( LumexNavbarMenuToggle ) );

		NavigationManager.LocationChanged += HandleLocationChanged;
	}

	private void HandleLocationChanged( object? sender, LocationChangedEventArgs e )
		=> StateHasChanged();

	private void Toggle()
	{
		Context.Menu?.Toggle();
	}

	[ExcludeFromCodeCoverage]
	private string? GetStyles( string slot )
	{
		if( !Navbar.Slots.TryGetValue( slot, out var styles ) )
		{
			throw new NotImplementedException();
		}

		var classes = Context.Owner.Classes;

		return slot switch
		{
			nameof( NavbarSlots.Toggle ) => styles( classes?.Toggle, Class ),
			nameof( NavbarSlots.ToggleIcon ) => styles( classes?.ToggleIcon ),
			_ => throw new NotImplementedException()
		};
	}

	/// <inheritdoc />
	public void Dispose()
	{
		NavigationManager.LocationChanged -= HandleLocationChanged;
	}
}