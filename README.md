# ArrowNav
TODO: Mention about the _Activate signal
Custom Godot Buttons that rely on arrow key/controller input
# Usage
Copy the ``addons/arrownav`` folder to your project's directory and enable it inside of Godot
The nodes ``base_uibutton`` and ``ui_handler`` will be added under the inherited node (``base_uibutton`` inherits from ``Label`` and ``ui_handler`` inherits from ``BoxContainer``)

By default ui_handler checks if ``ui_up``, ``ui_down`` or ``ui_accept`` has been pressed, feel free to change this if necessary. 
