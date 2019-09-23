using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Tabboz_Base;

namespace Tabboz_3D
{
    public class UIManager : MonoBehaviour
    {
        private DayManager dayManager;
        public FSMManager fSMManager;

        [HideInInspector]
        public TMP_Text WeekDay_txt, Day_txt, Month_txt;
        public GameObject ShopMenuPanel, ShopMenuContent;
        public GameObject ShopItemPref;
        public GameObject InventoryPanel, InventoryContent;

        public void Init()
        {
            dayManager = GameManager3D.instance.dayManager;
        }
        private void OnEnable()
        {
            fSMManager.OpenMenuShopDelegate += SetupShopMenu;
            fSMManager.Act_InsideAShopMenu_GoBack += CloseShopMenu;
            dayManager.UpdateDayDelegate += UpdateDayText;
            dayManager.UpdateMonth += UpdateMonthText;
        }
        private void OnDisable()
        {
            fSMManager.OpenMenuShopDelegate -= SetupShopMenu;
            fSMManager.Act_InsideAShopMenu_GoBack -= CloseShopMenu;
            dayManager.UpdateDayDelegate -= UpdateDayText;
            dayManager.UpdateMonth -= UpdateMonthText;
        }

        #region ShopMenu
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
        #endregion
        private void UpdateDayText(int _dayNum, string _dayName)
        {
            WeekDay_txt.text = _dayName;
            Day_txt.text = _dayNum.ToString("D2") + "-";
        }

        private void UpdateMonthText(MonthsConfigData _month)
        {
            Month_txt.text = _month.Name;
        }
    }
}
