using Godot;
using System;

public partial class ItemSegmentManager : Node
{

	[Export] private ItemSegmentController itemSegmentController;

	[Export] private Label name;

	[Export] private Label description;

	[Export] private Sprite2D icon;

	[Export] private Button price;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		itemSegmentController.onItemDefinitionChange += (ItemDefinition itemDefinition) => {
			name.Text = itemDefinition.GetItemName();
			description.Text = itemDefinition.GetDescription();
			price.Text = itemDefinition.GetPrice() + " coins";
			icon.Texture = itemDefinition.GetSprite();
		};
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
