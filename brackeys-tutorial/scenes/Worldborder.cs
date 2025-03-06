using Godot;
using System;

public partial class Worldborder : Area2D
{

		Timer timer;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{timer= GetNode<Timer>("Timer");
	timer.Timeout+=onTimerTimeout;
	BodyEntered+=onBodyEntered;}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void onBodyEntered(Node body)
	{	
		if(body is CharacterBody2D)
		{
			Engine.TimeScale=0.5;
			body.GetNode<CollisionShape2D>("CollisionShape2D").QueueFree();
			timer.Start();
		}
	}
	
	private void onTimerTimeout()
	{	Engine.TimeScale=1;
		GetTree().ReloadCurrentScene();
	}

}
