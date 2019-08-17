﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Bado_City;

public class GameManager : MonoBehaviour
{
    private Tabboz tabboz;
    public static GameManager MyGameManager = null;
    public GameObject TabbozMenu, Shops, Work, Disco, School, Girlfriend, Friends;
    public GameObject OutWtYrFriends, CallFriends, Race;
    public GameObject OutWtYrGf, CallYrGf, LeaveGf, LkngForGirlfriend;
    private Animator fsm;
    public List<Action> GameManagerActions = new List<Action>();
    public TMP_Text Nome, Cognome, NomeTipa, RapportoConLaTipa, Soldi, Reputazione, Figosit, ProgittoScolastico, NomeMoto, StatoMoto;

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
    #endregion

    void Awake()
    {
        //Check if instance already exists
        if (MyGameManager == null)

            //if not, set instance to this
            MyGameManager = this;

        //If instance already exists and it's not this:
        else if (MyGameManager != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

        ActionsSubs();
        ActionsToList();

        if(tabboz == null)
        {
            tabboz = new Tabboz();
            tabboz.Init();
        }
    }
    private void Start()
    {
        fsm = GetComponent<Animator>();
    }
    private void ActionsSubs()
    {
        GoToTabbozMenu += SetToTabbozMenu;
        //GoToTabbozMenu += UpdateTexts; Devo sistemare gli eventi in Inspector, il sistema attuale del cazzo non permette più metodi su un evento
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
    }
    private void ActionsToList()
    {
        GameManagerActions.Add(GoToTabbozMenu);
        GameManagerActions.Add(GoToShops);
        GameManagerActions.Add(GoToWork);
        GameManagerActions.Add(GoToSchool);
        GameManagerActions.Add(GoToFriends);
        GameManagerActions.Add(GoToDisco);
        GameManagerActions.Add(GoToGirlfriend);
        GameManagerActions.Add(GoToCallFriends);
        GameManagerActions.Add(GoToOutWtYrFriends);
        GameManagerActions.Add(GoToRace);
        GameManagerActions.Add(GoToOutWtYrGf);
        GameManagerActions.Add(GoToCallYrGf);
        GameManagerActions.Add(GoToLeaveGf);
        GameManagerActions.Add(GoToLkngForGirlfriend);
    }
    private void SetToTabbozMenu()
    {
        UpdateTexts();
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

    private void UpdateTexts()
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
