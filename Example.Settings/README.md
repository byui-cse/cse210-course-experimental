# Example.Settings
An example of how to use the Byui.Games core classes to read settings from a file. Note the settings
classes will look for and use a file called 'settings.json' or create one if it doesn't already 
exist. At a minimum, the settings.json file must have the following entries with your custom values.

"frameRate": 60,
"screenCaption": "CSE210 Settings Example",
"screenWidth": 640,
"screenHeight": 480

In this example, we are using the settings file to provide the information for creating an animated
robot on the screen. The robot related entries are as follows. Note the array of robot image files 
that are using for the walking animation.

"robotWidth": 96,
"robotHeight": 96,
"robotWalking": [
"Assets/robot1.png",
"Assets/robot2.png",
"Assets/robot3.png",
"Assets/robot4.png",
"Assets/robot5.png",
"Assets/robot6.png"
],
"robotWalkingDuration": 0.3