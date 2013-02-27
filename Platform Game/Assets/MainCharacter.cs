using UnityEngine;
using System.Collections;

public class MainCharacter : MonoBehaviour {
	PauseMenu pause;
	public float Velocity = 0.5F;
	public float RotationSpeed = 360F;
	public float JumpSpeed = 10F;
	
	private Quaternion qTo = Quaternion.identity;
	private Quaternion qRight = Quaternion.identity;
	private Quaternion qLeft = Quaternion.Euler(0F, 180F, 0F);
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		// Keep character anchored on x axis
		Vector3 pos = transform.position;
		pos.x = 0;
		transform.position = pos;
		
		pause = (PauseMenu)FindObjectOfType (typeof(PauseMenu));
		bool isPaused = pause.IsGamePaused();
		if(!isPaused) {
			if (Input.GetKey(KeyCode.W)) {
				// move forward
				this.transform.Translate(new Vector3(0F, 0F, 1F) * Velocity);
			}
			if (Input.GetKey(KeyCode.S)) {
				// Move backwards
				this.transform.Translate(new Vector3(0F, 0F, 1F) * -Velocity);
			}
			if (Input.GetKeyDown (KeyCode.D)) {
				// Turn right 180 degrees
				qTo = qRight;
				
			}
			if (Input.GetKeyDown(KeyCode.A)) {
				// Turn left 180 degrees
				qTo = qLeft;
				
			}
			if (Input.GetKeyDown(KeyCode.Space)) {
				if(rigidbody.velocity.y < 1F )
				{
					rigidbody.velocity = new Vector3(0F,10F,0F);
				}
			}
			
			transform.rotation = Quaternion.RotateTowards(transform.rotation, qTo, Time.deltaTime * RotationSpeed);
		}
	}
}
