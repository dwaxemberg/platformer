using UnityEngine;
using System.Collections;

public class CameraLook : MonoBehaviour {
	
	public float sensitivityX = 5F;

	public float minimumX = -20F;
	public float maximumX = 20F;
	
	float rotationX = 0F;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		rotationX += Input.GetAxis("Mouse Y") * sensitivityX;
		rotationX = Mathf.Clamp(rotationX, minimumX, maximumX);
		transform.localEulerAngles = new Vector3(-rotationX, 0F, 0F);
	}
}
