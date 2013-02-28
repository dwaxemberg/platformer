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
	
	void GoToNextLevel() {
		switch (pause.GetCurrentLevel()) {
		case 1:
			// move to level 2
			MainCharacter.MoveToLevel(2);
			break;
		case 2:
			// move to level 3
			MainCharacter.MoveToLevel(3);
			break;
		case 3:
			// WINNER!
			// restart game
			pause.RestartGame();
			break;
		default:
			// move to level 1'
			MainCharacter.MoveToLevel(1);
			break;
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.tag.CompareTo("Player")==0)
		{
			print ("Level Complete");
			Debug.Log ("Level Completed");
			GoToNextLevel();
		}
	}
}
