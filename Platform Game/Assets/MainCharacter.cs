using UnityEngine;
using System.Collections;

public class MainCharacter : MonoBehaviour {
	PauseMenu pause;
	public float VELOCITY = 0.5F;
	public float rotationSpeed = 50;
	
	private Vector3 currentEuler;
	private bool rotating = false;
	// Use this for initialization
	void Start () {
		currentEuler = transform.eulerAngles;	
	}
	/*
	 * need to add jumping. Make it 2D movement, i.e. left and right (pan) rotate 180 degrees
	 */

	Quaternion rightRotation = Quaternion.Euler(0,180,0);
	Quaternion leftRotation = Quaternion.Euler(0,-180,0);
	// Update is called once per frame
	void Update () {
		pause = (PauseMenu)FindObjectOfType (typeof(PauseMenu));
		bool isPaused = pause.IsGamePaused();
		if(!isPaused) {
			if (Input.GetKey(KeyCode.W)) {
				// move forward.
				this.transform.Translate(new Vector3(0F, 0F, 1F) * VELOCITY);
			}
			if (Input.GetKey(KeyCode.S)) {
				// Move backwards
				this.transform.Translate(new Vector3(0f, 0f, 1f) * -VELOCITY);
			}
			if (Input.GetKeyDown (KeyCode.D)) {
				// Turn right 180 degrees
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
				// Turn left 180 degrees
				//this.transform.Rotate(0, -360*Time.deltaTime, 0);
				
			}
		}
	}
}
