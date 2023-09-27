extends Node2D


func _ready():
	pass # Replace with function body.


func _draw():
	var center = Vector2(get_viewport_rect().get_center().x, get_viewport_rect().get_center().y)
	var radius = 448 / 2
	var angle_from = 0
	var angle_to = 360
	var color = Color8(255, 255, 255)
	draw_circle_arc_poly(center, radius, angle_from, angle_to, color)
	pass

func draw_circle_arc_poly(center, radius, angle_from, angle_to, color):
	var nb_points = 128
	var points_arc = PackedVector2Array()
	points_arc.push_back(center)
	var colors = PackedColorArray([color])

	for i in range(nb_points + 1):
		var angle_point = deg_to_rad(angle_from + i * (angle_to - angle_from) / nb_points - 90)
		points_arc.push_back(center + Vector2(cos(angle_point), sin(angle_point)) * radius)
	draw_polygon(points_arc, colors)
