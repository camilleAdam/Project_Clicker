using Godot;
using System;
using System.Collections.Generic;

public partial class MainSnake : Node
{
    [Export]
    public PackedScene snake_scene = (PackedScene)GD.Load("res://snake/scenes/snake_segment.tscn");

    private int score;
    private bool game_started = false;

    private int cells = 20;
    private int cell_size = 50;

    private Vector2 food_pos;
    private bool regen_food = true;

    private List<Vector2> old_data = new List<Vector2>();
    private List<Vector2> snake_data = new List<Vector2>();
    private List<Node2D> snake = new List<Node2D>();

    private Vector2 start_pos = new Vector2(9, 9);
    private Vector2 up = new Vector2(0, -1);
    private Vector2 down = new Vector2(0, 1);
    private Vector2 left = new Vector2(-1, 0);
    private Vector2 right = new Vector2(1, 0);
    private Vector2 move_direction;
    private bool can_move;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        NewGame();
    }

    private void NewGame()
    {
        GetTree().Paused = false;
        GetTree().CallGroup("segments", "queue_free");
        GetNode<Control>("GameOverMenu").Hide();
        score = 0;
        GetNode<Label>("Hud/ScoreLabel").Text = "SCORE : " + score.ToString();
        move_direction = up;
        can_move = true;
        GenerateSnake();
        MoveFood();
    }

    private void GenerateSnake()
    {
        old_data.Clear();
        snake.Clear();
        snake_data.Clear();

        for (int i = 0; i < 3; i++)
        {
            AddSegment(start_pos + new Vector2(0, i));
        }
    }

    private void AddSegment(Vector2 pos)
    {
        snake_data.Add(pos);
        var SnakeSegment = (Node2D)snake_scene.Instantiate();
        SnakeSegment.Position = (pos * cell_size) + new Vector2(0, cell_size);
        AddChild(SnakeSegment);
        snake.Add(SnakeSegment);
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        MoveSnake();
    }

    private void MoveSnake()
    {
        if (Input.IsActionJustPressed("move_down") && move_direction != up)
        {
            move_direction = down;
            can_move = false;
            if (!game_started)
            {
                StartGame();
            }
        }
        if (Input.IsActionJustPressed("move_up") && move_direction != down)
        {
            move_direction = up;
            can_move = false;
            if (!game_started)
            {
                StartGame();
            }
        }
        if (Input.IsActionJustPressed("move_left") && move_direction != right)
        {
            move_direction = left;
            can_move = false;
            if (!game_started)
            {
                StartGame();
            }
        }
        if (Input.IsActionJustPressed("move_right") && move_direction != left)
        {
            move_direction = right;
            can_move = false;
            if (!game_started)
            {
                StartGame();
            }
        }
    }

    private void StartGame()
    {
        game_started = true;
        GetNode<Timer>("MoveTimer").Start();
    }

    private void OnMoveTimerTimeout()
    {
        can_move = true;
        old_data = new List<Vector2>(snake_data);
        snake_data[0] += move_direction;
        for (int i = 0; i < snake_data.Count; i++)
        {
            if (i > 0)
            {
                snake_data[i] = old_data[i - 1];
            }
            snake[i].Position = (snake_data[i] * cell_size) + new Vector2(0, cell_size);
        }
        CheckOutOfBounds();
        CheckSelfEaten();
        CheckFoodEaten();
    }

    private void CheckOutOfBounds()
    {
        if (snake_data[0].x < 0 || snake_data[0].x > cells - 1 || snake_data[0].y < 0 || snake_data[0].y > cells - 1)
        {
            EndGame();
        }
    }

    private void CheckSelfEaten()
    {
        for (int i = 1; i < snake_data.Count; i++)
        {
            if (snake_data[0] == snake_data[i])
            {
                EndGame();
            }
        }
    }

    private void CheckFoodEaten()
    {
        if (snake_data[0] == food_pos)
        {
            score += 1;
            GetNode<Label>("Hud/ScoreLabel").Text = "SCORE: " + score.ToString();
            AddSegment(old_data[old_data.Count - 1]);
            MoveFood();
        }
    }

    private void MoveFood()
    {
        while (regen_food)
        {
            regen_food = false;
            food_pos = new Vector2(GD.RandRange(0, cells - 1), GD.RandRange(0, cells - 1));
            foreach (var i in snake_data)
            {
                if (food_pos == i)
                {
                    regen_food = true;
                }
            }
        }
        GetNode<Node2D>("Food").Position = (food_pos * cell_size) + new Vector2(0, cell_size);
        regen_food = true;
    }

    private void EndGame()
    {
        GetNode<Control>("GameOverMenu").Show();
        GetNode<Timer>("MoveTimer").Stop();
        game_started = false;
        GetTree().Paused = true;
        GetNode<Timer>("MoveTimer").Stop();
    }

    private void OnGameOverMenuRestart()
    {
        NewGame();
    }
}
