using UnityEngine;
using System.Collections;

public class MainCharacter : MonoBehaviour {
	public float VELOCITY = 0.5F;
	// Use this for initialization
	void Start () {
	
	}
	/*
	 * need to add jumping. Make it 2D movement, i.e. left and right (pan) rotate 180 degrees
	 */

	Quaternion rightRotation = Quaternion.Euler(0,180,0);
	Quaternion leftRotation = Quaternion.Euler(0,-180,0);
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.W)) {
			// move forward.
			this.transform.Translate(new Vector3(0F, 0F, 1F) * VELOCITY);
		}
		if (Input.GetKeyDown (KeyCode.D)) {
			// turn right
			var startRotation = this.transform.rotation;
			var endRotation = this.transform.rotation * Quaternion.Euler(0,180,0);
			var rate = 1;
			float t = 0;
			while(t < 1) {
				t += (Time.deltaTime * rate);
				this.transform.rotation = Quaternion.Slerp(startRotation, endRotation, t);
			}
		}
		if (Input.GetKeyDown(KeyCode.A)) {
			// turn left
			this.transform.Rotate(new Vector3(0f, 1f, 0f), -180);
		}
		if (Input.GetKey(KeyCode.S)) {
			// turn around
			this.transform.Translate(new Vector3(0f, 0f, 1f) * -VELOCITY);
		}
	}
}
