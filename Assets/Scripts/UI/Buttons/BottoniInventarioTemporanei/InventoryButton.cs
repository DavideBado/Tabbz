using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Tabboz_3D
{
    public class InventoryButton : Button
    {
        UIManager uIManager;
        InventoryButtonData m_buttonData;
        protected override void Start()
        {
            uIManager = GameManager3D.instance.uIManager;
            m_buttonData = GetComponent<InventoryButtonData>();
        }
        public override void OnPointerClick(PointerEventData eventData)
        {
            uIManager.ItemsMenuOnOff(m_buttonData.m_itemsMenu);
          }
    }
}
