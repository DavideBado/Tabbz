using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bado_City
{
    public class LoaderMainMenu : LoaderBase
    {
        public GameObject L_MainMenu, L_SettingsMenu, L_QuitPanel, L_CreditsPanel;
        public override void SetGameManager()
        {
            GameManager.MyGameManager.MainMenu = L_MainMenu;
            GameManager.MyGameManager.SettingsMenu = L_SettingsMenu;
            GameManager.MyGameManager.QuitPanel = L_QuitPanel;
            GameManager.MyGameManager.CreditsPanel = L_CreditsPanel;
            OnLoaded();
        }
    }
}
