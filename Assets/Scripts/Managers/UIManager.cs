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
        private FSMManager fSMManager;
        private TimeManager timeManager;

        [HideInInspector]
        public TMP_Text Timer_txt, WeekDay_txt, Day_txt, Month_txt;
        public GameObject ShopMenuPanel, ShopMenuContent;
        public GameObject ShopItemPref;
        public GameObject InventoryPanel, InventoryContent;

        public void Init()
        {
            fSMManager = GameManager3D.instance.fSMManager;
            dayManager = GameManager3D.instance.dayManager;
            timeManager = GameManager3D.instance.timeManager;
            fSMManager.OpenMenuShopDelegate += SetupShopMenu;
            fSMManager.Act_InsideAShopMenu_GoBack += CloseShopMenu;
            dayManager.UpdateDayDelegate += UpdateDayText;
            dayManager.UpdateMonth += UpdateMonthText;
            timeManager.UpdateTime += UpdateTimerText;
        }
        //private void OnEnable()
        //{
        //    fSMManager.OpenMenuShopDelegate += SetupShopMenu;
        //    fSMManager.Act_InsideAShopMenu_GoBack += CloseShopMenu;
        //    dayManager.UpdateDayDelegate += UpdateDayText;
        //    dayManager.UpdateMonth += UpdateMonthText;
        //}
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
                Destroy(_child.gameObject); // Dubbi
            }
        }
        private void SetupShopMenu(ShopBase _shop)
        {
            CleanShopMenu();
            foreach (ISaleable _item in _shop.ShopData.SaleableObjects)
            {
                GameObject _newItemInfo = Instantiate(ShopItemPref, ShopMenuContent.transform);
                ItemInfoData InfoData = _newItemInfo.GetComponent<ItemInfoData>();
                InfoData.Setup(_item, _shop);
            }
            ShopMenuPanel.SetActive(true);
        }
        private void CloseShopMenu()
        {
            ShopMenuPanel.SetActive(false);
            CleanShopMenu();
        }
        #endregion

        private void UpdateTimerText()
        {
            Timer_txt.text = timeManager._Hours.ToString("D2") + ":" + ((int)timeManager._Minutes).ToString("D2");
        }
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
