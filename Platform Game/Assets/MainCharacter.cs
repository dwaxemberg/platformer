using UnityEngine;
using System.Collections;

// Charles Marshall
public class MainCharacter : MonoBehaviour {
	PauseMenu pause;
	public float Velocity = 0.25F;
	public float RotationSpeed = 360F;
	public float JumpSpeed = 10F;
	
	// Variables for turning
	private Quaternion qTo = Quaternion.identity;
	private Quaternion qRight = Quaternion.identity;
	private Quaternion qLeft = Quaternion.Euler(0F, 180F, 0F);
	private const float fLittleBit = 0.01f;
    private bool bFirst = true;
	
	// Variable for jump constraints
	private float distToGround;
	
	// Use this for initialization
	void Start () {
		distToGround = collider.bounds.extents.y;
		pause = (PauseMenu)FindObjectOfType (typeof(PauseMenu));
	}
	
	// Update is called once per frame
	void Update () {
		// Keep character anchored on x axis
		Vector3 pos = transform.position;
		pos.x = 0;
		transform.position = pos;
		
		
		bool isPaused = pause.IsGamePaused();
		if(!isPaused) {
			if (Input.GetKey(KeyCode.W)) {
				// Move forward
				this.transform.Translate(new Vector3(0F, 0F, 1F) * Velocity);
			}
			if (Input.GetKey(KeyCode.S)) {
				// Move backwards
				this.transform.Translate(new Vector3(0F, 0F, 1F) * -Velocity);
			}
			if (Input.GetKeyDown (KeyCode.D)) {
				// Turn right 180 degrees
				if(Vector3.Angle(transform.forward, Vector3.forward) < fLittleBit) {
					transform.rotation = Quaternion.Euler(0F, 0F + fLittleBit, 0F);
					qTo = qLeft;
					bFirst = true;
				}
				else if (Vector3.Angle(transform.forward, Vector3.back) < fLittleBit) {
					transform.rotation = Quaternion.Euler(0F, 180F + fLittleBit, 0F);
					qTo = qRight;
					bFirst = false;
				}
				else {
					if(bFirst) {
						qTo = qLeft;
					}
					else {
						qTo = qRight;
					}
				}
			}
			if (Input.GetKeyDown(KeyCode.A)) {
				// Turn left 180 degrees
				if (Vector3.Angle(transform.forward, Vector3.forward) < fLittleBit) {
					transform.rotation = Quaternion.Euler(0.0f, 0.0f - fLittleBit, 0.0f);
					qTo = qLeft;
					bFirst = false;
				}
				else if (Vector3.Angle(transform.forward, Vector3.back) < fLittleBit) {
					transform.rotation = Quaternion.Euler(0.0f, 180.0f-fLittleBit,0.0f);
          			qTo = qRight;
          			bFirst = true;
				}
				else {
					if (bFirst) {
              			qTo = qRight;
					}
          			else {
              			qTo = qLeft;
					}
				}
			}
			if (Input.GetKeyDown(KeyCode.Space) && IsGrounded()) {
				// Jump
				rigidbody.velocity = new Vector3(0F,JumpSpeed,0F);
			}
			
			// For turning
			transform.rotation = Quaternion.RotateTowards(transform.rotation, qTo, Time.deltaTime * RotationSpeed);
		}
	}
	
	// Check to see if object is resting on a surface
	bool IsGrounded() {
		return Physics.Raycast(this.transform.position, -Vector3.up, distToGround);
	}
	
	// Diego Waxemberg
	public static void MoveToLevel(int level) {
		switch (level) {
		case 1:
			GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(0F, 73F, -1280F);
			break;
		case 2:
			GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(0F, 2F, -770F);
			break;
		case 3:
			GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(0F, 4F, -240F);
			break;
		default:
			GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(0F, 73F, -1280F);
			break;
		}
	}
}