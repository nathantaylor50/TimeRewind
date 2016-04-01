# TimeRewind
Time Rewind in Unity3D
This solution may have issues with scalability
Stores position, rotation, and velocity values of the objects that the script is attached to

press E to rewind time up to 10 seconds 


if used to store large amounts of data for larger scenes, create a seperate master script for the counter
so the counter calculation is not done by all the game objects

only add the script to objects you wish to be affected by the time rewind

![Player example](https://github.com/nathantaylor50/TimeRewind/blob/master/ezgif-2110815843.gif)

#issues:
~~~objects skips when rewinding after collision, further testing is needed.~~~~
this happened because the list max limit was not high enough, increasing the limit fixed this.

#Possible Future Improvements
- use stacks instead of linkedlists 
- implement a glitch effect to occur when time is being rewinded
- implement a visual bar in uGUI to show how much the player can rewind time for
- smooth movements at the begining and end of time rewinding (Lerp and Slerp)
- have a custom class to hold the infor instead of seperate lists, that way adding more info wouldnt be complicated, frame of animation etc. to reduce overhead (boxing and unboxing)
- to have the mechanic while destroying objects (bullets for example) one way can be "fake-destroying" instead of removing it, then after a point that the "destroyed" object cant be re-called back into existence by the mechanic then the object can actually be destroyed (use GameObject.activeInHierarchy)
- if for example a bullet is reverted to a time before it was actually in existence then destroy the object.
- instead of the class being used by a lot of gameObjects use GameObject.SendMessage from a parent object to send to child objects 
