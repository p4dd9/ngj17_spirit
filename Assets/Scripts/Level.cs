using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    public GameObject fadeOutGO;

    protected virtual void Awake()
    {
        GameManager.Instance.currentGameState = EGameState.InGame;
        PlayerPrefs.SetString("ContinueScene", SceneManager.GetActiveScene().name);
    }

    public virtual void TriggerCompleteLevel()
    {
        Instantiate<GameObject>(this.fadeOutGO);
    }
}
