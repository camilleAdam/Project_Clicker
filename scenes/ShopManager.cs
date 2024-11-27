using Godot;
using System;

public partial class ShopManager : Node
{

	[Export] private ItemDefinition[] item_list;

	[Export] private Control ui_container;

	[Export] private PackedScene item_scene;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		for (int i = 0; i < item_list.Length; i++)
		{
			ItemSegmentController item = item_scene.Instantiate<ItemSegmentController>();
			ui_container.AddChild(item);
			item.SetItemDefinition(item_list[i]);
			
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
