using Godot;
using System;

public partial class GameOverMenu : CanvasLayer
{
    [Signal]
    public delegate void RestartEventHandler();

    private Node clicker_scene;

    private void OnReturnHubButtonPressed()
    {
        var packedSceneResource = GD.Load<PackedScene>("res://scenes/main.tscn");
        if (packedSceneResource != null)
        {
            clicker_scene = packedSceneResource.Instantiate();
        }
        var root = GetTree().Root;
        var hud = root.GetChildren();
        GD.Print(hud);
        root.RemoveChild((Node)hud[1]);
    }

    private void OnRestartButtonPressed()
    {
        EmitSignal("Restart");
    }
}
