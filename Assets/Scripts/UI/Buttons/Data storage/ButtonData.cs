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

    /// <summary>
    /// Pezza imbarazzante per settare le action da inspector senza usare gli eventi di Unity
    /// </summary>
    private void SetOnClickAction()
    {
        foreach (Action _action in GameManager.MyGameManager.GameManagerActions)
        {
            if(_action.Method.Name == EventOnSubmit) // Questo ci permette sì di settare rapidamente le action collegate a un bottone, ma non ci permette di registrare più di un metodo alla action, facendo venire meno il senso di quest'ultima
            {
                OnClickAction = _action;
            }
        }
    }
}
