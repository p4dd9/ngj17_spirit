using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum EGameState
{
	Menu,
	InGame,
    Multiplayer,
	GameOver
}

public class GameManager : Singleton<GameManager>
{
	public EGameState currentGameState = EGameState.Menu;
	
	// Update is called once per frame
	private void Update ()
	{
		switch (this.currentGameState) {
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

	public IEnumerator CheckIfWon ()
	{
		yield return new WaitForEndOfFrame ();
        GameObject[] badStuffs = GameObject.FindGameObjectsWithTag("BadStuff");

		if (badStuffs.Length == 0) {
			GeneralLevel generalLevel = FindObjectOfType<GeneralLevel> ();

			if (generalLevel != null) {
				generalLevel.TriggerCompleteLevel ();
			}
		}
	}

	public IEnumerator CheckIfGameOver ()
	{
		yield return new WaitForEndOfFrame ();
		GameObject[] goodStuffs = GameObject.FindGameObjectsWithTag ("GoodStuff");

		float goodStuffSize = 0;

		for (int i = 0; i < goodStuffs.Length; ++i) {
			goodStuffSize += goodStuffs [i].transform.localScale.x;
		}

		//EnemyAction[] badStuffs = FindObjectsOfType<EnemyAction> ();
        GameObject[] badStuffs = GameObject.FindGameObjectsWithTag("BadStuff");

        float badStuffSize = 0;

		for (int i = 0; i < badStuffs.Length; ++i) {
			badStuffSize += badStuffs [i].transform.localScale.x;
		}

        if(this.currentGameState == EGameState.Multiplayer)
        {
            if(goodStuffSize == 0)
            {
                GameObject gameOverGO = Resources.Load<GameObject>("GameOver");
                GameObject go = Instantiate(gameOverGO);
                go.GetComponentInChildren<Text>().text = "Player 2 wins";
                SetCurrenGameState(EGameState.GameOver);
            }
            else if (badStuffSize == 0)
            {
                GameObject gameOverGO = Resources.Load<GameObject>("GameOver");
                GameObject go = Instantiate(gameOverGO);
                go.GetComponentInChildren<Text>().text = "Player 1 wins";
                SetCurrenGameState(EGameState.GameOver);
            }
        }
        else
        {
            if (goodStuffSize < badStuffSize)
            {
                GameObject gameOverGO = Resources.Load<GameObject>("GameOver");
                Instantiate(gameOverGO);
                SetCurrenGameState(EGameState.GameOver);
            }
        }
	}

	private void HandleInGameState ()
	{

		if (Input.GetKeyUp (KeyCode.P)) { // break
			if (Time.timeScale == 1) { // audio on
				Time.timeScale = 0;
				AudioListener.pause = true;
			} else { // audio off
				Time.timeScale = 1;
				AudioListener.pause = false;
			}
		}
	}

	private void HandleGameOverState ()
	{
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
