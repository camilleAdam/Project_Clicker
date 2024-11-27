using System;
using Godot;

// https://docs.godotengine.org/en/stable/tutorials/scripting/c_sharp/c_sharp_global_classes.html
[GlobalClass]
public partial class ItemDefinition : Resource {
    [Export] private Texture2D sprite;
    [Export] private String name;

    [Export] private String description;

    [Export] private int price;

    public String GetItemName() {
        return name;
    }

    public String GetDescription() {
        return description;
    }

    public int GetPrice() {
        return price;
    }

    public Texture2D GetSprite() {
        return sprite;
    }
}