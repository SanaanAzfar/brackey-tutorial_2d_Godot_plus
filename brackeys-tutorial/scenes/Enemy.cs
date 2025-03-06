using Godot;
using System;

public partial class Enemy : Node2D
{
	
	RayCast2D ray_cast_right;
	RayCast2D ray_cast_left;
	private AnimatedSprite2D _animatedSprite;
	private float direction=1;
	[Export]
	float SPEED=60;
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		ray_cast_right=GetNode<RayCast2D>("RayCastRight");
		ray_cast_left=GetNode<RayCast2D>("RayCastLeft");
		_animatedSprite= GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		Vector2 move=Position;

		if(ray_cast_right.IsColliding() && !(ray_cast_right.GetCollider() is CharacterBody2D))
		{ 	direction=-1;
		_animatedSprite.FlipH=true;}
		else if(ray_cast_left.IsColliding() && !(ray_cast_left.GetCollider() is CharacterBody2D))
		{
			direction=1;
		_animatedSprite.FlipH=false;}

		move.X+=(float)(direction*SPEED*delta);
		Position=move;
	}
}
