## Custom font variable
define custom_font = "fonts/Margarine/Margarine-Regular.ttf"

## Say
style say_window xalign 0.5
style say_window xsize 1220
style say_window ysize 250
style say_window yalign 0.95
style say_window background Frame("gui/frame.png", 105, 105, xalign=0.5, yalign=1.0)
style say_label color "#ffffff"
style say_label font custom_font
style say_label size 40
style say_label text_align 0.0
style say_dialogue size 30
style say_dialogue adjust_spacing True
style say_dialogue color "#e4e4e4"

define gui.name_xpos = 0.05
define gui.name_ypos = 0.25
define gui.dialogue_xpos = 0.05
define gui.dialogue_ypos = 0.35
define gui.namebox_borders = Borders(3, 0, 3, 17, 10, 0, 10, 0)
define gui.namebox_height = 20

# CTC (click-to-continue)
image ctc:
    "gui/ctc.png"
    zoom 0.65
    offset(10, 0)
    easein 1.0 offset(10, 5)
    easein 1.0 offset(10, 0)
    repeat

## NVL dialogue
style nvl_window align (0.5, 0.5)
style nvl_window xsize 900
style nvl_label size 30
style nvl_label color "#ffffff"
style nvl_label font custom_font
style nvl_dialogue size 25
style nvl_dialogue color "#e4e4e4"
style nvl_dialogue font custom_font
style nvl_dialogue adjust_spacing True

define gui.nvl_borders = Borders(27, 140, 27, 140)
define gui.nvl_name_xpos = 0.1
define gui.nvl_name_xalign = 0.0
define gui.nvl_text_xpos = 0.1
define gui.nvl_text_ypos = 0.2
define gui.nvl_text_width = 720

## GUI - Mixed
define gui.interface_text_font = custom_font
define gui.text_font = custom_font
define gui.accent_color = '#ffffff'
define gui.navigation_spacing = 10

style gui_prompt_text font custom_font
style gui_medium_button_text font custom_font
style button_text idle_color "#ffffff"
style button_text hover_color "#dedede"
style button_text selected_color "#cccccc"
style navigation_button hover_background Frame("gui/menu_item_bg_hover.png", bottom = 18, tile = True)
style navigation_button size_group None
style navigation_button_text idle_color "#ffffff"
style navigation_button_text hover_color "#ffffff"
style navigation_button_text font custom_font
style navigation_button_text size 35

# Return button
style return_button left_padding 80
style return_button top_padding 0
style return_button xalign 0.08
style return_button yalign 0.13
style return_button xsize 150
style return_button idle_background "gui/arrow_left_idle.png"
style return_button hover_background "gui/arrow_left_hover.png"
style return_button_text yalign 0.5
style return_button_text line_leading -10

define gui.button_text_xalign = 0.5
define gui.navigation_xpos = 0.5

## Scrollbars
style vscrollbar:
    base_bar Frame("gui/scrollbar/vertical_[prefix_]bar.png", Borders(5, 5, 5, 5, 0, 0, 0, 0))
    thumb "gui/scrollbar/vertical_[prefix_]thumb.png"
    thumb_offset 25

style scrollbar:
    base_bar Frame("gui/scrollbar/horizontal_[prefix_]bar.png", Borders(5, 5, 5, 5, 0, 0, 0, 0))
    thumb "gui/scrollbar/horizontal_[prefix_]thumb.png"
    thumb_offset 25

style game_menu_vscrollbar:
    xsize 50

style game_menu_scrollbar:
    ysize 50

## General styles: game menu's (pref, about, help...)
style pref_label_text font custom_font
style radio_button_text font custom_font
style radio_button_text line_leading -5
style radio_button left_padding 35
style check_button_text font custom_font
style check_button_text line_leading -5
style check_button_text antialias True
style check_button left_padding 35
style slider thumb_offset 22.5
style game_menu_label xalign 0.18
style game_menu_label yalign 0.05
style game_menu_label xanchor 0.0
style game_menu_label ysize 90
style game_menu_label top_padding 60
style game_menu_label bottom_padding 65
style game_menu_label left_padding 20
style game_menu_label right_padding 20
style game_menu_label background Frame("gui/menu_title_bg.png", bottom = 33)
style game_menu_navigation_frame xsize 0
style game_menu_content_frame left_margin 0
style game_menu_content_frame xfill True
style game_menu_side xpos 350
style game_menu_side ysize 700

## About
style about_text font custom_font

## Help
style help_text font custom_font
style help_label_text font custom_font
style help_button_text font custom_font

## History
style history_text font custom_font
style history_text size 30
style history_name xsize 180
style history_name_text font custom_font
style history_name_text text_align 0.5
style history_name_text minwidth 180
style history_name_text size 30
style history_name_text left_padding 20
style history_window xfill False
style history_window ysize None
style history_window ymargin 20
style history_fixed xfit True

## Notify
style notify_text font custom_font
define gui.notify_frame_borders = Borders(0, 5, 5, 5, 10, 15, 20, 15)

## Skip
define gui.skip_frame_borders = Borders(0, 5, 5, 5, 10, 10, 10, 10)
style skip_triangle line_spacing 0
style skip_triangle line_leading 0

## Choice buttons
define gui.choice_button_borders = Borders(100, 10, 100, 10, 10, 20, 10, 20)
define gui.choice_button_text_font = custom_font
style choice_button hover_offset(0, 2)

## Quick menu
define gui.quick_button_text_font = custom_font
define gui.quick_button_text_size = 25
style quick_button_text selected_color "#C3242A"

## Save/Load
style slot_button_text font custom_font
style page_hbox yalign 0.1

## Confirm
style confirm_button hover_background Frame("gui/namebox.png", Borders(3, 0, 3, 17, 10, 0, 10, 0))
style confirm_button ysize 25
