using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Scenamachine : MonoBehaviour
{
    [SerializeField] Runner runner;

    [SerializeField] CinemachineVirtualCamera
        cinemachineVirtualCamera;

    private void OnEnable()
    {
        State.Subscribe(Condition.START, Follow);  
        State.Subscribe(Condition.FINISH,Observe);
    }

    public void Follow()
    {
        cinemachineVirtualCamera.Follow
            = runner.transform;
    }

    public void Observe()
    {
        cinemachineVirtualCamera.LookAt
            = runner.transform;
    }

    private void OnDisable()
    {
        State.UnSubscribe(Condition.START, Follow);
        State.UnSubscribe(Condition.FINISH, Observe);
    }

}
