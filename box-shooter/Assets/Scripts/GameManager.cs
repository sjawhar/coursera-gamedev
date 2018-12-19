﻿﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.ImageEffects;

public class GameManager : MonoBehaviour {

	// make game manager public static so can access this from other scripts
	public static GameManager gm;

	// public variables
	public int score=0;

	public bool canBeatLevel = false;
	public int beatLevelScore=0;

	public float startTime=5.0f;
	
	public Text mainScoreDisplay;
	public Text mainTimerDisplay;

	public GameObject gameOverScoreOutline;
	public GameObject timeFrozenScoreOutline;

	public AudioSource musicAudioSource;

	public bool gameIsOver = false;

	public GameObject playAgainButtons;
	public string playAgainLevelToLoad;

	public GameObject nextLevelButtons;
	public string nextLevelToLoad;

	private float currentTime;

	private bool gameIsFrozen = false;
	private float freezeTime = 0.0f;

	// setup the game
	void Start () {

		// set the current time to the startTime specified
		currentTime = startTime;

		// get a reference to the GameManager component for use by other scripts
		if (gm == null) 
			gm = this.gameObject.GetComponent<GameManager>();

		// init scoreboard to 0
		mainScoreDisplay.text = "0";

		// inactivate the gameOverScoreOutline gameObject, if it is set
		if (gameOverScoreOutline)
			gameOverScoreOutline.SetActive (false);

		if (timeFrozenScoreOutline)
			timeFrozenScoreOutline.SetActive(false);

		// inactivate the playAgainButtons gameObject, if it is set
		if (playAgainButtons)
			playAgainButtons.SetActive (false);

		// inactivate the nextLevelButtons gameObject, if it is set
		if (nextLevelButtons)
			nextLevelButtons.SetActive (false);
	}

	// this is the main game event loop
	void Update () {
		if (gameIsOver) {
			return;
		}
		else if (gameIsFrozen && freezeTime < 0)
		{
			gameIsFrozen = false;
			freezeTime = 0.0f;
			timeFrozenScoreOutline.SetActive(false);
			Camera.main.GetComponent<SepiaTone>().enabled = false;
		}
		else if (currentTime < 0)
		{ // check to see if timer has run out
			EndGame();
			return;
		}
		else if (canBeatLevel && (score >= beatLevelScore))
		{  // check to see if beat game
			BeatLevel();
			return;
		}
		// game playing state, so update the timer
		AdvanceTime();
	}

	void EndGame() {
		// game is over
		gameIsOver = true;

		// repurpose the timer to display a message to the player
		mainTimerDisplay.text = "GAME OVER";

		// activate the gameOverScoreOutline gameObject, if it is set 
		if (gameOverScoreOutline)
			gameOverScoreOutline.SetActive (true);
	
		// activate the playAgainButtons gameObject, if it is set 
		if (playAgainButtons)
			playAgainButtons.SetActive (true);

		// reduce the pitch of the background music, if it is set 
		if (musicAudioSource)
			musicAudioSource.pitch = 0.5f; // slow down the music
	}
	
	void BeatLevel() {
		// game is over
		gameIsOver = true;

		// repurpose the timer to display a message to the player
		mainTimerDisplay.text = "LEVEL COMPLETE";

		// activate the gameOverScoreOutline gameObject, if it is set 
		if (gameOverScoreOutline)
			gameOverScoreOutline.SetActive (true);

		// activate the nextLevelButtons gameObject, if it is set 
		if (nextLevelButtons)
			nextLevelButtons.SetActive (true);
		
		// reduce the pitch of the background music, if it is set 
		if (musicAudioSource)
			musicAudioSource.pitch = 0.5f; // slow down the music
	}

	// public function that can be called to update the score or time
	public void TargetHit(int scoreAmount, float timeAmount)
	{
		// increase the score by the scoreAmount and update the text UI
		score += scoreAmount;
		mainScoreDisplay.text = score.ToString ();
		
		// increase the time by the timeAmount
		currentTime += timeAmount;
		
		// don't let it go negative
		if (currentTime < 0)
			currentTime = 0.0f;

		// update the text UI
		mainTimerDisplay.text = currentTime.ToString ("0.00");
	}

	public void FreezeTargetHit()
	{
		gameIsFrozen = true;
		freezeTime += 5.0f;
		if (timeFrozenScoreOutline) {
			timeFrozenScoreOutline.SetActive(true);
		}
		Camera.main.GetComponent<SepiaTone>().enabled = true;
	}

	private void AdvanceTime()
	{
		if (gameIsFrozen) {
			freezeTime -= Time.deltaTime;
			return;
		}
		currentTime -= Time.deltaTime;
		mainTimerDisplay.text = currentTime.ToString("0.00");
	}

	public bool IsGameFrozen()
	{
		return gameIsFrozen;
	}

	// public function that can be called to restart the game
	public void RestartGame ()
	{
		// we are just loading a scene (or reloading this scene)
		// which is an easy way to restart the level
        SceneManager.LoadScene(playAgainLevelToLoad);
	}

	// public function that can be called to go to the next level of the game
	public void NextLevel ()
	{
		// we are just loading the specified next level (scene)
        SceneManager.LoadScene(nextLevelToLoad);
	}
	

}
