using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Bado_City
{
    /// <summary>
    /// Classe specifica per i bottoni di scelta del negozio di vestiti
    /// </summary>
    public class ClothingsButton : MyButtonBase
    {
        ClothingsButtonData clothingsButtonData;
        protected override void Start()
        {
            clothingsButtonData = GetComponent<ClothingsButtonData>();
            base.Start();
        }
        public override void OnPointerClick(PointerEventData eventData)
        {
            if (clothingsButtonData.ClothingShop != null)
            {
                GameManager.MyGameManager.SetClothingDelegate(clothingsButtonData.ClothingShop);
            }
            base.OnPointerClick(eventData);
        }
    }
}
