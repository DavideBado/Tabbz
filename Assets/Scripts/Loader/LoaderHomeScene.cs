using UnityEngine;
using TMPro;
using Tabboz_Base;

namespace Tabboz_3D
{
    public class LoaderHomeScene : LoaderBase
    {
        public TMP_Text TimerTxt, DayNumTxt, DayNameTxt, MonthTxt;
        public GameObject ShopMenuPanel, ShopMenuContent, ShopMenuItemPref;
        public InventoryMenu InventoryPanel;

        public override void SetGameManager()
        {
            GameManager3D gameManager = GameManager3D.instance;
            gameManager.GameManagerSetup();
            gameManager.uIManager.Timer_txt = TimerTxt;
            gameManager.uIManager.Day_txt = DayNumTxt;
            gameManager.uIManager.WeekDay_txt = DayNameTxt;
            gameManager.uIManager.Month_txt = MonthTxt;
            gameManager.uIManager.ShopMenuPanel = ShopMenuPanel;
            gameManager.uIManager.ShopMenuContent = ShopMenuContent;
            gameManager.uIManager.ShopItemPref = ShopMenuItemPref;
            gameManager.uIManager.InventoryPanel = InventoryPanel;
            gameManager.InitManagers();
            OnLoaded();
        }
    } 
}