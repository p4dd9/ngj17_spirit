using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitManagers : MonoBehaviour {

    private void Awake()
    {
        GameManager.Instance.Touch();
    }
}
