using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum EButtonAction
{
    NewGame,
    Continue,
    Credits,
    Exit,
    Menu
}

public class MenuButtonCollider : MonoBehaviour
{
    public Text text;
    public float triggerWaitTime = 1.75f;
    public float triggerExitWaitTime = 0.5f;
    public float targetScale = 1.5f;
    public EButtonAction action;

    private float startTriggerTime;
    private bool isInsideTrigger;
    private float exitTriggerTime;
    private float enterScale;
    private float exitScale;
    private bool loadLevelTriggered;

    private void Update()
    {
        if(!this.isInsideTrigger)
        {
            if (!Mathf.Approximately(this.text.rectTransform.localScale.x, 1))
            {
                this.text.rectTransform.localScale = Vector3.Lerp(Vector3.one * this.exitScale, Vector3.one, Mathf.InverseLerp(this.exitTriggerTime, this.exitTriggerTime + this.triggerExitWaitTime, Time.time));
            }
            else
            {
                this.text.rectTransform.localScale = Vector3.one;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        this.startTriggerTime = Time.time;
        this.isInsideTrigger = true;
        this.enterScale = this.text.rectTransform.localScale.x;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        this.text.rectTransform.localScale = Vector3.Lerp(Vector3.one * this.enterScale, Vector3.one * this.targetScale, Mathf.InverseLerp(this.startTriggerTime, this.startTriggerTime + this.triggerWaitTime, Time.time));

        if(Mathf.Approximately(this.text.rectTransform.localScale.x, this.targetScale))
        {
            switch(this.action)
            {
                case EButtonAction.NewGame:
                    {
                        if(!this.loadLevelTriggered)
                        {
                            this.loadLevelTriggered = true;
                            StartCoroutine(LoadLevel("Level1"));
                        }              
                    }
                    break;

                case EButtonAction.Continue:
                    {

                    }
                    break;

                case EButtonAction.Credits:
                    {
                        if (!this.loadLevelTriggered)
                        {
                            this.loadLevelTriggered = true;
                            StartCoroutine(LoadLevel("Credits"));
                        }
                    }
                    break;

                case EButtonAction.Menu:
                    {
                        if (!this.loadLevelTriggered)
                        {
                            this.loadLevelTriggered = true;
                            StartCoroutine(LoadLevel("Menu"));
                        }
                    }
                    break;

                case EButtonAction.Exit:
                    {
                        Application.Quit();
                    }
                    break;
            }
        }
    }

    private IEnumerator LoadLevel(string levelName)
    {
        GameObject go = Instantiate<GameObject>(Resources.Load<GameObject>("FadeOut"));
        go.GetComponentInChildren<UIFade>().fadeTime = 0.5f;
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(levelName);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        this.isInsideTrigger = false;
        this.exitTriggerTime = Time.time;
        this.exitScale = this.text.rectTransform.localScale.x;
    }
}
