using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public GameObject fadeOutGO;

    protected virtual void Awake()
    {
        GameManager.Instance.currentGameState = EGameState.InGame;
    }

    public virtual void TriggerCompleteLevel()
    {
        Instantiate<GameObject>(this.fadeOutGO);
    }
}
