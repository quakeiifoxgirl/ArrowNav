#if TOOLS
using Godot;
using System;

[Tool]
public partial class controlmenu : EditorPlugin
{
	string addonPath = "res://addons/controlmenu/";
	public override void _EnterTree()
	{
		var Menu = GD.Load<Script>($"{addonPath}Menu.cs");
        var ControllerButton = GD.Load<Script>($"{addonPath}ControllerButton.cs");
		var Slider = GD.Load<Script>($"{addonPath}SliderConsole.cs");
        AddCustomType("ControllerButton", "Label", ControllerButton, null);
		AddCustomType("Menu", "VBoxContainer", Menu, null);
		AddCustomType("SliderConsole", "Label", Slider, null);
    }

	public override void _ExitTree()
	{
		// Clean-up of the plugin goes here.
	}
}
#endif
