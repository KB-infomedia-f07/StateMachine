using Godot;
using Godot.Collections;
using System;

public partial class StateMachine : Node
{
	[Export]
	State initialeState;
	State currentState;

	Dictionary states = new();
	public override void _Ready()
	{
		foreach (var child in GetChildren())
		{
			if (child is State childState)
			{
				states[childState.Name.ToString().ToLower()] = childState;
				childState.Transitioned += OnChildTransition;
			}
		}
		if (initialeState != null)
		{
			initialeState.Enter();
			currentState = initialeState;
		}
	}

	public void OnChildTransition(State exitingState, string newStateName)
	{
		if (exitingState != currentState)
		{
			return;
		}

		State newState = (State)states[newStateName.ToLower()];
		if (newState == null)
		{
			return;
		}
		if (currentState != null)
		{
			currentState.Exit();
		}

		newState.Enter();
		currentState = newState;
	}

	public override void _Process(double delta)
	{
		if (currentState != null)
		{
			currentState.Update(delta);
		}
	}

	public override void _PhysicsProcess(double delta)
	{
		if (currentState != null)
		{
			currentState.PhysicsUpdate(delta);
		}
    }

}
