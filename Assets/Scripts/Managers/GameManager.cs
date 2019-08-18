using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Bado_City;

public class GameManager : MonoBehaviour
{
    private Tabboz tabboz;
    public static GameManager MyGameManager = null;
    public GameObject TabbozMenu, Shops, Work, DiscoOut, DiscoIn, School, Girlfriend, Friends;
    public GameObject OutWtYrFriends, CallFriends, Race;
    public GameObject OutWtYrGf, CallYrGf, LeaveGf, LkngForGirlfriend;
    public GameObject LookingForAJob, QuitWork, FactoryInfo, Asslicker, AskSalaryIncrease, Strike;
    private Animator fsm;
    public TMP_Text Nome, Cognome, NomeTipa, RapportoConLaTipa, Soldi, Reputazione, Figosit, ProgittoScolastico, NomeMoto, StatoMoto;
    [HideInInspector]
    public DiscoShopConfigData DiscoShop;

    #region Actions
    public Action GoToTabbozMenu;
    public Action GoToShops;
    public Action GoToWork;
    public Action GoToSchool;
    public Action GoToFriends;
    public Action GoToDisco;
    public Action GoToGirlfriend;
    public Action GoToCallFriends;
    public Action GoToOutWtYrFriends;
    public Action GoToRace;
    public Action GoToOutWtYrGf;
    public Action GoToCallYrGf;
    public Action GoToLeaveGf;
    public Action GoToLkngForGirlfriend;
    public Action GoToLookingForAJob;
    public Action GoToQuitWork;
    public Action GoToFactoryInfo;
    public Action GoToAsslicker;
    public Action GoToAskSalaryIncrease;
    public Action GoToStrike;
    public Action GoToEnterTheDisco;
    #endregion
    #region delegates
    public delegate void MyDiscoShopDelegate(DiscoShopConfigData _shop);

    public MyDiscoShopDelegate SetDiscoDelegate;
    #endregion

    void Awake()
    {
        //Controlla se esite già
        if (MyGameManager == null)

            //Se no setta questo come MyGameManager
            MyGameManager = this;

        //Se invece esiste già e non è questo
        else if (MyGameManager != this)

            //Distrugge questo
            Destroy(gameObject);

        //Ci assicuriamo di non perderlo quando cambiamo scena
        DontDestroyOnLoad(gameObject);

        ActionsSubs();
        DelegatesSubs();
        fsm = GetComponent<Animator>();
        
        //Se non esiste un tabboz
        if(tabboz == null)
        {
            //Generiamo un nuovo tabboz
            tabboz = new Tabboz();
            tabboz.Init();
        }
    }

    /// <summary>
    /// Regitra tutti i metodi alle action
    /// </summary>
    private void ActionsSubs()
    {
        GoToTabbozMenu += SetToTabbozMenu;
        GoToTabbozMenu += UpdateTabbozMenuTexts;
        GoToShops += SetToShops;
        GoToWork += SetToWork;
        GoToSchool += SetToSchool;
        GoToFriends += SetToFriends;
        GoToDisco += SetToDisco;
        GoToGirlfriend += SetToGirlfriend;
        GoToCallFriends += SetToCallFriends;
        GoToOutWtYrFriends += SetToOutWtYrFriends;
        GoToRace += SetToRace;
        GoToOutWtYrGf += SetToOutWtYrGf;
        GoToCallYrGf += SetToCallYrGf;
        GoToLeaveGf += SetToLeaveGf;
        GoToLkngForGirlfriend += SetToLkngForGirlfriend;
        GoToLookingForAJob += SetToLookingForAJob;
        GoToQuitWork += SetToQuitWork;
        GoToFactoryInfo += SetToFactoryInfo;
        GoToAsslicker += SetToAsslicker;
        GoToAskSalaryIncrease += SetToAskSalaryIncrease;
        GoToStrike += SetToStrike;
        GoToEnterTheDisco += SetToEnterTheDisco;
    }    
    private void DelegatesSubs()
    {
        SetDiscoDelegate += SetDiscoShop;
    }
    /// <summary>
    /// Tutti i metodi che settano i trigger della FSM
    /// </summary>
    #region TriggerSet
    private void SetToTabbozMenu()
    {      
        fsm.SetTrigger("GoToTabbozMenu");
    }
    private void SetToShops()
    {
        fsm.SetTrigger("GoToShops");
    }
    private void SetToWork()
    {
        fsm.SetTrigger("GoToWork");
    }
    private void SetToSchool()
    {
        fsm.SetTrigger("GoToSchool");
    }
    private void SetToFriends()
    {
        fsm.SetTrigger("GoToFriends");
    }
    private void SetToDisco()
    {
        fsm.SetTrigger("GoToDisco");
    }
    private void SetToGirlfriend()
    {
        fsm.SetTrigger("GoToGirlfriend");
    }
    private void SetToCallFriends()
    {
        fsm.SetTrigger("GoToCallFriends");
    }
    private void SetToOutWtYrFriends()
    {
        fsm.SetTrigger("GoToOutWtYrFriends");
    }
    private void SetToRace()
    {
        fsm.SetTrigger("GoToRace");
    }
    private void SetToOutWtYrGf()
    {
        fsm.SetTrigger("GoToOutWtYrGf");
    }
    private void SetToCallYrGf()
    {
        fsm.SetTrigger("GoToCallYrGf");
    }
    private void SetToLeaveGf()
    {
        fsm.SetTrigger("GoToLeaveGf");
    }
    private void SetToLkngForGirlfriend()
    {
        fsm.SetTrigger("GoToLkngForGirlfriend");
    }
    private void SetToLookingForAJob()
    {
        fsm.SetTrigger("GoToLookingForAJob");
    }
    private void SetToQuitWork()
    {
        fsm.SetTrigger("GoToQuitWork");
    }
    private void SetToFactoryInfo()
    {
        fsm.SetTrigger("GoToFactoryInfo");
    }
    private void SetToAsslicker()
    {
        fsm.SetTrigger("GoToAsslicker");
    }
    private void SetToAskSalaryIncrease()
    {
        fsm.SetTrigger("GoToAskSalaryIncrease");
    }
    private void SetToStrike()
    {
        fsm.SetTrigger("GoToStrike");
    }
    private void SetToEnterTheDisco()
    {
        fsm.SetTrigger("GoToEnterTheDisco");
    }
    #endregion
    /// <summary>
    /// Set dei negozi
    /// </summary>
    #region ShopSet
    private void SetDiscoShop(DiscoShopConfigData _discoShop)
    {
        DiscoShop = _discoShop;
    }
    #endregion
    /// <summary>
    /// Aggiorna i testi del menu del tabboz
    /// </summary>
    private void UpdateTabbozMenuTexts()
    {
        Nome.text = tabboz.Nome;
        Cognome.text = tabboz.Cognome;
        // if(tipa != null...da fare classe tipa
        // NomeTipa = ....
        RapportoConLaTipa.text = (tabboz.RapportoConLaTipa.ToString() + "/100");
        Soldi.text = tabboz.Soldi.ToString();
        Reputazione.text = (tabboz.Reputazione.ToString() + "/100");
        Figosit.text = (tabboz.Figosit.ToString() + "/100");
        ProgittoScolastico.text = (tabboz.ProfittoScolastico.ToString() + "/100");
        if (tabboz.Bike != null)
        {
            NomeMoto.gameObject.SetActive(true);
            StatoMoto.gameObject.SetActive(true);
            NomeMoto.text = tabboz.Bike.Name;
            StatoMoto.text = (tabboz.Bike.Stato.ToString() + "/100");
        }
        else StatoMoto.gameObject.SetActive(false);
    }
}
