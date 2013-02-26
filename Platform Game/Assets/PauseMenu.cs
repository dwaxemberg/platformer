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
		PauseGame();
	}
	
	// LastUpdate is called after all other Updates
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
		//If you have a custom skin, use it
		if(skin != null)
			GUI.skin = skin;
		//If the game is paused, display the correct menu
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
	//Sets timeScale to .0001 (0 was causing unity to crash occasionally)
	void PauseGame()
	{
		savedTimeScale = Time.timeScale;
		Time.timeScale = 0.0001f;
		AudioListener.pause = true;
		currentPage = Page.Main;
	}
	//Restores timeScale from .0001 to previous
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
	//Displays option sliders/buttons
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
	//Displays custom credits
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
	//If timeScale is < 1, game is paused
	public bool IsGamePaused()
	{
		return (Time.timeScale < 1);
	}
	//Display button in button left corner that, when clicked, goes back to main menu
	void ShowBackButton()
	{
		if(GUI.Button (new Rect(20, Screen.height - 50, 50, 20), "Back"))
				currentPage = Page.Main;
	}
	//Creates an area for the GUI components to use
	void BeginPage(int width, int height)
	{
		GUILayout.BeginArea (new Rect((Screen.width - width) / 2, (Screen.height - height) / 2, width, height));
	}
	//Ends the page.  If not on main menu, display the back button.
	void EndPage()
	{
		GUILayout.EndArea();
		if(currentPage != Page.Main)
			ShowBackButton();
	}
	//Has the game started
	bool IsBeginning()
	{
		return (Time.time <= startTime);
	}
	//Main menu options
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
