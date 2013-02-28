using UnityEngine;
using System.Collections;

public class CameraLook : MonoBehaviour {
	PauseMenu pause;
	public float sensitivityX = 5F;

	public float minimumX = -20F;
	public float maximumX = 20F;
	
	float rotationX = 0F;
	
	// Use this for initialization
	void Start () {
		pause = (PauseMenu)FindObjectOfType (typeof(PauseMenu));
	}
	
	// Update is called once per frame
	void Update () {
		
		bool isPaused = pause.IsGamePaused();
		if(!isPaused)
		{
			rotationX += Input.GetAxis("Mouse Y") * sensitivityX;
			rotationX = Mathf.Clamp(rotationX, minimumX, maximumX);
			transform.localEulerAngles = new Vector3(-rotationX, 0F, 0F);
		}
	}
}
