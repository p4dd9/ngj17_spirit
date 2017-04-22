using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level4 : Level
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
        SceneManager.LoadScene("Level5");
    }

    protected override void TriggerCompleteLevel()
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
        if(FindObjectsOfType<EnemyAction>().Length == 0)
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
