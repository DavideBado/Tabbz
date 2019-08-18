using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Bado_City
{
    public class MyButtonBase : Button
    {
        ButtonData mydata;
        protected override void Start()
        {
            mydata = GetComponent<ButtonData>();
        }
        public override void OnPointerClick(PointerEventData eventData)
        {
            if(mydata.DiscoShop != null)
            {
                GameManager.MyGameManager.SetDiscoDelegate(mydata.DiscoShop);
            }
            foreach (Action _action in mydata.OnClickActions)
            {
                _action();
            }
        }
    }
}
