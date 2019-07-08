# Unity3-RailsShooter-Demo

Show the studennts what a rail shooter game looks like [here](https://www.youtube.com/watch?v=ypwjcVEaSKg)

Make sure that everyone has Unity 2017.2+ for this project
Show the studennts what a rail shooter game looks like [here](https://www.youtube.com/watch?v=ypwjcVEaSKg)

Make sure that everyone has Unity 2017.2+ for this project

1. Create a new 3D project
2. Set up Source Control Repo
3. Create a New Scene 
4. Rename it to Level 1
5. Right Click `Hierarchy > 3D Object> Terrain`
6. Select terrain component. If the brush settings do not appear, click the 3 lines of the inspector (on the top right), and change it from debug to normal mode.
7. While the terrain is selected,  Look for resolution in the inspector. 
8. Make the terrain width and height to be 1000.
9. Move terrain position to X-250 Y 0 Z -250 to make stuff around the origin of the world
10. Select the raise/lower terrain option. Start painting on the terrain to raise it. Shift + mouse to lower it back down. Opacity is how fast things move up and lower
11. Maximum Terrain height is set at 600  (click at the gear icon in the Terrain in inspector)
12. Set the terrain height
13. In the terrain `Paint Height` option, set a height of 100, then click the "Flatten" button to set the terrain at a certain height. 
14. Then Shift + mouse to push things down to create a "valley"
15. Change the Y position to -100 to bring the terrain back to origin (since we kicked it up 100)
16. Create a mountain on the outside of the terrain (border it) so that the player does not see outside the level
17. Draw a mountain at the middle of the game.
18. Now, we'll be adding texture to our terrain. 
19. Go to the Unity assets store
20. Search for Rock texture (24 PBR Materials for Unity 5). If not available, search for any other texture.
21. Click the "Import" button to import the assets into your project 
22. Uncheck the demo scene. We don't need it. We don't want scripts. 
23. Click on the `Terrain` game object. From the inspector, select the `Paint Texture` option. 
24. Click `Edit Textures... > Add Texture...'
25. Find `rock3`  from the texture assets and drag it into the Albedo (first box to the left) 
26. Select a `rock2Norm` texture, and drag it onto the `Normal `option. Normal Map Ensure texture type is normal map so that unity knows that it is normal map and how to behave accordingly (They are a special kind of texture that allow you to add surface detail such as bumps, grooves, and scratches to a model which catch the light as if they are represented by real geometry)
27. Turn off normal map to show how much flatter our world looks. Manipulate scale values in texture. 
28. Add another texture (add texture button) click on the new texture and paint over it. Select a purplish texture with a corresponding normal. You can now use the new texture to paint over the terrain.  
29. Play around with the metallic/smooth stuff in `Edit Terrain Texture` menu.
30. We will now optimize the terrain for development. 
31. In the inspector, go to settings of `Terrain`. Increase the Pixel Error.
32. Decrease the Base Map Dist (to 400) things render as we get closer to them 
33. Uncheck Cast Shadows 
34. Now that our texture is ready, we are going to be adding a skybox
35. Right `Assets > Create > Material.
36.  Rename the material to `Skybox`.
37. In the inspector, pick the Shader to be `Skybox/Procedural`.
38. Change the color of the tint (to something reddish or purplish so that it shows).
39. Drag and drop it into the sky. It looks great, but we can do better!
40. Go to the asset store. Download and import `Skybox Volume 2 (Nebula)` or something similar. 
41. Change the `Skybox` you just applied from procedural to `Skybox/6 Sided`. 
42. There is a images in the skybox folders that represent directions. Click on any of them and drag it straight onto our skybox.
43. Alternatevly, we can use the provided `DSGWP` of any one the assets.
44. Delete our `Skybox`.
45. Move `DSGWP` to the top of assets. Rename `DSGWP` to `Skybox`.
46. Increase the exposure to show that we can make the skybox lighter.
47. Go to the Asset store. Download and import `Star Sparrow Modular Spaceship`.
48. Go to the `StarSparrow > Prefabs`, and drag and drop it onto the scene.
49. Move it around so that it is at a decent spot on the map.
50. Prefab it, then rename it to `Player Ship`.
51. Setting up a Splash Screen
52. Create a new scene.
53. Remove the directional light.
54. Increase the `Main Camera` Field of View.
55. Save the scene. Call it `Splash`. 
56. Right click `hierarchy > Create Empty`. Call it `Music Player`.
57. Add an `Audio Source` to the `Music Player`. Download the track from [here](https://drive.google.com/drive/folders/1IzkfwTkw2lPu7U8fmt8CGvwwLKyoYT-s)
58. Add a Skybox (from the asset back) to this scene. 
59. Turn the volume down. Play on wake. Loop. 
60. Add the scenes to the scene builder `File > Build Settings`.
61. Add a new scrip to the `Music Player` object. Call it `MusicPlayer` : 
```
    void Start () {
	Invoke ("LoadFirstScene", 2f); //string referenced
    }

    void LoadFirstScene(){
	SceneManager.LoadScene(1);
    }
} 
```
62. Show them that the Music Player object is getting destroyed between scenes. We do not want that. 
63. Show them the [Unity Execution order](https://docs.unity3d.com/Manual/ExecutionOrder.html). It's Awake > Start > Update... Update... Update
64. So on awake, we need to not to destroy the game object.
65. In `MusicPlayer.cs`:
```
    void Awake(){
	DontDestroyOnLoad(gameObject);
    } 
```
66. Now, the song plays between scenes. Now, it's time to make the ship fly around a certain path.
67. The easiest way to do this is to make use of an existing asset pack that Unity 2017 comes with. `Assets > Import Package > Utility`. Import all of the Assets. Some have dependencies.
68. Standard Assets > Utility. Has a couple of useful scripts:
a. WaypointCircuit.cs
b. WaypontProgressTracker.cs
69. Toggle "Y" to get a bird's eye view of the `Terrain`.
70. Create empty game object. Name it `Circuit`. 
71. Reset the transform to know where to find it.
72. Create empty child objects (5-10 no more to create smooth movements).
73. Pick a few way points by moving around the children objects all over the `Terrain`.
74. Toggle "X". Drag the `Circuit` child up a bit. 
75. In the Inspector, on the `Waypoint Circuit` script, click the "assign child objects" button and it'll show you the path. 
76. Now also click "Auto Rename numerically from this order". 
77. Now, add a component to the camera `Waypoint Progress Tracker.cs` to the `Main Camera`. 
78. On the script, you will find a `Circuit` field. Now, drag the `Circuit` game object onto the `Circuit` field of the `Waypoint Progress Tracker` script.
79. In the `Target` field, drag and drop the `Main Camera` (the thing that it's going to be moving).
80. Play the game now, and see what happens. 
a. If you get a wierd error, open the `WaypointCircuit.cs` script. In line 255, change the `i=-1` to `i=0`, and `++i` to `i++`.
81. Using Cross Platform Input
82. Make the `Player Ship` a child of the `Main Camera`.
83. Reset the `Player Ship` transformation.
84. Now the ship doesn't look so great, so move it a bit forward to get more of its view.
85. Align the view with camera to see what the camera is seeing. Select the `Main Camera`, then  `GameObject > Align View`. (if needed show this step).
86. Hard coding keys doesn't allow for remapping
87. Middle layer talks to other things
88. Allows players to remap the keys
89. A and D are the horizontal access `Edit > Project Settings > Input` is the key to the input layer (axis and buttons are the main 2 ideas)

90. Add a new script. Attach it to the `Player Ship`. Call it `PlayerController`.
```
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {
	float horizontalThrow = CrossPlatformInputManager.GetAxis("Horizontal");
	print(horizontalThrow);
    } 
```
91. Throw is how far we tilt our joy stick. Print the throw to show them what happens. Value 0 to 1.
92. In `PlayerController.cs` do the following changes:
```
    [Tooltip("In ms^-1")][SerializeField] float xSpeed = 4f;
    }

    // Update is called once per frame
    void Update () {
	float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
	float xOffsetThisFrame = xThrow * xSpeed * Time.deltaTime;
	print (xOffsetThisFrame);
    }
} 
```
93. Show them the graph here (coming soon)
94. In `PlayerController.cs` do the following changes:
```

    void Update () {
	float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
	float xOffsetThisFrame = xThrow * xSpeed * Time.deltaTime;

	float rawNewXPos = transform.localPosition.x + xOffsetThisFrame;


	transform.localPosition = new Vector3 (rawNewXPos, transform.localPosition.y, transform.localPosition.z); //change only Z, not Y and Z.
    } 
...

```
95. Play the came, and show them that great! This works. But now our ship is rolling off the screen. So we need to "clamp it" within an X boundary. Experiment to see what the xBoundaries are. In the time of documenting this demo, it was 25 meters
```
[Tooltip("In m")][SerializeField] float xRange = 25f; 

	float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
	float xOffsetThisFrame = xThrow * xSpeed * Time.deltaTime;

	float rawNewXPos = transform.localPosition.x + xOffsetThisFrame;
	float clampedXPos = Mathf.Clamp(rawNewXPos, -xRange, xRange);


	transform.localPosition = new Vector3 (clampedXPos, transform.localPosition.y, transform.localPosition.z); //change only Z, not Y and Z. 
```
96. Limit the Y axis 
97. Rotating X is pitch (show it on the `Player Ship`)
98. Rotate Y is it yaws
99. Z is rolls
100. We want the position of where we shoot to be different depending on where we aim on the screen
101. Refactoring our update. In `PlayerController.cs`, create a new function called `ProcessTranslation()` Call it in `Update()`:
```
...
   [Tooltip("In m")][SerializeField] float yRange = 15f;

... 

    private void ProcessTranslation() {
	//Throw
	float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
	float yThrow = CrossPlatformInputManager.GetAxis("Vertical");


	//Offsets
	float xOffset = xThrow * speed * Time.deltaTime;
	float yOffset = yThrow * speed * Time.deltaTime;

	//X raw
	float rawNewXPos = transform.localPosition.x + xOffset;
	float clampedXPos = Mathf.Clamp(rawNewXPos, -xRange, xRange);


	//Y raw
	float rawYPos = transform.localPosition.y + yOffset;
	float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);


	transform.localPosition = new Vector3 (clampedXPos, clampedYPos, transform.localPosition.z); //change only Z, not Y and Z.
    } 
...
```

102. Order matters in rotation
103. Be in Local mode (up top near center) (X key)
104. Use the E key to enter rotation mode
105. Try to see which order of rotations (red, green blue) does it make it easier to get to the X-30 Y30 and Z0 rotation
106. If you pitch first, then yaw right, you get weird results! 
107.  Create a `ProcessRotation() method, and call it in `Update()`:
```
private void ProcessRotation() {
transform.localRotation = Quaternion.Euler(0f, 90f, 0f);
} 
```
108. `Transform.localRotation.x` is a Quaternion. YOU CAN'T manipulate it directly. You have to create one first. It's representation of a rotation. X Y Z and Euler angles. 
109. Set the rotation to 90f. Show them what happens.
110. `Quaternion.Euler` is a static function that returns a Quaternion value, and sticks it into the `localRotation`. Internally, we do not need to know what it does!
111. To get the `Player Ship` pointing towards the center, the pitch depends on the position of the screen. Move the ship's Y Position. Show that now we need to move the pitch by -5 of that position
112. Increase the value of it to show dramatic it can be if more than 5.
113. Show them the rotation couplings table. The pitch control factor is about 2x the Y position. NOTE: factors change from project to project. You have to keep experimenting to get the right factors.  
114. So, for `ProcessRotation()`:
```
    [SerializeField] float positionPitchFactor = -2f; 

    private void ProcessRotation() {

	float pitch = 0f;
	float yaw = 0f;
	float roll = 0f;

	transform.localRotation = Quaternion.Euler(pitch, yaw, roll); 

    } 
```
115. Well, now we need to determine the pitch. For `ProcessRotation()`:
```
[SerializeField] float controlPitchFactor = -2f; 
float pitch = (transform.localPosition.y * positionPitchFactor) 
116. Great, now we also need to take into consideration the Pitch factor due to controls.

```
float pitch = (transform.localPosition.y * positionPitchFactor) + (yThrow*controlPitchFactor); 
```

OR break up the code: 

```
private void ProcessRotation() {
//pitch
float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
float pitchDueToControlThrow = yThrow * controlPitchFactor;
float pitch = pitchDueToPosition + pitchDueToControlThrow;

float yaw = 0f;
float roll = 0f;

transform.localRotation = Quaternion.Euler(pitch, yaw, roll);

} 

```

117. Now, we need to calculate the yaw and the roll (refer to the table to know what is coupled with what): 
```
[SerializeField] float positionYawFactor = 1.5f;
[SerializeField] float controlRollFactor = -20f; 

private void ProcessRotation() {
//pitch
float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
float pitchDueToControlThrow = yThrow * controlPitchFactor;
float pitch = pitchDueToPosition + pitchDueToControlThrow;

float yaw = transform.localPosition.x * positionYawFactor;

float roll = xThrow * controlRollFactor;

transform.localRotation = Quaternion.Euler(pitch, yaw, roll);

} 



```
118. Created a Landing Pad to see what changes we are applying. Put it under the `Player Ship`. Prefab the `Landing Pad`.
119. Create a Particle System effect as a child of the `Player Ship`. Right click `Player Ship > Effects > Particle System`.
120. Rename particle system to `Bullets`.
121. (optional) In the Asset Store, download any `3D particle system`.  On the inspector, click `Renderer > Default-Particle`. Drag and drop the particles texture onto the `Bullets` in the heiarchy.
122. Click on `Shape`. Choose `Cone`. Reduce the radius all the way down to `0.01.` Change the angle down to "0".
123.  Change the particle `Start Color` to red.
124. Play the game and show what is happening. 
125. Uncheck Looping. Change the duration of the particles. If you put it for 3s.  It shoots for 3 secs then stops.
126. Change the duration to 0.2.
127. Change the `Emission` `Rate over Time` to 3 (the number of particles emitted per second).
128. Start lifetime - how long the bullet lives before it disappears.
129. Start speed - the speed of the bullet as it shoots. Change it to an appropriate number so that the bullet shoots forward. 
130. Change the `Simulation Space` to `World` so the bullets leave the child game object. 
131. Prefab the `Bullets` 
132. Delete it from the Hierarchy. 
133. Add the `Bullets` it as a child of the `Player Ship`.
134. Duplicate `Bullets` under the `Player Ship`. Name them `Bullets - Left` and `Bullets - Right`
135. Move the `Bullets` so that they line up with the ship's cannons. 
136. Mention that the entire `Particle System` is a Gameobject. Not each particle is a game object.
137. Now, we will create an explosion effect. In the Hierarchy, `Right Click > Effects > Particle System`. Rename it to `Explosion`.
138. Drag it and drop it onto the Explosion Game object
139. Change the duration of the explosion to 0.50
140. Turn off looping
141. Start lifetime is 0.1
142. Start speed random between two constants. 5-50
143. Size random between two constants. 1 to 5. 
144. Emission RoT 300.
145. Shape > Sphere.
146. (optional). Renderer > Put a material on it.
147. Start color > gradient. Players the colors in order as it fades
148. Simulation space is world.
149. Play the particle animation to show that it looks like. 
150. Adding obstacles and enemies
151. Our first option is to just simply raise the `Terrain` along the path. Select the `Terrain` Gameobject, and raise it where the path goes.
152. Create a new `Empty` Gameobject in the hierarchy. Name it `Environment Obstacles`.
153. Create a `Cube` under the `Environment Obstacles`. Name it Obstacle (1). Change the scale to X50 Y10 Z10.
154.  Duplicate and spread the obstacles around. You can even add textures to them if you'd like.
155. Play the game to show what the obstacles are doing. 
156. Download the `Simple Generic Enemy` asset from [here](https://drive.google.com/drive/folders/1IzkfwTkw2lPu7U8fmt8CGvwwLKyoYT-s). Send them the zip file on `Slack`. 
157. Remind them that this is a paid asset. Use it in a non-commercial way. If they want to publish this game, remember that someone spend a lot of time developing these assets. Be kind, and buy it from the Asset Store.
158. Double click the `Asset` file, and import all of the spaceship assets.
159. Drag and drop `Ship_03` into the hierarchy. 
160. Rename it to `Enemy Ship`. Rescale it to X20 Y20 Z20. (possibly a bigger size depending on the project).
161. Set the rotation so that the `Enemy Ship` faces the `Player Ship`. 
162. Prefab `Enemy Ship (1)`.
163. Create an empty Game Object in the hierarchy. Name it `Enemies`.
164. Drag and drop `Enemy Ship (1)` onto `Enemies`. Duplicate  `Enemy Ship (1)`, and move them around so that they intercept the `Circuit` at different points.
165. Tidying things up - designer mode to coder mode. 
166. Create an `Asset Packs` folder. Put all the `Asset Packs` in there. 
167. Create a folder for `Prefabs`. Drop all the prefabs in there.
168. Create a `Audio` folder for sound effects. Drop all audio files in there.
169. Create a folder for `Scripts`. Drop all the scripts in there.
170. Create a `Environment` folder. Drop the `Terrain` and `Skybox` in there.
171. Prefab `Directional Light` because we want to use it in multiple scenes. Put it in `Environment`.
172. Now, the `Music Player` is loading a scene which is weird. So create a new `SceneLoader` script. Let us create a separation of concern.
173. Inside the `Splash` scene, create a new `Empty` GameObject called `Scene Loader`.
174. Attach the `SceneLoader` script to the `Scene Loader` game object. Move the following code from `MusicPlayer.cs` to `SceneLoader.cs`:
```

using UnityEngine.SceneManagement; 

void Start () {
Invoke ("LoadFirstScene", 4f); //string referenced
}

// Update is called once per frame
void Update () {

}

void LoadFirstScene(){
SceneManager.LoadScene(1);
} 

```
175. Play the game to show things are still working the same. 
176. Collisions
177. In the `PlayerController.cs` script, Use the `OnCollisionEnter` to print something out.
```
    void OnCollisionEnter(Collision collision){
	print ("A collision occured!");
    }
```
178. Nothing happens! 
a. There are two types of collisions. First, normal collisions (we've seen before. Which process physics).
b. Then there are triggers
c. On the `Player Ship`, add a `Box Collider` component. If it's not a trigger, then the physics will be processed. It will bounce off of things. If IT IS trigger, physics will NOT be processed. Now for physics to happen, we need a `Rigidbody`.
d. Add a `Rigidbody` component to the `Player Ship`.
e. It if has a box collider and Is Kinematic is unchecked, it is a rigid body collider. If it has kinematic selected, it's a kinematic rigid body collider. Rigid bodies provide physics to the object.  Kinematic means the study of movement without physics. It's basically saying we move this thing in script. We are not going to let the physics engine move it. Show them the physics being processed in the game, and the collision message is actually happening now.
f. Why put a physics component on there only to make it not moved?!?! 
g. Show them the table. If either things have a trigger on them, then it is an onTrigger Event.
h. If it does not have a `Rigidbody` on it, it's a static collider
i. On the `Player Ship`, turn off the Is Trigger and Is Kinematic. Play the game. Show that when the ship bumps the wall, the physics is processed. Not what we want! We want to just blow it up. 
j. The `Terrain` itself is a static collider. 
k. So if we want the ship to Trigger, the ship MUST have a `Rigidbody` on it. 
179. Enemy prefabs - Add Box Collider on them. As long as they have colliders on them, it doesn't matter. 
180. Do the same with obstacle prefab. Add a Box collider to it. Check the static button (has to do with lighting) 
181. With all that said, add the `OnTriggerEnter` function in `PlayerController.cs`:
```
    void OnTriggerEnter(Collider other) {
	print("Something triggered");
    } 
```
182. Sending messages between components.
183. Add a new script to the `Player Ship`. Name it `CollisionHandler`.
184. Move the `OnTriggerEnter` function to `CollisionHandler.cs` (to keep things tidy).
185. Now, when a trigger occurs, we want to start the death sequence of a player. Inside `CollisionHandler.cs`:
```
void OnTriggerEnter(Collider other) {
StartDeathSequence();
}

private void StartDeathSequence(){
print("Start death sequence");
SendMessage("OnPlayerDeath"); //string referenced
} 
```
186. Now, someone has to catch the message, and run the `OnPlayerDeath` sequence. In `PlayerController.cs`:
```
    bool isControlEnabled = true; 

    void OnPlayerDeath(){
	isControlEnabled = false;
    } 
```
187. Now, in the `PlayerControlller.cs` `Update()`, we check for `isControlEnabled`. If so, process movement. If not, stay still:
```

void Update () {
if (isControlEnabled) {
    ProcessTranslation ();
    ProcessRotation ();
}
} 
```

188. Great. But now we also would like to enable the explosion effect. In `CollisionHandler.cs`, expose a GameObject to the inspector:
```
[SerializeField] GameObject deathFX; 
```
189. Now, drag and drop the `Explosion` prefab onto the `Death FX` field in the inspector.
190. Also, drag and drop the prefab onto the `Player Ship` itself.
191. Uncheck the `Explosion` Gameobject to disable it. We only want to enable it in the case of a trigger.
192. In `CollisionHandler.cs`, the `onTriggerEnter`:

```
void OnTriggerEnter(Collider other) {
deathFX.SetActive(true);
StartDeathSequence();
} 
```
193. Now, let us load levels: 
[SerializeField] float levelLoadDelay = 3f; 

Define a `ReloadScene` function
    private void ReloadScene(){
	SceneManager.LoadScene(1);
    } 
194. Call the function in the OnTriggerEnter:
void OnTriggerEnter(Collider other) {
deathFX.SetActive(true);
StartDeathSequence();
Invoke("ReloadScene", levelLoadDelay);
} 
195. Click on the bullets. Go to the inspector > Particle System >  Enable collision.
196. Open the Collision option. Change the Type from `Planes` to `World`. 
197. Finally, check the `Send Collison Messages` box.
198. In the Hierarchy, select all `Enemy Ship` objects. Disable the Is Trigger on the Box Collider.
199. Still with all `Enemy Ship` objects selected, add a component `Script`, and name it `Enemy`.  
200. The gameObject is from the context of the enemy
void OnParticleCollision(GameObject other){
print("Particles collided with enemy" + gameObject.name);
}  
201. Show them the print statement
202. Now, we destroy the GameObject
    void OnParticleCollision(GameObject other){
	Destroy(gameObject);
    } 
203. Create a duplicate of the `Explosion` prefab. Name it `Enemy Explosion`. 
204. In the `Enemy.cs` script, add the following:
    void OnParticleCollision(GameObject other){
	Destroy(gameObject);
	Instantiate (deathFX, transform.position, Quaternion.identity);
    } 
205. Adding Score UI
206. Add a GameObject > UI > Text
207. `Canvas`
208. Click `2D` on top, where the `# Scene` is, to show them what the canvas looks like.  
209. In the inspector, the `Canvas > Render Mode` choose `Screen Space - Overlay.`
210. Press the "T" key, then drag and position the textbox down left.
211. In the inspector, in Text (Script) add text and color. Align center if necessary. 
212. For different fonts, go to Dafont.com 
213. Drag the .ttf file into font, and it sets it up!
214. Click on the `Text` in `Hierarchy`. Add a new script called `ScoreBoard`.
215. In `ScoreBoard.cs`:
```
using UnityEngine.UI; 
    int score;
    Text scoreText;

    // Use this for initialization
    void Start () {
	scoreText = GetComponent<Text>();
	scoreText.text = "456";
    } 
```

216. Great, but this is static. We need to create a public function (a function that can be called by another script) to increment the score.

```
int score;
Text scoreText;

// Use this for initialization
void Start () {
scoreText = GetComponent<Text>();
}

public void ScoreHit(int scorePerHit){
score = score + scorePerHit;
scoreText.text = score.ToString();
} 

```
217. Now, we need to call this function every time an `Enemy Spaceship` dies.
218. In `Enemy.cs`:
```
[SerializeField] int scorePerHit = 12;

ScoreBoard sb;

// Use this for initialization
void Start () {
sb = FindObjectOfType<ScoreBoard>();

} 

void OnParticleCollision(GameObject other){
sb.ScoreHit(scorePerHit);
Destroy(gameObject);
Instantiate (deathFX, transform.position, Quaternion.identity);
} 

```

	
	


	
		
