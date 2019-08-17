using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class MyButtonBase : Button
{
    ButtonData mydata;
    protected override void Start()
    {
        mydata = GetComponent<ButtonData>();
    }
    public override void OnPointerClick(PointerEventData eventData)
    {
        mydata.OnClickAction();
    }
}
