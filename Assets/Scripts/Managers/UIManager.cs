using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Bado_City;

namespace Bado_City3D
{
    public class UIManager : MonoBehaviour
    {
        public GameObject ShopMenuPanel, ShopMenuContent;
        public GameObject ShopItemPref;
        public GameObject InventoryPanel, InventoryContent;
        public FSMManager fSMManager;

        private void OnEnable()
        {
            fSMManager.OpenMenuShopDelegate += SetupShopMenu;
            fSMManager.Act_InsideAShopMenu_GoBack += CloseShopMenu;
        }
        private void OnDisable()
        {
            fSMManager.OpenMenuShopDelegate -= SetupShopMenu;
            fSMManager.Act_InsideAShopMenu_GoBack -= CloseShopMenu;
        }

        private void CleanShopMenu()
        {
            foreach (Transform _child in ShopMenuContent.transform)
            {
                Destroy(_child.gameObject);
            }
        }
        private void SetupShopMenu(ShopBase _shop)
        {
            CleanShopMenu();
            foreach (ClothesConfigData _item in _shop.ShopData.SaleableObjects)
            {
                GameObject _newItemInfo = Instantiate(ShopItemPref, ShopMenuContent.transform);
                ClothesInfoData clothesInfo = _newItemInfo.GetComponent<ClothesInfoData>();
                clothesInfo.Setup(_item);
            }
            ShopMenuPanel.SetActive(true);
        }
        private void CloseShopMenu()
        {
            ShopMenuPanel.SetActive(false);
            CleanShopMenu();
        }      
    }
}
