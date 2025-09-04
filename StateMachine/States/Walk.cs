using Godot;
using System;

public partial class Walk : State
{
	[Export]
    Player player;
    public override void Enter()
    {
		GD.Print("Entering walk");
    }

    public override void Exit()
    {
		GD.Print("Exiting walk");
    }

	public override void PhysicsUpdate(double delta)
	{
		var velocity = player.Velocity;
		var direction = Input.GetVector("move_left", "move_right", "none", "none");
		if (direction.X != 0)
		{
			velocity.X = Mathf.Round(direction.X) * player.Speed;
		}
		else
		{
			EmitSignal(State.SignalName.Transitioned, this, "idle");
		}

		player.Velocity = velocity;
    }

    public override void Update(double delta)
    {

    }
}
