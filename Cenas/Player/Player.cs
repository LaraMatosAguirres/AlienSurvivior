using Godot;
using System;

public partial class Player : Area2D
{
	[Signal]
	public delegate void ShootEventHandler(Vector2 position, Vector2 direction);
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Vector2 direction = Vector2.Zero;

		if(Input.IsActionPressed("ui_right"))
		{
			direction.X += 1;
		}
		if(Input.IsActionPressed("ui_left"))
		{
			direction.X -= 1;
		}
		if(Input.IsActionPressed("ui_down"))
		{
			direction.Y += 1;
		}
		if(Input.IsActionPressed("ui_up"))
		{
			direction.Y -= 1;
		}

		direction = direction.Normalized();

		Position += direction * 100 * (float)delta;

		if(Input.IsActionJustPressed("ui_accept"))
		{
			Vector2 gunPos = GetNode<Marker2D>("Marker2D").GlobalPosition;

			Vector2 mousePos = GetGlobalMousePosition();
			direction = (mousePos - gunPos).Normalized();
			
			EmitSignal(SignalName.Shoot, gunPos, direction);
		}
	}
}
