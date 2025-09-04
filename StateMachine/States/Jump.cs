using Godot;
using System;

public partial class Jump : State
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

    }

    public override void Update(double delta)
    {

    }
}
