using Godot;
using System;


public partial class GameManager : Node
{
	 int score=0;

	public void Add_point()
	{score++;
	GetNode<Label>("ScoreLabel").Text="Your Coins: "+score;} 
}

