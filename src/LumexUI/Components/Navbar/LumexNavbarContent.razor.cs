// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;
using LumexUI.Utilities;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

/// <summary>
/// A component representing the content section of the <see cref="LumexNavbar"/>.
/// </summary>
[CompositionComponent( typeof( LumexNavbar ) )]
public partial class LumexNavbarContent : LumexComponentBase
{
    /// <summary>
    /// Gets or sets content to be rendered inside the navbar content section.
    /// </summary>
    [Parameter] public RenderFragment? ChildContent { get; set; }

    /// <summary>
    /// Gets or sets the alignment for the content section of the navbar.
    /// </summary>
    /// <remarks>
    /// The default value is <see langword="null"/> 
    /// </remarks>
    [Parameter] public Align? Align { get; set; }

    [CascadingParameter] internal NavbarContext Context { get; set; } = default!;

	private LumexNavbar Navbar => Context.Owner;

	private Dictionary<string, ComponentSlot> _slots = [];

	/// <summary>
	/// Initializes a new instance of the <see cref="LumexNavbarContent"/>.
	/// </summary>
	public LumexNavbarContent()
    {
        As = "ul";
    }

    /// <inheritdoc />
    protected override void OnInitialized()
    {
        ContextNullException.ThrowIfNull( Context, nameof( LumexNavbarContent ) );
    }

	/// <inheritdoc />
	protected override void OnParametersSet()
	{
		var navbarContent = Styles.NavbarContent.Style( TwMerge );
		_slots = navbarContent( new()
		{
			[nameof( Align )] = Align?.ToString() ?? "",
		} );
	}

	[ExcludeFromCodeCoverage]
	private string? GetStyles( string slot )
	{
		if( !_slots.TryGetValue( slot, out var styles ) )
		{
			throw new NotImplementedException();
		}

		var classes = Navbar.Classes;

		return slot switch
		{
			nameof( SlotBase.Base ) => styles( classes?.Content, Class ),
			_ => throw new NotImplementedException()
		};
	}
}