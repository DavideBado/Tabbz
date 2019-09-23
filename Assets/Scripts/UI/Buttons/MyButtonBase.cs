using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Tabboz_Base
{
    /// <summary>
    /// Classe per i bottoni che si limitano a settare un trigger della state/classe base per gli altri bottoni
    /// </summary>
    public class MyButtonBase : Button
    {
        protected ButtonBaseData myBaseData;
        protected override void Start()
        {
            myBaseData = GetComponent<ButtonBaseData>();
        }
        public override void OnPointerClick(PointerEventData eventData)
        {            
            foreach (Action _action in myBaseData.OnClickActions)
            {
                _action();
            }
        }
    }
}
