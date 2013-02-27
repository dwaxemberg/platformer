//Chris Baumann
using UnityEngine;
using System.Collections;

public class horizontalMovingObject : MonoBehaviour {
	public float speed = 1; //Speed of platform
	public float amplitude = 25; //Full extension of amplitude
	//GameObject Player; //Get the player
	// Use this for initialization
	void Start () {
		//player = gameObject.Find("Player"); //Recognize the player as an entity in the platform
	}
	
	// Update is called once per frame
	void Update () {
		float oscillation = Mathf.Sin(Time.time * (speed)) * (amplitude/2); //Inverse of speed to have control and to prevent have undefined speed, amplitude/2 to halve the sine curve to be of amplitude of half
		transform.position = Vector3.up * oscillation; //Create the new position
		rigidbody.MovePosition(transform.position); //Move the platform as according to the oscillations
		
	
	}
	void onTriggerEnter(GameObject player) { //When player collides with platform
    		transform.parent = player.transform; //Player becomes parent, moves with platform
    	} 
    void OnTriggerExit(Collider player) { //When player moves off of platform
    	transform.parent = null; //Remove parenting
    }
	}