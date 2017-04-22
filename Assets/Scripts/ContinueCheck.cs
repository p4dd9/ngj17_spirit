using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueCheck : MonoBehaviour
{
	private void Start ()
    {
        this.gameObject.SetActive(PlayerPrefs.GetString("ContinueScene", "").Length > 0);
	}
}
