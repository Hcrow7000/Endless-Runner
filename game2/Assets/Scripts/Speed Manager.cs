using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedManager : 
    Singleton<SpeedManager>
{

    [SerializeField] float speed = 30.0f;
    [SerializeField] float ltspeed = 55.0f;

    public float Speed { get { return speed; } }
    
    private void OnEnable()
    {
        State.Subscribe(Condition.START, Excute);

    }

    public void Excute()
    {
        StartCoroutine(Increase());
    }


    IEnumerator Increase()
    {
        while (speed < ltspeed)
        {
            yield return CoroutineCache.WaitForSecond(5.0f);

            speed = speed + 2.5f;

        }
    }

    private void OnDisable()
    {
        State.UnSubscribe(Condition.START,Excute);
    }

}
