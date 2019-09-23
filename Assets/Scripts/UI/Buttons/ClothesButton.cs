using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Tabboz_Base
{
    /// <summary>
    /// Classe specifica per i bottoni di scelta del negozio di vestiti
    /// </summary>
    public class ClothesButton : MyButtonBase
    {
        ClothesButtonData clothesButtonData;
        protected override void Start()
        {
            clothesButtonData = GetComponent<ClothesButtonData>();
            base.Start();
        }
        public override void OnPointerClick(PointerEventData eventData)
        {
            if (clothesButtonData.clothesShop != null)
            {
                GameManager.MyGameManager.SetClothingDelegate(clothesButtonData.clothesShop);
            }
            base.OnPointerClick(eventData);
        }
    }
}
