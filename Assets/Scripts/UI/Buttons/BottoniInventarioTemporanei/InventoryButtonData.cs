using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tabboz_3D
{
    public class InventoryButtonData : MonoBehaviour
    {
        public GameObject ItemsMenu;
        public IItemsMenu m_itemsMenu;
        private void Awake()
        {
            m_itemsMenu = ItemsMenu.GetComponent<IItemsMenu>();
        }
    } 
}
