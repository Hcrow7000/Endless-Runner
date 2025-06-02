using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class MouseManager : MonoBehaviour
{

    [SerializeField] Texture2D texture2D;

    private void Awake()
    {
        texture2D = Resources.Load
            <Texture2D>("Default");
    }

    private void OnEnable()
    {
        State.Subscribe(Condition.START, DisableMode);
        State.Subscribe(Condition.FINISH, EnableMode);
    }

    void Start()
    {
        Cursor.SetCursor(texture2D, Vector2.zero
            , CursorMode.ForceSoftware);
        
        EnableMode();

    }

    public void EnableMode()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

    }

    public void DisableMode()
    {
        Cursor.visible=false;
        Cursor.lockState=CursorLockMode.Locked;

    }

    private void OnDisable()
    {
        State.UnSubscribe(Condition.START, DisableMode);
        State.UnSubscribe(Condition.FINISH, EnableMode);
    }

}
