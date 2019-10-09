using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tabboz_3D
{
    public class InventoryMenu : MonoBehaviour
    {
        public List<GameObject> AllItemsMenuGObj = new List<GameObject>();
        public List<IItemsMenu> AllItemsMenu = new List<IItemsMenu>();

        private void Awake()
        {
            AllItemsMenu.Clear();
            foreach (GameObject _ItemMenu in AllItemsMenuGObj)
            {
                AllItemsMenu.Add(_ItemMenu.GetComponent<IItemsMenu>());
            }
        }
    } 
}
