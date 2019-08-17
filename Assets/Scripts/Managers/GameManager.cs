using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager MyGameManager = null;
    public GameObject TabbozMenu, Shops, Work, Disco;
    private Animator fsm;
    public List<Action> GameManagerActions = new List<Action>();

    #region Actions
    public Action GoToTabbozMenu;
    public Action GoToShops;
    public Action GoToWork;
    public Action GoToSchool;
    public Action GoToFriends;
    public Action GoToDisco;
    public Action GoToGirlfriend;
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
    }
    private void Start()
    {
        fsm = GetComponent<Animator>();
    }
    private void ActionsSubs()
    {
        GoToTabbozMenu += SetToTabbozMenu;
        GoToShops += SetToShops;
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
    }
    private void SetToTabbozMenu()
    {
        fsm.SetTrigger("GoToTabbozMenu");
    }
    private void SetToShops()
    {
        fsm.SetTrigger("GoToShops");
    }
}
