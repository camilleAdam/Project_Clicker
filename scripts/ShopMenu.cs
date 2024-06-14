using Godot;
using System;
using System.Collections.Generic;

public partial class ShopMenu : CanvasLayer
{

 public override void _Ready()
    {
        fillShop();
    }
    public List<Item> itemsShop = new List<Item>();

    //[Export]
    //public PackedScene item_scene = (PackedScene)GD.Load("res://scenes/item_segment.tscn");
    private void OnClosePressed()
    {
        GetNode<CanvasLayer>("../ShopMenu").Visible = false;
    }

    private void fillShop() 
    {
        //var itemSegment = (Node2D)item_scene.Instantiate();
        var vbox = GetNode("ItemsPanel").GetNode("ItemsVBoxContainer");
        vbox.
        GetTree().CallGroup("items", "queue_free");
        itemsShop.Add(new Item("The Pack", "Looks like the pack is here to give you a paw", (1, "clickS"), 1000));
    }
}