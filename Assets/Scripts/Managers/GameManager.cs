using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Tabboz_Base;

public class GameManager : MonoBehaviour
{
    public int CurrentSceneIndex, NextSceneIndex;
    public static GameManager MyGameManager = null;
    public Tabboz tabboz;
    public GameObject LoadingImage;
    [HideInInspector]
    public GameObject MainMenu, SettingsMenu, QuitPanel, CreditsPanel;
    [HideInInspector]
    public GameObject TabbozMenu, Shops, Work, DiscoOut, DiscoIn, School, Girlfriend, Friends;
    [HideInInspector]
    public GameObject OutWtYrFriends, CallFriends, Race;
    [HideInInspector]
    public GameObject OutWtYrGf, CallYrGf, LeaveGf, LkngForGirlfriend;
    [HideInInspector]
    public GameObject LookingForAJob, QuitWork, FactoryInfo, Asslicker, AskSalaryIncrease, Strike;
    [HideInInspector]
    public GameObject ClothingsOut, ClothesSIn;
    private Animator fsm;
    [HideInInspector]
    public TMP_Text Nome, Cognome, NomeTipa, RapportoConLaTipa, Soldi, Reputazione, Figosit, ProfittoScolastico, NomeMoto, StatoMoto;
    [HideInInspector]
    public DiscoShopConfigData DiscoShop;
    [HideInInspector]
    public ClothesShopConfigData ClothesShop;

    #region Actions
    public Action GoToLoading;
    public Action GoToMainMenu;
    public Action GoToQuit;
    public Action GoToSettings;
    public Action GoToCredits;
    public Action GoToGameplay;
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
    public Action GoToEnterTheClothingsShop;
    public Action GoToClothingsShop;
    #endregion
    #region Delegates
    public delegate void MyDiscoShopDelegate(DiscoShopConfigData _shop);
    public MyDiscoShopDelegate SetDiscoDelegate;
    public delegate void MyClothingsShopDelegate(ClothesShopConfigData _shop);
    public MyClothingsShopDelegate SetClothingDelegate;
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
        GoToTabbozMenu += UpdateTabbozMenuTextsAndImages;
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
        GoToEnterTheClothingsShop += SetToEnterTheClothingsShop;
        GoToClothingsShop += SetToClothingsShop;
        GoToLoading += SetToLoading;
        GoToGameplay += SetToGameplay;
        GoToGameplay += UpdateTabbozMenuTextsAndImages;
        GoToMainMenu += SetToMainMenu;
        GoToQuit += SetToQuit;
        GoToSettings += SetToSettings;
        GoToCredits += SetToCredits;
    }  
    private void DelegatesSubs()
    {
        SetDiscoDelegate += SetDiscoShop;
        SetClothingDelegate += SetClothingsShop;
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
    private void SetToClothingsShop()
    {
        fsm.SetTrigger("GoToClothingsShop");
    }
    private void SetToEnterTheClothingsShop()
    {
        fsm.SetTrigger("GoToEnterTheClothingsShop");
    }
    private void SetToLoading()
    {
        fsm.SetTrigger("GoToLoading");
    }
    private void SetToGameplay()
    {
        fsm.SetTrigger("GoToGameplay");
    }
    private void SetToMainMenu()
    {
        fsm.SetTrigger("GoToMainMenu");
    }
    private void SetToQuit()
    {
        fsm.SetTrigger("GoToQuit");
    }
    private void SetToSettings()
    {
        fsm.SetTrigger("GoToSettings");
    }
    private void SetToCredits()
    {
        fsm.SetTrigger("GoToCredits");
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
    private void SetClothingsShop(ClothesShopConfigData _clothingsShop)
    {
        ClothesShop = _clothingsShop;
    }
    #endregion
    /// <summary>
    /// Aggiorna i testi e le immagini del tabboz menu
    /// </summary>
    private void UpdateTabbozMenuTextsAndImages()
    {
        Nome.text = tabboz.Nome;
        Cognome.text = tabboz.Cognome;
        // if(tipa != null...da fare classe tipa
        // NomeTipa = ....
        RapportoConLaTipa.text = (tabboz.RapportoConLaTipa.ToString() + "/100");
        Soldi.text = tabboz.Soldi.ToString();
        Reputazione.text = (tabboz.Reputazione.ToString() + "/100");
        Figosit.text = (tabboz.Figosit.ToString() + "/100");
        ProfittoScolastico.text = (tabboz.ProfittoScolastico.ToString() + "/100");
        if (tabboz.Bike != null)
        {
            NomeMoto.gameObject.SetActive(true);
            StatoMoto.gameObject.SetActive(true);
            NomeMoto.text = tabboz.Bike.Name;
            StatoMoto.text = (tabboz.Bike.Stato.ToString() + "/100");
        }
        else StatoMoto.gameObject.SetActive(false);

        for (int i = 0; i < tabboz.clothings.Count; i++)
        {
            TabbozMenu.GetComponent<TabbozImageData>().Clothings[i].sprite = tabboz.clothings[i].Icon;
        }
    }
}
