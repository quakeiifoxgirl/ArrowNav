using Godot;
using System;

public partial class ControllerButton : Label
{
	public bool isButtonActive;
	LabelSettings settings = new LabelSettings();
	// Called when the node enters the scene tree for the first time.

	[Signal] public delegate void OnButtonPressedEventHandler();
	public override void _Ready()
	{
		//settings = new LabelSettings();
		//settings.Font = ResourceLoader.Load<Font>("res://dosfont.ttf");
		settings.FontSize = 24;
        LabelSettings = settings;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(isButtonActive)
		{
			settings.FontColor = Colors.Cyan;
		}
		else
		{
			settings.FontColor = Colors.Gray;
		}
	}
}
