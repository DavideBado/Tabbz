using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Bado_City
{
    public class LoaderTabbozMenu : LoaderBase
    {
        public GameObject L_TabbozMenu, L_Shops, L_Work, L_DiscoOut, L_DiscoIn, L_School, L_Girlfriend, L_Friends;
        public GameObject L_OutWtYrFriends, L_CallFriends, L_Race;
        public GameObject L_OutWtYrGf, L_CallYrGf, L_LeaveGf, L_LkngForGirlfriend;
        public GameObject L_LookingForAJob, L_QuitWork, L_FactoryInfo, L_Asslicker, L_AskSalaryIncrease, L_Strike;
        public GameObject L_ClothingsOut, L_ClothesSIn;
        public TMP_Text L_Nome, L_Cognome, L_NomeTipa, L_RapportoConLaTipa, L_Soldi, L_Reputazione, L_Figosit, L_ProfittoScolastico, L_NomeMoto, L_StatoMoto;

        public override void SetGameManager()
        {
            GameManager.MyGameManager.TabbozMenu = L_TabbozMenu;
            GameManager.MyGameManager.Shops = L_Shops;
            GameManager.MyGameManager.Work = L_Work;
            GameManager.MyGameManager.DiscoOut = L_DiscoOut;
            GameManager.MyGameManager.School = L_School;
            GameManager.MyGameManager.Girlfriend = L_Girlfriend;
            GameManager.MyGameManager.Friends = L_Friends;
            GameManager.MyGameManager.OutWtYrFriends = L_OutWtYrFriends;
            GameManager.MyGameManager.CallFriends = L_CallFriends;
            GameManager.MyGameManager.Race = L_Race;
            GameManager.MyGameManager.OutWtYrGf = L_OutWtYrGf;
            GameManager.MyGameManager.CallYrGf = L_CallYrGf;
            GameManager.MyGameManager.LeaveGf = L_LeaveGf;
            GameManager.MyGameManager.LkngForGirlfriend = L_LkngForGirlfriend;
            GameManager.MyGameManager.LookingForAJob = L_LookingForAJob;
            GameManager.MyGameManager.QuitWork = L_QuitWork;
            GameManager.MyGameManager.FactoryInfo = L_FactoryInfo;
            GameManager.MyGameManager.Asslicker = L_Asslicker;
            GameManager.MyGameManager.AskSalaryIncrease = L_AskSalaryIncrease;
            GameManager.MyGameManager.Strike = L_Strike;
            GameManager.MyGameManager.ClothingsOut = L_ClothingsOut;
            GameManager.MyGameManager.ClothesSIn = L_ClothesSIn;
            GameManager.MyGameManager.Nome = L_Nome;
            GameManager.MyGameManager.Cognome = L_Cognome;
            GameManager.MyGameManager.NomeTipa = L_NomeTipa;
            GameManager.MyGameManager.RapportoConLaTipa = L_RapportoConLaTipa;
            GameManager.MyGameManager.Soldi = L_Soldi;
            GameManager.MyGameManager.Reputazione = L_Reputazione;
            GameManager.MyGameManager.Figosit = L_Figosit;
            GameManager.MyGameManager.ProfittoScolastico = L_ProfittoScolastico;
            GameManager.MyGameManager.NomeMoto = L_NomeMoto;
            GameManager.MyGameManager.StatoMoto = L_StatoMoto;
            OnLoaded();
        }
    }
}
