using Godot;
using System;

public partial class Player : CharacterBody2D
{
	AnimationPlayer animationPlayer;
	Sprite2D sprite;
	public float Speed = 300.0f;
	public float JumpVelocity = -400.0f;
	public bool isFacingLeft = false;

    public override void _Process(double delta)
    {
		sprite.FlipH = isFacingLeft;
    }

	public override void _Ready()
	{
		animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
		sprite = GetNode<Sprite2D>("Sprite");	
		animationPlayer.Play("idle");
	}

	public void PlayAnimation(string animationName)
	{
		if (animationPlayer != null)
		{
			animationPlayer.Play(animationName);
		}
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;
		// Add the gravity.
		if (!IsOnFloor())
		{
			velocity += GetGravity() * (float)delta;
		}
		Velocity = velocity;
		MoveAndSlide();
	}
}
