using UnityEngine;
using TMPro;
using Tabboz_Base;

namespace Tabboz_3D
{
    public class LoaderWorkScene : LoaderBase
    {
        public TMP_Text TimerTxt, DayNumTxt, DayNameTxt, MonthTxt;
        public GameObject ShopMenuPanel, ShopMenuContent, ShopMenuItemPref;
        public InventoryMenu InventoryPanel;
        public Transform EndLevel_L, EndLevel_R;

        public override void SetGameManager()
        {
            GameManager3D gameManager = GameManager3D.instance;
            gameManager.uIManager.Timer_txt = TimerTxt;
            gameManager.uIManager.Day_txt = DayNumTxt;
            gameManager.uIManager.WeekDay_txt = DayNameTxt;
            gameManager.uIManager.Month_txt = MonthTxt;
            gameManager.uIManager.ShopMenuPanel = ShopMenuPanel;
            gameManager.uIManager.ShopMenuContent = ShopMenuContent;
            gameManager.uIManager.ShopItemPref = ShopMenuItemPref;
            gameManager.uIManager.InventoryPanel = InventoryPanel;
            gameManager.levelManager.EndLevel_L = EndLevel_L.position.x;
            gameManager.levelManager.EndLevel_R = EndLevel_R.position.x;
            gameManager.levelManager.NextLevel_L = (int)EndLevel_L.position.y;
            gameManager.levelManager.NextLevel_R = (int)EndLevel_R.position.y;
            OnLoaded();
        }
    } 
}