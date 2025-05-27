using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedManager : MonoBehaviour
{

    [SerializeField] float speed = 30.0f;
    [SerializeField] float ltspeed = 55.0f;

    static SpeedManager instance;

    public static SpeedManager Instance
    { get { return instance; } }

    public float Speed { get { return speed; } }

    public float LtSpeed {get { return ltspeed; } }

    private void Awake()
    {
        if ( instance == null)
        {
            instance = this;
        }

    }

}
