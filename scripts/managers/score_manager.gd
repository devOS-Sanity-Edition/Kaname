extends Node

@onready var currentScore
@onready var deathsScore
@onready var recordScore



# Called when the node enters the scene tree for the first time.
func _ready():
	currentScore = 0
	deathsScore = 0
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	pass


func score():
	currentScore += 1
	pass

func resetScore():
	if (currentScore - 1 > recordScore):
		recordScore = currentScore - 1
	
	deathsScore += 1
	currentScore = 0
