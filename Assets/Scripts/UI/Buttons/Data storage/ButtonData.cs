using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonData : MonoBehaviour
{
    public string EventOnSubmit;
    public Action OnClickAction;

    private void Start()
    {
        SetOnClickAction();
    }

    private void SetOnClickAction()
    {
        foreach (Action _action in GameManager.MyGameManager.GameManagerActions)
        {
            if(_action.Method.Name == EventOnSubmit)
            {
                OnClickAction = _action;
            }
        }
    }
}
