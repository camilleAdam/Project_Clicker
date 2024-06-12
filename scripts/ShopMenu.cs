using Godot;
using System;

public partial class ShopMenu : CanvasLayer
{
    private void OnClosePressed()
    {
        GetNode<CanvasLayer>("../ShopMenu").Visible = false;
    }
}