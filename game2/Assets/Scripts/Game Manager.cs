using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
   public void Excute()
   {
        State.Publish(Condition.START);

        AudioManager.Instance.ScenerySound("Execute");

        AudioManager.Instance.Listener("Enter Button");
   }

   

    public void Resume()
    {
        State.Publish(Condition.RESUME);
    }

}
