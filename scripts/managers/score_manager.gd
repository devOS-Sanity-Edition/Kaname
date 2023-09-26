extends Node

var currentScore = 0
var deathsScore = 0
var recordScore = 0

signal currentScore_value(new_value)

# Called when the node enters the scene tree for the first time.
func _ready():
	deathsScore = 0
	currentScore = 0
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	emit_signal("currentScore_value", currentScore)
	pass

		
func resetScore():
	if (currentScore - 1 > recordScore):
		recordScore = currentScore - 1
	
	deathsScore += 1
	currentScore = 0
