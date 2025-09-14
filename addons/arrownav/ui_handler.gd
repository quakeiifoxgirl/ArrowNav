extends BoxContainer
class_name ui_handler
var LabelArray : Array[base_uibutton]
@export var Sounds : Array[AudioStream]
var SoundPlayer : AudioStreamPlayer


var LabelIndex : int

func PlaySoundIndex(index : int):
	if SoundPlayer != null:
		SoundPlayer.stream = Sounds[index]
		SoundPlayer.play()

func GetLabelIndex(label : base_uibutton) -> int:
	for l in LabelArray.size():
		if LabelArray[l] == label:
			return l
	return 0
	
func SetFocused(index : int):
	LabelIndex = index
	PlaySoundIndex(0)

func _ready() -> void:

	if Sounds.size() >= 2:
		SoundPlayer = AudioStreamPlayer.new()
		add_child(SoundPlayer)
	for child in get_children():
		if child is base_uibutton:
			var labelchild = child as base_uibutton
			labelchild.uihand = self
			LabelArray.append(labelchild)
			#LabelArray.append(child as base_uibutton)

func _process(_delta: float) -> void:
	if(get_children().size() == 0):
		push_error("There are no children on this node!\nPlease add a node that extends from base_uibutton")
		queue_free()
		return
	for label in LabelArray:
		label.Focused = false
	
	
	
	if Input.is_action_just_pressed("ui_up") and LabelIndex > 0:
		LabelIndex -= 1
		PlaySoundIndex(0)
	elif Input.is_action_just_pressed("ui_down") and LabelIndex != LabelArray.size() -1:
		LabelIndex += 1
		PlaySoundIndex(0)
	
	if Input.is_action_just_pressed("ui_accept"):
		PlaySoundIndex(1)
		LabelArray[LabelIndex]._Activate.emit()
		
	LabelIndex = clampi(LabelIndex, 0, LabelArray.size() - 1)
	
	LabelArray[LabelIndex].Focused = true
