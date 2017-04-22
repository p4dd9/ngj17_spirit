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
	// Use this for initialization
	
	// Update is called once per frame
	private void Update ()
    {
		

        if(this.currentGameState == EGameState.Menu)
        {
            if (Input.anyKey)
            {
                this.currentGameState = EGameState.InGame;
                SceneManager.LoadScene("Level1");
            }
        }
        else if (this.currentGameState == EGameState.InGame)
        {
            if (Input.GetKeyUp(KeyCode.G))
            {
                Debug.Log("Pressed G");
                GameObject gameOverGO = Resources.Load<GameObject>("GameOver");
                Instantiate(gameOverGO);
                this.currentGameState = EGameState.GameOver;
            }
        }
        else if(this.currentGameState == EGameState.GameOver)
        {
            if(Input.anyKey)
            {
                this.currentGameState = EGameState.Menu;
                SceneManager.LoadScene("Menu");
            }
        }
	}
}
