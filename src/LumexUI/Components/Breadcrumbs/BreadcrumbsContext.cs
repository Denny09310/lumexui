// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using LumexUI.Common;

namespace LumexUI;

internal sealed class BreadcrumbsContext( LumexBreadcrumbs owner ) : IComponentContext<LumexBreadcrumbs>
{
	public event Action? OnChange;

	private readonly List<LumexBreadcrumbItem> _items = [];

	public LumexBreadcrumbs Owner { get; } = owner;

	public void Register( LumexBreadcrumbItem item )
	{
		_items.Add( item );
		OnChange?.Invoke();
	}

	public void Unregister( LumexBreadcrumbItem item )
	{
		_items.Remove( item );
		OnChange?.Invoke();
	}

	public bool IsLast( LumexBreadcrumbItem item )
	{
		return item == _items[^1];
	}
}
