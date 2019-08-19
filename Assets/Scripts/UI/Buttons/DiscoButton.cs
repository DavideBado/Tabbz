using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Bado_City
{
    /// <summary>
    /// Classe specifica per i bottoni di scelta della discoteca
    /// </summary>
    public class DiscoButton : MyButtonBase
    {
        DiscoButtonData discoButtonData;
        protected override void Start()
        {
            discoButtonData = GetComponent<DiscoButtonData>();
            base.Start();
        }
        public override void OnPointerClick(PointerEventData eventData)
        {
            if (discoButtonData.DiscoShop != null)
            {
                GameManager.MyGameManager.SetDiscoDelegate(discoButtonData.DiscoShop);
            }
            base.OnPointerClick(eventData);
        }
    }
}
