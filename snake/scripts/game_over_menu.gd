extends CanvasLayer

signal restart

var clicker_scene = preload("res://scenes/main.tscn").instantiate()

func on_return_hub_button_pressed():
	get_tree().root.get_child(0)
	var hud = get_tree().root.get_children()
	print(hud)
	#get_node("/root/Main").free()
	get_tree().root.remove_child(hud[1])
	

func _on_restart_button_pressed():
	restart.emit()
