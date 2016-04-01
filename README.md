# TimeRewind

Time Rewind in Unity3D
Stores position, rotation, and velocity values of the objects that the script is attached to

press E to rewind time up to 10 seconds 


if used to store large amounts of data for larger scenes, create a seperate master script for the counter
so the counter calculation is not done by all the game objects

only add the script to objects you wish to be affected by the time rewind

![Player example](https://github.com/nathantaylor50/TimeRewind/blob/master/2016-04-01_14-31-22.webm)

#issues:
~~~objects skips when rewinding after collision, further testing is needed.~~~~
this happened because the list max limit was not high enough, increasing the limit fixed this.
