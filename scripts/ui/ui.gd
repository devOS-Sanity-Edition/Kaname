extends Node

# Called when the node enters the scene tree for the first time.
func _ready():
	get_tree().root.connect("size_changed", Callable(self, "SizeChanged"))
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	print($TopGamePanel/TopPanelContainer.get_minimum_size())
	print($BottomGamePanel/BottomPanelContainer.get_minimum_size())
	pass

func SizeChanged():
	$TopGamePanel/TopPanelContainer.custom_minimum_size = Vector2i(get_viewport().get_visible_rect().size.x, 128)
	$TopGamePanel/TopPanelContainer.set_size(get_viewport().get_visible_rect().size.x, 128)
	$BottomGamePanel/BottomPanelContainer.custom_minimum_size = Vector2i(get_viewport().get_visible_rect().size.x, 128)
	$BottomGamePanel/BottomPanelContainer.set_size(get_viewport().get_visible_rect().size.x, 128)
	pass
