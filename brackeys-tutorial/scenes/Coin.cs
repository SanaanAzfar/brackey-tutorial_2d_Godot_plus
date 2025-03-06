using Godot;
using System;


public partial class Coin : Area2D
{
	GameManager Game_Manager;

	private AnimationPlayer _animatedSprite;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{BodyEntered+=onBodyEntered;
	Game_Manager= GetNode<GameManager>("%GameManager");
	_animatedSprite= GetNode<AnimationPlayer>("AnimationPlayer");}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{}

	private void onBodyEntered(Node cb)
	{
		if(cb is CharacterBody2D cb2)
		{	
			Game_Manager.Add_point();
			_animatedSprite.Play("coin_collect");
		}
	}
}
