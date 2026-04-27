using Godot;
using System;

public partial class Shot : Area2D
{
	[Export]
	public Vector2 Direction { get; set; }

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Position += Direction * 200 * (float)delta;

		if(Position.Y < -10 || Position.Y > 610 || Position.X < -10 || Position.X > 810)
		{
			QueueFree();
		}
		
	}
}