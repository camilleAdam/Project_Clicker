extends Node

@export var clicker_scene : PackedScene

var coins : int
var game_started : bool = false

# Called when the node enters the scene tree for the first time.
func _ready():
	new_game() 

func new_game():
	get_tree().paused = false;
	coins = 0;
	$Hud.get_node("CoinsLabel").text = "COINS : " + str(coins)
	

# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	click_action()
	check_coins_level()

func click_action():
	if Input.is_action_just_pressed("left_click"):
		add_coins()
		if not game_started:
			start_game()
			
func start_game():
	game_started = true
	
func add_coins():
	coins = coins + 1
	$Hud.get_node("CoinsLabel").text = "COINS : " + str(coins)

func check_coins_level():
	if coins > 10 :
		$NextLevelButton.disabled = false

func next_level():
	_add_a_scene_manually()

var snake_scene = preload("res://snake/scenes/main.tscn").instantiate()

func _add_a_scene_manually():
	# This is like autoloading the scene, only
	# it happens after already loading the main scene.
	get_tree().root.add_child(snake_scene)
