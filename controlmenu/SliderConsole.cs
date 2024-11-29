using Godot;
using System;

public partial class SliderConsole : ControllerButton
{
	public float SliderValue;
	public string SliderName;
    public int MaxClamp = 100;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
        //SliderName = "Volume";
        //OnSliderChange += SliderConsole_OnSliderChange;
		base._Ready();
	}

    /*
    private void SliderConsole_OnSliderChange()
    {
        Text = $"{SliderName}:{SliderValue}";
    }
    */

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{
		base._Process(delta);
	}

	[Signal] public delegate void OnSliderChangeEventHandler();

    public override void _PhysicsProcess(double delta)
    {
        float Axis = Input.GetAxis("menu_left", "menu_right");
        if (Axis != 0 && isButtonActive && GetNode<Control>(GetParent().GetPath()).Visible)
        {
            SliderValue = SliderValue + 1 * Axis;
            SliderValue = Mathf.Clamp(Mathf.Round(SliderValue), 0, MaxClamp);
            //Text = $"{SliderName}:{SliderValue}";
			this.EmitSignal("OnSliderChange");
        }
    }
}
