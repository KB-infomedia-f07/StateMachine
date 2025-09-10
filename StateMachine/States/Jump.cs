using Godot;
using System;

public partial class Jump : State
{
	[Export]
  Player player;
  public override void Enter()
  {
    var velocity = player.Velocity;
    velocity.Y -= 400;
    player.Velocity = velocity;
    GD.Print("Entering jump");
  }

  public override void Exit()
  {
    GD.Print("Exiting jump");
  }

  public override void PhysicsUpdate(double delta)
  {
		var velocity = player.Velocity;
		var direction = Input.GetVector("move_left", "move_right", "none", "none");
    if (direction.X != 0)
    {
      velocity.X = Mathf.Round(direction.X) * player.Speed;
      if (direction.X < 0)
      {
        player.isFacingLeft = true;
      }
      else
      {
        player.isFacingLeft = false;
      }

      //player.isFacingLeft = direction.X < 0;
      player.Velocity = velocity;
		}
  }

  public override void Update(double delta)
  {
		if (player.IsOnFloor() && player.Velocity.Y <= 0)
		{
      EmitSignal(State.SignalName.Transitioned, this, "idle");
		}
  }
}
