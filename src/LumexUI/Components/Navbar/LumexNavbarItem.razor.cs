// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;
using LumexUI.Utilities;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

/// <summary>
/// A component representing a navigation item within the <see cref="LumexNavbarContent"/>.
/// </summary>
[CompositionComponent( typeof( LumexNavbar ) )]
public partial class LumexNavbarItem : LumexComponentBase
{
	/// <summary>
	/// Gets or sets content to be rendered inside the navbar item.
	/// </summary>
	[Parameter] public RenderFragment? ChildContent { get; set; }

	[CascadingParameter] internal NavbarContext Context { get; set; } = default!;

	private LumexNavbar Navbar => Context.Owner;

	/// <summary>
	/// Initializes a new instance of the <see cref="LumexNavbarItem"/>.
	/// </summary>
	public LumexNavbarItem()
	{
		As = "li";
	}

	/// <inheritdoc />
	protected override void OnInitialized()
	{
		ContextNullException.ThrowIfNull( Context, nameof( LumexNavbarItem ) );
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
			nameof( NavbarSlots.Item ) => styles( classes?.Item, Class ),
			_ => throw new NotImplementedException()
		};
	}
}