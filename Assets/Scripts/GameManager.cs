using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum EGameState
{
	Menu,
	InGame,
	GameOver
}

public class GameManager : Singleton<GameManager>
{
	public EGameState currentGameState = EGameState.Menu;
	
	// Update is called once per frame
	private void Update ()
	{
		switch (this.currentGameState) {
		case EGameState.Menu:
			{
				HandleMenuState ();
				break;
			}
			
		case EGameState.InGame:
			{
				HandleInGameState ();
				break;
			}

		case EGameState.GameOver:
			{
				HandleGameOverState ();
				break;
			}
		}
	}

	private void HandleMenuState() {
		if (Input.anyKey) {
			SetCurrenGameState (EGameState.InGame);
			LoadScene ("Level1");
		}
	}

	private void HandleInGameState() {
		if (Input.GetKeyUp (KeyCode.G)) {
			GameObject gameOverGO = Resources.Load<GameObject> ("GameOver");
			Instantiate (gameOverGO);
            SetCurrenGameState(EGameState.GameOver);
		}
	}
	private void HandleGameOverState() {
		if (Input.anyKey) {
			SetCurrenGameState (EGameState.Menu);
			LoadScene ("Menu");
		}
	}

	private void SetCurrenGameState (EGameState state)
	{
		this.currentGameState = state;
	}

	private void LoadScene (string sceneName)
	{
		SceneManager.LoadScene (sceneName);
	}
}
