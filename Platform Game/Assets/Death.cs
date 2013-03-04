using UnityEngine;
using System.Collections;

public class Death : MonoBehaviour {
	PauseMenu pause;
	// Use this for initialization
	void Start () {
		pause = (PauseMenu)FindObjectOfType (typeof(PauseMenu));
	}

	// Update is called once per frame
	void Update () {

	}
	
	// Diego Waxemberg
	void OnTriggerEnter(Collider col) {
		pause.RestartLevel();
	}
}
