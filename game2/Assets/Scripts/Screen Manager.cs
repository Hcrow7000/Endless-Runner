using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    [SerializeField] GameObject timePanel;
    [SerializeField] GameObject resultPanel;
    [SerializeField] GameObject startButton;

    private void OnEnable()
    {
        State.Subscribe(Condition.START, ExcuteInterface);
        State.Subscribe(Condition.FINISH, FinishInerface);
    }

    public void ExcuteInterface()
    {
        startButton.SetActive(false);
    }

    public void FinishInerface()
    {
        timePanel.SetActive(false);
        resultPanel.SetActive(true);
    }

    private void OnDisable()
    {
        State.UnSubscribe(Condition.START, ExcuteInterface);
        State.UnSubscribe(Condition.FINISH, FinishInerface);  
    }
}
