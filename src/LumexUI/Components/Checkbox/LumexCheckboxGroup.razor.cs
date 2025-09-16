// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

using System;
using System.Diagnostics.CodeAnalysis;

using LumexUI.Common;
using LumexUI.Utilities;

using Microsoft.AspNetCore.Components;

namespace LumexUI;

/// <summary>
/// A component that represents a group of checkboxes.
/// </summary>
public partial class LumexCheckboxGroup : LumexComponentBase, ISlotComponent<CheckboxGroupSlots>
{
	/// <summary>
	/// Gets or sets content to be rendered inside the checkbox group.
	/// </summary>
	[Parameter] public RenderFragment? ChildContent { get; set; }

	/// <summary>
	/// Gets or sets the label for the checkbox group.
	/// </summary>
	[Parameter] public string? Label { get; set; }

	/// <summary>
	/// Gets or sets the description for the checkbox group.
	/// </summary>
	[Parameter] public string? Description { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether the checkbox group is disabled.
	/// </summary>
	[Parameter] public bool Disabled { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether the checkbox group is read-only.
	/// </summary>
	[Parameter] public bool ReadOnly { get; set; }

	/// <summary>
	/// Gets or sets a color of the checkbox group.
	/// </summary>
	/// <remarks>
	/// The default is <see cref="ThemeColor.Primary"/>
	/// </remarks>
	[Parameter] public ThemeColor Color { get; set; } = ThemeColor.Primary;

	/// <summary>
	/// Gets or sets the border radius of the checkbox group.
	/// </summary>
	/// <remarks>
	/// The default is <see cref="Radius.Medium"/>
	/// </remarks>
	[Parameter] public Radius Radius { get; set; } = Radius.Medium;

	/// <summary>
	/// Gets or sets the size of the checkbox group.
	/// </summary>
	/// <remarks>
	/// The default value is <see cref="Size.Medium"/>
	/// </remarks>
	[Parameter] public Size Size { get; set; } = Size.Medium;

	/// <summary>
	/// Gets or sets the CSS class names for the checkbox group slots.
	/// </summary>
	[Parameter] public CheckboxGroupSlots? Classes { get; set; }

	/// <summary>
	/// Gets or sets the CSS class names for the checkboxes slots.
	/// </summary>
	[Parameter] public CheckboxSlots? CheckboxClasses { get; set; }

	private readonly CheckboxGroupContext _context;

	private Dictionary<string, ComponentSlot> _slots = [];

	/// <summary>
	/// Initializes a new instance of the <see cref="LumexCheckboxGroup"/>.
	/// </summary>
	public LumexCheckboxGroup()
	{
		_context = new CheckboxGroupContext( this );
	}

	/// <inheritdoc />
	protected override void OnParametersSet()
	{
		var checkboxGroup = Styles.CheckboxGroup.Style( TwMerge );
		_slots = checkboxGroup();
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
			nameof( CheckboxGroupSlots.Base ) => styles( Classes?.Base, Class ),
			nameof( CheckboxGroupSlots.Wrapper ) => styles( Classes?.Wrapper ),
			nameof( CheckboxGroupSlots.Description ) => styles( Classes?.Description ),
			nameof( CheckboxGroupSlots.Label ) => styles( Classes?.Label ),
			_ => throw new NotImplementedException()
		};
	}
}