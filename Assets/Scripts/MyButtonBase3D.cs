using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Tabboz_3D
{
    /// <summary>
    /// Classe per i bottoni che si limitano a settare un trigger della state/classe base per gli altri bottoni
    /// </summary>
    public class MyButtonBase3D : Button
    {
        protected ButtonBaseData3D myBaseData;
        protected override void Start()
        {
            myBaseData = GetComponent<ButtonBaseData3D>();
        }
        public override void OnPointerClick(PointerEventData eventData)
        {
            foreach (Action _action in myBaseData.OnClickActions)
            {
                _action?.Invoke();
            }
        }
    }
}