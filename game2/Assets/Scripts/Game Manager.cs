using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject startButton;

    public void DisableButton()
    {
        startButton.SetActive(false);
    }

   public void Excute()
   {
        State.Publish(Condition.START);

        AudioManager.Instance.ScenerySound("Execute");

        AudioManager.Instance.Listener("Enter Button");
   }

    public void Finish()
    {

    }

    public void Resume()
    {
        State.Publish(Condition.RESUME);
    }

    private void OnEnable()
    {
        State.Subscribe
            (Condition.START, DisableButton);
        
    }

    public void OnDisable()
    {
        State.UnSubscribe
            (Condition.START, DisableButton);
    }

}
