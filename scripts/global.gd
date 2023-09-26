extends Node

enum BASE_MODES {
	dev,
	easy,
	normal,
	hard,
	hell,
	hades,
	denise,
	reverse,
	nox,
	polar
}

# Called when the node enters the scene tree for the first time.
func _ready():
	# This is `OS.min_window_size` in Godot 3.2+, just noting for anything else
	DisplayServer.window_set_min_size(Vector2i(1280, 720))
	pass # Replace with function body.
	

func _input(event):
	if Input.is_key_pressed(KEY_ESCAPE):
		get_tree().quit()

# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	pass
