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
   }

    public void Finish()
    {

    }

    public void Resume()
    {
        Debug.Log("Resume");
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
