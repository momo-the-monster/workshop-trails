## MMM Trails - Intro to Creative Coding in Unity
![Picture](http://zippy.gfycat.com/WaryDisastrousGalapagospenguin.gif)

### About:
This is the finished project for my Intro to Creative Coding in Unity workshop. In the workshop, we write many of these scripts together, line-by-line, to better understand what we're doing. Here the project is ready for dissection, and saved into multiple scenes so you can see the process. I recommend you start by trying out one of the builds so you can play with all the scenes.

Downloads:
[Windows App](https://github.com/momo-the-monster/workshop-trails/releases/download/v0.1-alpha/PDXCC_Win_Workshop.zip)
[Mac App](https://github.com/momo-the-monster/workshop-trails/releases/download/v0.1-alpha/PDXCC_Win_Workshop.zip)

Then open the project in Unity and check out the Scenes in Assets/MMM/Trails/Scenes. I include some information about each scene below.

### Scene 1: Whitesnake
![Picture](http://i.imgur.com/3ntftcw.jpg)
**Use the keyboard to move around a cube with an attached _Trail Renderer_.**
The movement is all controlled in the *Move XY* Script attached to the cube, and the visuals are provided by the *Trail Renderer* component on that same cube. The instructions all live in the UI Object.

### Scene 2: Light Cycle
![Picture](http://i.imgur.com/tmh6pVs.jpg)
**Multiple Trail Renderers with Colors.**
The cube was turned into a Prefab called BrushCube, and six copies were made and added to a container object called Brush. The Brush is moved using the *Move XY* Script from Scene 1. A *Bloom* effect has been added to the camera, this is part of the *Unity Standard Assets*. Try playing with the trail palettes by changing the colors of the *Trail Renderer*. You can shift-click to select all the cubes and change all their colors at once. Try it while the scene is running!

### Scene 3: Enter the Mirror
![Picture](http://i.imgur.com/D9I6wHP.jpg)
**Symmetry and Screen Capture**
Two components are added to the Main Camera - Symmetry, which enables horizontal mirroring effects with several blend modes, and Simple Grab, which captures screenshots of your scene to a specified folder. Try out all the blend modes and generate some screen captures. You can press the Space Bar to toggle the UI on and off thanks to the *Group Toggle From Keyboard* script on the UI>Group object.

### Scene 4: The Camera Follows
![Picture](http://i.imgur.com/vtGDqyG.jpg)
**Stay With the Action**
A *Camera Follow* script has been added to the camera. This will keep the camera centered on a target object - in this case, the Brush container. Play with the Speed to see what it feels like, and change the Offset around while the scene is running. The 'Use Current Offset' property on the *Camera Follow* will set the offset on Scene Start based on the existing distance between the Camera and its Target.

### Scene 5: A Simplification
![Picture](http://i.imgur.com/h8iEIDH.jpg)
**Less is More**
The *Mesh Renderers* for the brush heads have been turned off so we see only the ends of the lines as they draw themselves. The *Camera Follow* script has been removed from the camera. Try playing with the Start and End sizes of the BrushCubes.

### Scene 6: Texturality
![Picture](http://i.imgur.com/3CY8lM2.jpg)
**Adding a Background Image**
A textured Quad is attached to the Camera to round out the look of our scene (photograph is Creative Commons CC-BY-SA Luca Galuzzi, please keep attribution if you use it). The *Fill Screen* script on the quad keeps the background filling the view of the camera, which has been switch to Orthographic view for this scene.