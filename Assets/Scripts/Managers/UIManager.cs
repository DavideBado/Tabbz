using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Tabboz_Base;
using System.Linq;

namespace Tabboz_3D
{
    public class UIManager : MonoBehaviour
    {
        private DayManager dayManager;
        private FSMManager fSMManager;
        private TimeManager timeManager;
        List<IItemsMenu> allItemsMenu = new List<IItemsMenu>();
        IItemsMenu m_CurrentItemsMenu;
        [HideInInspector]
        public TMP_Text Timer_txt, WeekDay_txt, Day_txt, Month_txt;
        public GameObject ShopMenuPanel, ShopMenuContent;
        public GameObject ShopItemPref;
        public InventoryMenu InventoryPanel;

        #region Actions
        public Action InventoryOnOff;
        #endregion
        #region DelegatesDef
        public delegate void OnItemsMenuDelegate(IItemsMenu _itemsMenu);
        #endregion

        #region Delegates
        public OnItemsMenuDelegate ItemsMenuSetup;
        public OnItemsMenuDelegate ItemsMenuOnOff;
        #endregion

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
            InventoryOnOff += OpenCloseInventory;
            ItemsMenuSetup += SetupItemsMenu;
            ItemsMenuOnOff += ItemsMenuOpenClose;
            allItemsMenu = InventoryPanel.GetComponentsInChildren<IItemsMenu>().ToList();
            dayManager.ReturnCurrentDayMonth?.Invoke();
            InitMenu();
        }
        //private void OnEnable()
        //{
        //    fSMManager.OpenMenuShopDelegate += SetupShopMenu;
        //    fSMManager.Act_InsideAShopMenu_GoBack += CloseShopMenu;
        //    dayManager.UpdateDayDelegate += UpdateDayText;
        //    dayManager.UpdateMonth += UpdateMonthText;
        //}
        //private void OnDisable()
        //{
        //    fSMManager.OpenMenuShopDelegate -= SetupShopMenu;
        //    fSMManager.Act_InsideAShopMenu_GoBack -= CloseShopMenu;
        //    dayManager.UpdateDayDelegate -= UpdateDayText;
        //    dayManager.UpdateMonth -= UpdateMonthText;
        //    timeManager.UpdateTime -= UpdateTimerText;
        //    InventoryOnOff -= OpenCloseInventory;
        //    ItemsMenuSetup -= SetupItemsMenu;
        //    ItemsMenuOnOff -= ItemsMenuOpenClose;
        //}

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
                ItemInShopInfoData InfoData = _newItemInfo.GetComponent<ItemInShopInfoData>();
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

        #region Inventory

        private void OpenCloseInventory()
        {
            InventoryPanel.gameObject.SetActive(!InventoryPanel.gameObject.activeSelf);
            //if(InventoryPanel.gameObject.activeSelf)
            //{
            //InitMenu();
            //}
        }

        private void InitMenu()
        {

            foreach (IItemsMenu _menu in InventoryPanel.AllItemsMenu)
            {
                CleanItemsMenu(_menu);
                ItemsMenuSetup(_menu);
            }
        }

        private void CleanItemsMenu(IItemsMenu _itemsMenu)
        {
            foreach (Transform _child in _itemsMenu.Content.transform)
            {
                Destroy(_child.gameObject); // Dubbi
            }
        }
        private void SetupItemsMenu(IItemsMenu _itemsMenu)
        {
           // CleanItemsMenu(_itemsMenu);
            foreach (ISaleable _item in _itemsMenu.Items)
            {
                _itemsMenu.UpdateItems(_item);
                //GameObject _newItemInfo = Instantiate(_itemsMenu.ItemPrefab, _itemsMenu.Content.transform);
                //ItemInventoryInfoData InfoData = _newItemInfo.GetComponent<ItemInventoryInfoData>();
                //InfoData.Setup(_item);
            }
            //if(m_CurrentItemsMenu != null)
            //    m_CurrentItemsMenu.Panel.SetActive(false);
            //_itemsMenu.Panel.SetActive(true);
            //m_CurrentItemsMenu = _itemsMenu;
        }

        public void UpdateItemsInMenu(ISaleable _item)
        {
            foreach (IItemsMenu _itemsMenu in InventoryPanel.AllItemsMenu)
            {
                _itemsMenu.UpdateItems(_item);
            }
        }

        private void ItemsMenuOpenClose(IItemsMenu _itemsMenu)
        {
            GameObject _panel = _itemsMenu.Panel;
            _panel.SetActive(true);
            if (m_CurrentItemsMenu != null && m_CurrentItemsMenu != _itemsMenu)
                m_CurrentItemsMenu.Panel.SetActive(false);
            m_CurrentItemsMenu = _itemsMenu;
        }
        #endregion

        #region Time&co
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
        #endregion
    }
}
