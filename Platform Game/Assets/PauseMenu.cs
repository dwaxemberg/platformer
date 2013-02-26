using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {
	private Page currentPage;
	private float savedTimeScale;
	private float startTime = 0.1f;
	
	public GUISkin skin;
	public Color statColor = Color.yellow;
	public enum Page
	{
		None,Main,Options,Credits
	}
	// Use this for initialization
	void Start() 
	{
		Time.timeScale = 1;
		//PauseGame();
	}
	
	// Update is called once per frame
	void Update() 
	{
		if(Input.GetKeyDown (KeyCode.P))
		{
			switch(currentPage)
			{
				case Page.None: PauseGame();
					break;
				case Page.Main:	UnPauseGame();
					break;
				default:	currentPage = Page.Main;
					break;
			}
		}
	}
	void OnGUI()
	{
		if(skin != null)
			GUI.skin = skin;
		if(IsGamePaused())
		{
			GUI.color = statColor;
			switch(currentPage)
			{
			case Page.Main:	MainPauseMenu ();
				break;
			case Page.Credits: showCredits ();
				break;
			case Page.Options: showOptions ();
				break;
			}
		}
			
	}
	void PauseGame()
	{
		savedTimeScale = Time.timeScale;
		Time.timeScale = 0.0001f;
		AudioListener.pause = true;
		currentPage = Page.Main;
	}
	void UnPauseGame()
	{
		Time.timeScale = savedTimeScale;
		AudioListener.pause = false;
		currentPage = Page.None;
	}
	void RestartGame()
	{
		//restart the game
	}
	void showOptions()
	{
		BeginPage (300,300);
		GUILayout.Label ("Volume");
		AudioListener.volume = GUILayout.HorizontalSlider (AudioListener.volume, 0, 1);
		GUILayout.Label ("Quality Level");
		string[] qualities = QualitySettings.names;
		for(int i=0; i<qualities.Length; i++)
		{
			if(GUILayout.Button (qualities[i]))
				QualitySettings.SetQualityLevel (i,true);
		}
		EndPage ();
	}
	void showCredits()
	{
		BeginPage (300,300);
		GUILayout.Label ("EECS 290 - Introduction to Game Design, with Professor whatshisname");
		GUILayout.Label ("GAME NAME");
		GUILayout.Label ("Person 1");
		GUILayout.Label ("Person 1");
		GUILayout.Label ("Person 1");
		GUILayout.Label ("Person 1");
		GUILayout.Label ("Date");
		EndPage ();
	}
	bool IsGamePaused()
	{
		return (Time.timeScale < 1);
	}
	void ShowBackButton()
	{
		if(GUI.Button (new Rect(20, Screen.height - 50, 50, 20), "Back"))
				currentPage = Page.Main;
	}
	void BeginPage(int width, int height)
	{
		GUILayout.BeginArea (new Rect((Screen.width - width) / 2, (Screen.height - height) / 2, width, height));
	}
	void EndPage()
	{
		GUILayout.EndArea ();
		if(currentPage != Page.Main)
			ShowBackButton();
	}
	bool IsBeginning()
	{
		return (Time.time <= startTime);
	}
	void MainPauseMenu()
	{
		BeginPage(200,200);
		if(GUILayout.Button (IsBeginning() ? "Play" : "Continue"))
			UnPauseGame();
		if(GUILayout.Button ("Restart"))
			RestartGame();
		if(GUILayout.Button ("Options"))
			currentPage = Page.Options;
		if(GUILayout.Button ("Credits"))
			currentPage = Page.Credits;
		EndPage();
	}
	void OnApplicationPause(bool pause)
	{
		if(IsGamePaused())
			AudioListener.pause = true;
	}
}
