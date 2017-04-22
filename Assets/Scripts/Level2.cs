using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2 : Level
{
    public float completeLevelWaitTimeInSecs = 2;
    private bool completeLevelTriggered;
	private string levelName = "Level3";

    private void Start()
    {
        Merging merging = FindObjectOfType<Merging>();
        merging.onCollided += this.TriggerCompleteLevel;
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

    private IEnumerator CompleteLevel()
    {
        yield return new WaitForSeconds(this.completeLevelWaitTimeInSecs);
		SceneManager.LoadScene(levelName);
    }
}
