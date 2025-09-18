// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;

using Microsoft.AspNetCore.Components;

namespace LumexUI.Internal;

/// <summary>
/// Represents an internal tab panel component.
/// This component is intended for internal use only.
/// </summary>
[EditorBrowsable( EditorBrowsableState.Never )]
public partial class TabPanel : LumexComponentBase
{
	/// <summary>
	/// Gets or sets the currently selected tab associated with this panel.
	/// </summary>
	/// <remarks>
	/// Internal use only.
	/// </remarks>
	[Parameter] public LumexTab? SelectedTab { get; set; }

	[CascadingParameter] internal TabsContext Context { get; set; } = default!;

	private LumexTabs Tabs => Context.Owner;

	/// <inheritdoc />
	protected override void OnInitialized()
	{
		ContextNullException.ThrowIfNull( Context, nameof( TabPanel ) );
	}

	[ExcludeFromCodeCoverage]
	private string? GetStyles( string slot )
	{
		if( !Tabs.Slots.TryGetValue( slot, out var style ) )
		{
			throw new NotImplementedException();
		}

		return slot switch
		{
			nameof( TabsSlots.TabPanel ) => style( Tabs.Classes?.TabPanel, Class ),
			_ => throw new NotImplementedException()
		};
	}
}