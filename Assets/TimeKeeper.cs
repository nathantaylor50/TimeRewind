using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
 * A class to store the position, rotation and velocity of game objects
 * the aim of this script is to create an illusion of time moving backwards
 */

public class TimeKeeper : MonoBehaviour
{

	//create 3 serperate lists to store the pos, rotation, and velocity of the data
	List<Vector3> positionVal = new List<Vector3> ();
	List<Vector3> rotationVal = new List<Vector3> ();
	List<Vector3> velocityVal = new List<Vector3> ();

	//index of the list
	int indexVal;
	//counter
	float counter;
	//bool and reference to the rigidbody component
	bool isRewinding;
	//max list size
	int listLimit = 1000;
	//store max time limit for which this mechanic can be used
	int timeLimitInSeconds = 10;
	Rigidbody rb;

	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
	}


	void Update ()
	{
		//counter variable to limit the rewind mechanic usage, current limit set to 10
		//check for key press
		if (Input.GetKey (KeyCode.E)) {
			if (counter > 0) {
				counter -= Time.deltaTime;
				isRewinding = true;
				Rewind ();
			}
		} else {
			if (counter < timeLimitInSeconds) {
				counter += Time.deltaTime;
			}
			isRewinding = false;
		}

		//if time is moving forward, keep adding new elements to the arrays
		if (!isRewinding) {
			positionVal.Add (transform.position);
			rotationVal.Add (transform.eulerAngles);
			velocityVal.Add (rb.velocity);
			//increase the index every frame
			if (indexVal < listLimit) {
				indexVal++;
			}
		}

		//rmove the first elemnent of all three lists when those lists goes beyond the cap
		//this is done to prevent the list becoming too large
		if (indexVal > listLimit && !isRewinding) {
			positionVal.RemoveAt (0);
			rotationVal.RemoveAt (0);
			velocityVal.RemoveAt (0);
		}


	}

	//rewind the game
	void Rewind ()
	{
		if (indexVal > 0) {
			//decrease index
			indexVal--;

			transform.position = positionVal [indexVal];
			positionVal.RemoveAt (indexVal);

			transform.eulerAngles = rotationVal [indexVal];
			rotationVal.RemoveAt (indexVal);

			rb.velocity = velocityVal [indexVal];
			velocityVal.RemoveAt (indexVal);

		}
	}
}

