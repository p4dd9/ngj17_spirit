﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level3 : Level
{
    public float completeLevelWaitTimeInSecs = 2;
    private bool completeLevelTriggered;

    private void Start()
    {
        StartCoroutine(this.LevelCompleteCheck());
    }

    private IEnumerator CompleteLevel()
    {
        yield return new WaitForSeconds(this.completeLevelWaitTimeInSecs);
        SceneManager.LoadScene("Level4");
    }

    private IEnumerator LevelCompleteCheck()
    {
        if(FindObjectsOfType<Merging>().Length == 1)
        {
            if (!this.completeLevelTriggered)
            {
                this.completeLevelTriggered = true;
                StartCoroutine(this.CompleteLevel());
            }
        }
        else
        {
            yield return new WaitForSeconds(1);
            StartCoroutine(this.LevelCompleteCheck());
        }
        
    }
}