using UnityEngine;
using System.Collections;

public class MainCharacter : MonoBehaviour {
	public float VELOCITY = 0.5F;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		var position = this.transform.position;
		bool rotated = false;
		if (Input.GetKey(KeyCode.W)) {
			// move forward.
			this.transform.Translate(new Vector3(0F, 0F, 1F) * VELOCITY);
		}
		if (Input.GetKey (KeyCode.D)) {
			// turn right
			this.transform.Rotate(new Vector3(0f, 1f, 0F), 5);
		}
		if (Input.GetKey(KeyCode.A)) {
			// turn left
			this.transform.Rotate(new Vector3(0f, 1f, 0f), -5);
		}
		if (Input.GetKeyDown(KeyCode.S)) {
			// turn around
			this.transform.Rotate(new Vector3(0f, 1f, 0f), 180);
			rotated = true;
		}
		if (Input.GetKeyUp(KeyCode.S)) {
			rotated = false;
		}
		//random shit
	}
}
