using Godot;
using System;

public partial class Idle : State
{
	[Export]
	Player player;
    public override void Enter()
	{
		GD.Print("Entering Idle");
	}

    public override void Exit()
    {
		GD.Print("Exiting idle");
    }

	public override void PhysicsUpdate(double delta)
	{
		var velocity = player.Velocity;
		velocity.X = Mathf.MoveToward(player.Velocity.X, 0, player.Speed);
		player.Velocity = velocity;

		if (Input.IsActionJustPressed("move_left") || Input.IsActionJustPressed("move_right"))
		{
			EmitSignal(State.SignalName.Transitioned, this, "walk");
		}
	/*
		if (Input.IsActionJustPressed("jump"))
		{
			EmitSignal(State.SignalName.Transitioned, this, "jump");
		}
		*/
    }

    public override void Update(double delta)
    {
		
    }
}
