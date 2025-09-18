// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;
using LumexUI.Styles;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

/// <summary>
/// A component representing the trigger of the <see cref="LumexPopover"/> component, controlling its display.
/// </summary>
[CompositionComponent( typeof( LumexPopover ) )]
public partial class LumexPopoverTrigger : LumexComponentBase
{
	/// <summary>
	/// Gets or sets a content to render as popover trigger.
	/// </summary>
	[Parameter, EditorRequired] public RenderFragment ChildContent { get; set; } = default!;

	[CascadingParameter] internal PopoverContext Context { get; set; } = default!;

	private LumexPopover Popover => Context.Owner;

	/// <inheritdoc />
	protected override void OnInitialized()
	{
		ContextNullException.ThrowIfNull( Context, nameof( LumexPopoverTrigger ) );		
	}

	/// <inheritdoc />
	protected override void OnParametersSet()
	{
		if( ChildContent is null )
		{
			throw new InvalidOperationException(
				$"{GetType()} requires a value for the {nameof( ChildContent )} parameter." );
		}
	}

	[ExcludeFromCodeCoverage]
	private string? GetStyles( string slot )
	{
		if( !Popover.Slots.TryGetValue( slot, out var style ) )
		{
			throw new NotImplementedException();
		}

		return slot switch
		{
			nameof( PopoverSlots.Trigger ) => style( Popover.Classes?.Trigger, Class ),
			_ => throw new NotImplementedException()
		};
	}
}
