using Godot;
using System;

public partial class Main : Node
{

    private int coins;
    private bool gameStarted = false;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        NewGame();
    }

    private void NewGame()
    {
        GetTree().Paused = false;
        coins = 0;
        GetNode<Label>("Hud/CoinsLabel").Text = "COINS : " + coins.ToString();
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        ClickAction();
        CheckCoinsLevel();
    }

    private void ClickAction()
    {
        if (Input.IsActionJustPressed("left_click"))
        {
            AddCoins();
            if (!gameStarted)
            {
                StartGame();
            }
        }
    }

    private void StartGame()
    {
        gameStarted = true;
    }

    private void AddCoins()
    {
        coins++;
        GetNode<Label>("Hud/CoinsLabel").Text = "COINS : " + coins.ToString();
    }

    private void CheckCoinsLevel()
    {
        if (coins > 10)
        {
            GetNode<Button>("NextLevelButton").Disabled = false;
        }
    }

    private PackedScene snake_scene = (PackedScene)GD.Load("res://snake/scenes/main.tscn");

    private void _AddASceneManually()
    {
        // This is like autoloading the scene, only
        // it happens after already loading the main scene.
        var sceneInstance = snake_scene.Instantiate();
        GetTree().Root.AddChild(sceneInstance);
    }

    private void NextLevel()
    {
        _AddASceneManually();
    }

    private void OnShopPressed()
    {
        GetNode<CanvasLayer>("ShopMenu").Visible = true;
    }
}
