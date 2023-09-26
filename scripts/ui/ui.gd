extends Node

@onready var TopGamePanel : Control = $TopGamePanel/TopPanelContainer
@onready var BottomGamePanel : Control = $BottomGamePanel/BottomPanelContainer

@onready var deathsTextLabel : RichTextLabel = $TopGamePanel/TopPanelContainer/CenterContainer/HBoxContainer/DeathPanel/DeathText
@onready var deathsScoreLabel : RichTextLabel = $TopGamePanel/TopPanelContainer/CenterContainer/HBoxContainer/DeathPanel/DeathNumber
@onready var currentLevelTextLabel : RichTextLabel = $TopGamePanel/TopPanelContainer/CenterContainer/HBoxContainer/LevelPanel/LevelText
@onready var currentLevelScoreLabel : RichTextLabel = $TopGamePanel/TopPanelContainer/CenterContainer/HBoxContainer/LevelPanel/LevelNumber
@onready var recordTextLabel : RichTextLabel = $TopGamePanel/TopPanelContainer/CenterContainer/HBoxContainer/RecordPanel/RecordText
@onready var recordScoreLabel : RichTextLabel = $TopGamePanel/TopPanelContainer/CenterContainer/HBoxContainer/RecordPanel/RecordNumber

var deathsScore = ScoreManager.deathsScore
var currentLevelScore = ScoreManager.currentScore
var recordScore = ScoreManager.recordScore

# Called when the node enters the scene tree for the first time.
func _ready():
	get_tree().root.connect("size_changed", Callable(self, "SizeChanged"))
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	print(TopGamePanel.get_minimum_size())
	print(BottomGamePanel.get_minimum_size())
	pass

func SizeChanged():
	TopGamePanel.custom_minimum_size = Vector2i(get_viewport().get_visible_rect().size.x, 128)
	TopGamePanel.set_size(Vector2(get_viewport().get_visible_rect().size.x, 128))
	BottomGamePanel.custom_minimum_size = Vector2i(get_viewport().get_visible_rect().size.x, 128)
	BottomGamePanel.set_size(Vector2(get_viewport().get_visible_rect().size.x, 128))
	pass
