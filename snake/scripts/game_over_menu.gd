extends CanvasLayer

signal restart

var clicker_scene = preload("res://scenes/main.tscn").instantiate()

func on_return_hub_button_pressed():
	get_tree().root.add_child(clicker_scene)
	get_node("/root/Main").free()

func _on_restart_button_pressed():
	restart.emit()
