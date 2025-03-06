using Godot;
using System;
using System.Threading;
using System.Reflection.Metadata;
public partial class Player : CharacterBody2D
{
	[Export]
	public  float Speed = 150.0f;
	[Export]
	public  float JumpVelocity = -300.0f;
	private int jump_count=0;
	 private AnimatedSprite2D _animatedSprite;
	public override void _PhysicsProcess(double delta)
	{ 
		_animatedSprite= GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		Vector2 velocity = Velocity;		
		
		// Add the gravity.
		if (!IsOnFloor())
		{
			
			velocity += GetGravity() * (float)delta;
		
		}

		// Handle Jump.
		
		if(Input.IsActionJustPressed("ui_home"))
		{GetTree().ReloadCurrentScene();}
		
		if(Input.IsActionJustPressed("ui_end"))
		{
			GetTree().Quit();	
		}
		
		if (Input.IsActionJustPressed("ui_up") &&IsOnFloor()||( jump_count<1&&!IsOnFloor()&&Input.IsActionJustPressed("ui_up")))
		{
			++jump_count;
			velocity.Y = JumpVelocity;
		}
		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		
		if(direction.X>0)
		{_animatedSprite.FlipH=false;}
		else if (direction.X<0)
		{_animatedSprite.FlipH=true;}
		
		if(IsOnFloor())
		{jump_count=0;
			if(direction.X!=0)
			{_animatedSprite.Play("Run");}
			else
			{_animatedSprite.Play("idel");}}
		else
		{_animatedSprite.Play("jump_spin");}



		if (direction != Vector2.Zero)
		{
			velocity.X = direction.X * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		}

		Velocity = velocity;
		MoveAndSlide();
	}
}
