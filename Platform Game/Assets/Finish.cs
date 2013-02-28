using UnityEngine;
using System.Collections;

public class Finish : MonoBehaviour {
	GameObject player;
	PauseMenu pause;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		pause = (PauseMenu)FindObjectOfType (typeof(PauseMenu));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.tag.CompareTo("Player")==0)
		{
			Debug.Log ("Level Completed");
			pause.RestartGame();
		}
	}
}
