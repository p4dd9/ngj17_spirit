using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GeneralLevel : Level
{
    public float completeLevelWaitTimeInSecs = 2;
    private bool completeLevelTriggered;

    private IEnumerator CompleteLevel()
    {
        yield return new WaitForSeconds(this.completeLevelWaitTimeInSecs);

        if(SceneManager.GetActiveScene().buildIndex < SceneManager.sceneCount - 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            SceneManager.LoadScene("Credits");
        }
    }

    public void CheckForCompletion()
    {
        StartCoroutine(GameManager.Instance.CheckIfWon());
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
}
