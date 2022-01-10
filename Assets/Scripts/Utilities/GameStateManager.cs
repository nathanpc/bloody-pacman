using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Global game states.
/// </summary>
public enum GlobalGameState {
	Running = 0,
	Over
}

/// <summary>
/// Handles the current state of the game and changes states when needed.
/// </summary>
public class GameStateManager : MonoBehaviour {
	[SerializeField] private GlobalGameState _currentState;

	[Header("Main Menu")]
	public string gameScene;

	[Header("Game Over")]
	public GameObject gameOverScreen;
	public string mainMenuScene;

	[Header("Objects")]
	public GameObject broccoli;
	public GameObject sugarDaddy;

	public void Start() {
		CurrentState = GlobalGameState.Running;
	}

	/// <summary>
	/// Well, it's over everyone! Time to go home.
	/// </summary>
	public void GameOver() {
		// Ignore all of this if its already over.
		if (CurrentState == GlobalGameState.Over)
			return;

		// Show the Game Over screen.
		gameOverScreen.SetActive(true);

		// Disable the players to avoid problems.
		broccoli.SetActive(false);
		sugarDaddy.SetActive(false);

		// Set the game state.
		CurrentState = GlobalGameState.Over;
	}

	/// <summary>
	/// Goes to the main menu screen.
	/// </summary>
	public void GoToMainMenuScene() {
		SceneManager.LoadScene(mainMenuScene);
	}

	/// <summary>
	/// Goes to the game scene.
	/// </summary>
	public void GoToGameScene() {
		SceneManager.LoadScene(gameScene);
	}

	/// <summary>
	/// Current game state.
	/// </summary>
	public GlobalGameState CurrentState {
		get { return _currentState; }
		protected set { _currentState = value; }
	}
}
