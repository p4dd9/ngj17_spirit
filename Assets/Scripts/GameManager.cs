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

    public void CheckIfGameOver()
    {
        if (GameObject.FindGameObjectsWithTag("GoodStuff").Length - 1 == 0)
        {
            GameObject gameOverGO = Resources.Load<GameObject>("GameOver");
            Instantiate(gameOverGO);
            SetCurrenGameState(EGameState.GameOver);
        }
    }

    private void HandleInGameState() {

		if (Input.GetKeyUp(KeyCode.P)) // break
		{
			if (Time.timeScale == 1) // audio on
			{
				Time.timeScale = 0;
				AudioListener.pause = true;
			}
			else // audio off
			{
				Time.timeScale = 1;
				AudioListener.pause = false;
			}
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
