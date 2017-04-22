using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1 : Level
{
    public float completeLevelWaitTimeInSecs = 2;
    private bool completeLevelTriggered;

    private void Start()
    {
        Influence influence = FindObjectOfType<Influence>();
        influence.onCollided += this.TriggerCompleteLevel;
    }

    public override void TriggerCompleteLevel()
    {
        if(!this.completeLevelTriggered)
        {
            this.completeLevelTriggered = true;
            base.TriggerCompleteLevel();
            StartCoroutine(this.CompleteLevel());
        }
    }

    private IEnumerator CompleteLevel()
    {
        yield return new WaitForSeconds(this.completeLevelWaitTimeInSecs);
        SceneManager.LoadScene("Level2");
    }
}
