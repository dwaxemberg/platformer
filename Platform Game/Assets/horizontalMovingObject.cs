//Chris Baumann
using UnityEngine;
using System.Collections;

public class movingObject : MonoBehaviour {
	public float speed = 1; //Speed of platform
	public float amplitude = 25; //Full extension of amplitude
	
	// Use this for initialization
	void Start () {	
	}
	
	// Update is called once per frame
	void Update () {
		float oscillation = Mathf.Sin(Time.time * (speed)) * (amplitude/2); //Amplitude/2 to halve the sine curve to be of amplitude of half (full oscillation of top to bottom is amplitude)
		transform.position = Vector3.forward * oscillation; //Create the new position
		rigidbody.MovePosition(transform.position); //Move the platform as according to the oscillations
		
	/*void onTriggerEnter(GameObject otherObject) {
    		transform.parent = otherObject.transform;
    	}
    } 
    void OnTriggerExit(Collider otherObject) {
    	transform.parent = null;
    }
	}
	*/
	}
}
