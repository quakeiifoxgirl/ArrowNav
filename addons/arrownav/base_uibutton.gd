extends Label
class_name base_uibutton

var uitext : String
var Focused : bool

var uihand : ui_handler

var focus_color = Color.AQUAMARINE

var mouse_enteredbool : bool

var button : Button

	
func mouse_enter():
	mouse_enteredbool = true
	uihand.SetFocused(uihand.GetLabelIndex(self))
	
func buttondown():
	uihand.PlaySoundIndex(1)
	_Activate.emit()

func mouse_exit():
	mouse_enteredbool = false

func _enter_tree() -> void:
	uitext = text
	button = Button.new()
	label_settings = LabelSettings.new()
	button["theme_override_styles/pressed"] = StyleBoxEmpty.new()
	button["theme_override_styles/focus"] = StyleBoxEmpty.new()
	button.flat = true
	
	button.size = size
	button.size += Vector2(40, 0)
	button.button_down.connect(buttondown)
	add_child(button)
	button.mouse_entered.connect(mouse_enter)
	button.mouse_exited.connect(mouse_exit)

@warning_ignore("unused_signal")	
signal _Activate()

func _process(_delta: float) -> void:
	if Focused:
		label_settings.font_color = focus_color
	else:
		label_settings.font_color = Color.WHITE
	if Focused:
		text = "> %s" % uitext
	else:
		text = uitext
	#button.size = size
