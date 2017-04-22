using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    protected virtual void Awake()
    {
        GameManager.Instance.currentGameState = EGameState.InGame;
    }
}
