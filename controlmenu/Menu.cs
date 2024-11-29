using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class Menu : VBoxContainer
{
	[Export] ControllerButton[] Buttons;
	[Export] AudioStreamPlayer player;
	[Export] Font ControllerButtonFont;
	int CurrentButton;

	

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		if(player == null)
		{
			GD.PrintErr("Cannot find a AudioStreamPlayer\nNo Audio will be played when moving through the menu.");
		}


        VisibilityChanged += Menu_VisibilityChanged;
		for(int i = 0; i < Buttons.Length; i++)
		{
			Buttons[i].LabelSettings.Font = ControllerButtonFont;
		}
		
	}

	void PlayAudio()
	{
		if(player == null)
		{
			return;
		}
		player.Play();
	}

    private void Menu_VisibilityChanged()
    {
		CurrentButton = 0;
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{
		for(int i = 0; i < Buttons.Length; i++)
		{
			Buttons[i].isButtonActive = false;
		}
		if (Input.IsActionJustPressed("menu_down") && CurrentButton < Buttons.Length - 1 && GetNode<Control>(GetParent().GetPath()).Visible && Visible)
		{
            CurrentButton++;
			PlayAudio();

        }
		else if (Input.IsActionJustPressed("menu_up") && CurrentButton != 0 && GetNode<Control>(GetParent().GetPath()).Visible && Visible)
		{
            CurrentButton--;
			PlayAudio();
        }
		else if (Input.IsActionJustPressed("menu_enter") && Buttons[CurrentButton].Visible && GetNode<Control>(GetParent().GetPath()).Visible && Visible)
		{
			Buttons[CurrentButton].EmitSignal("OnButtonPressed");
		}
		if(Buttons.Length > 0)
		{
            Buttons[CurrentButton].isButtonActive = true;
        }
		
	}
}
