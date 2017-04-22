using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level3 : Level
{
    public float completeLevelWaitTimeInSecs = 2;
    private bool completeLevelTriggered;
	private string levelName = "Level4";

    private void Start()
    {
        StartCoroutine(this.LevelCompleteCheck());
    }

    private IEnumerator CompleteLevel()
    {
        yield return new WaitForSeconds(this.completeLevelWaitTimeInSecs);
		SceneManager.LoadScene(levelName);
    }

    public override void TriggerCompleteLevel()
    {
        if (!this.completeLevelTriggered)
        {
            this.completeLevelTriggered = true;
            base.TriggerCompleteLevel();
            StartCoroutine(this.CompleteLevel());
        }
    }

    private IEnumerator LevelCompleteCheck()
    {
        if(FindObjectsOfType<Merging>().Length == 1)
        {
            TriggerCompleteLevel();
        }
        else
        {
            yield return new WaitForSeconds(1);
            StartCoroutine(this.LevelCompleteCheck());
        }
        
    }
}
