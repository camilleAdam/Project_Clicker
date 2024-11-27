using Godot;
using System;
using System.Collections.Generic;

public partial class ShopMenu : CanvasLayer
{

  public override void _Ready()
     {
     }
    public List<Item> itemsShop = new List<Item>();

    public List<Panel> itemsPanel = new List<Panel>();
   // private Node item_scene;

    [Export]
    public PackedScene item_scene = (PackedScene)GD.Load("res://scenes/item_segment.tscn");
    private void OnClosePressed()
    {
        GetNode<CanvasLayer>("../ShopMenu").Visible = false;
    }

}