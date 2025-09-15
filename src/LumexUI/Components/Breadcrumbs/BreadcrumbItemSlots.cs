// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;

namespace LumexUI;

/// <summary>
/// Represents the set of customizable slots for the <see cref="LumexBreadcrumbItem"/> component.
/// </summary>
[ExcludeFromCodeCoverage]
public class BreadcrumbItemSlots : SlotBase
{
	/// <summary>
	/// Gets or sets the CSS class for the item slot.
	/// </summary>
	public string? Item { get; set; }

	/// <summary>
	/// Gets or sets the CSS class for the separator slot.
	/// </summary>
	public string? Separator { get; set; }
}
