define j = Character("John", ctc = "ctc")
define narrator = Character(who = None, what_xalign = 0.5, what_yalign = 0.4, what_italic = True, ctc = "ctc")

label dark_forest:
    scene dark_forest
    "You went down the hill and found yourself in a dark forest."
    "Be careful, you don't know what's {color=#C3242A}lurking{/color} in the dark of night."

label start:
    scene rocky
    j "Here it is, he said to go down the hill and to the left."
    j "I have a bad feeling about this, but I need to find out more."
    $renpy.notify("Choose your path wisely.")
    menu:
        "Go down the hill":
            jump dark_forest
        "Check phone signal":
            jump dark_forest
        "Go back":
            jump dark_forest
    return
