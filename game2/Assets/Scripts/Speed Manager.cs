using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpeedManager : 
    Singleton<SpeedManager>
{

    [SerializeField] float speed = 30.0f;
    [SerializeField] float ltspeed = 55.0f;

    [SerializeField] float initializeSpeed;

    public float Speed { get { return speed; } }
    
    public float InitializeSpeed {get { return initializeSpeed; } }

    private void OnEnable()
    {
        initializeSpeed= speed;

        State.Subscribe(Condition.START, Excute);
        State.Subscribe(Condition.FINISH, Release);
    }

    public void Excute()
    {
        StartCoroutine(Increase());
    }

    void Release()
    {
        StopAllCoroutines();
    }

    IEnumerator Increase()
    {
        while (speed < ltspeed)
        {
            yield return CoroutineCache.WaitForSecond(0.533f);

            speed = speed + 0.5f;

        }
    }

  

    private void OnDisable()
    {
       

        State.UnSubscribe(Condition.START,Excute);
        State.UnSubscribe(Condition.FINISH,Release);
    }

}
