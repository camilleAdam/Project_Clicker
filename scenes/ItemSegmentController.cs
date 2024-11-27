using Godot;
using System;

public partial class ItemSegmentController : Node
{

	[Signal] public delegate void onItemDefinitionChangeEventHandler(ItemDefinition itemDefinition);
	public void SetItemDefinition(ItemDefinition itemDefinition){
		EmitSignal(SignalName.onItemDefinitionChange, itemDefinition);
	}

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
