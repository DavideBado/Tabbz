using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FSMManager : MonoBehaviour
{
    Animator FSM;
    #region Triggers srings
    public string To_OutsideTheDoor_Trigger;
    public string To_GashaponMachine_Trigger;
    public string To_OnTheRoad_Trigger;
    public string To_InsideABuilding_Trigger;
    public string To_InGashaponBoxView_Trigger;
    public string To_InGashaponView_Trigger;
    #endregion

    #region Actions
    public Action Act_OnTheRoad_DetectDoor;
    public Action Act_OnTheRoad_DetectGashaMachine;
    public Action Act_OutsideTheDoor_GoBack;
    public Action Act_OutsideTheDoor_GoForward;
    public Action Act_InsideABuilding_GoBack;
    public Action Act_InsideAShopMenu_GoBack;
    public Action Act_OnGashaponMachine_GoForward;
    public Action Act_OnGashaponMachine_GoBack;
    public Action Act_GashaponBoxView_Submit;
    public Action Act_GashaponView_Submit;
    #endregion

    #region DelegatesDef
    public delegate void MyCheckShopDelegate(ShopBase _shop);
    #endregion

    #region Delegates
    public MyCheckShopDelegate CheckShopOpenDelegate;
    public MyCheckShopDelegate OpenMenuShopDelegate;
    #endregion
    private void Awake()
    {
        FSM = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        ActSub();
        DelegSub();
    }
    private void OnDisable()
    {
        ActUnsub();
        DelegUnsub();
    }
    private void ActSub()
    {
        Act_OnTheRoad_DetectDoor += SetTo_OutsideTheDoor_Trigger;
        Act_OnTheRoad_DetectGashaMachine += SetTo_GashaponMachine_Trigger;
        Act_OutsideTheDoor_GoBack += SetTo_OnTheRoad_Trigger;
        Act_OutsideTheDoor_GoForward += SetTo_InsideABuilding_Trigger;
        Act_InsideABuilding_GoBack += SetTo_OnTheRoad_Trigger;
        Act_OnGashaponMachine_GoForward += SetTo_InGashaponBoxView_Trigger;
        Act_OnGashaponMachine_GoBack += SetTo_OnTheRoad_Trigger;
        Act_GashaponBoxView_Submit += SetTo_InGashaponView_Trigger;
        Act_GashaponView_Submit += SetTo_GashaponMachine_Trigger;
    }
    private void ActUnsub()
    {
        Act_OnTheRoad_DetectDoor -= SetTo_OutsideTheDoor_Trigger;
        Act_OnTheRoad_DetectGashaMachine -= SetTo_GashaponMachine_Trigger;
        Act_OutsideTheDoor_GoBack -= SetTo_OnTheRoad_Trigger;
        Act_OutsideTheDoor_GoForward -= SetTo_InsideABuilding_Trigger;
        Act_InsideABuilding_GoBack -= SetTo_OnTheRoad_Trigger;
        Act_OnGashaponMachine_GoForward += SetTo_InGashaponBoxView_Trigger;
        Act_OnGashaponMachine_GoBack -= SetTo_OnTheRoad_Trigger;
        Act_GashaponBoxView_Submit -= SetTo_InGashaponView_Trigger;
        Act_GashaponView_Submit -= SetTo_GashaponMachine_Trigger;
    }
    private void DelegSub()
    {
        CheckShopOpenDelegate += CheckShopOpen;
    }
    private void DelegUnsub()
    {
        CheckShopOpenDelegate -= CheckShopOpen;
    }

    #region TriggerSetMet
    private void SetTo_OutsideTheDoor_Trigger()
    {
        FSM.SetTrigger(To_OutsideTheDoor_Trigger);
    }
    private void SetTo_GashaponMachine_Trigger()
    {
        FSM.SetTrigger(To_GashaponMachine_Trigger);
    }
    private void SetTo_OnTheRoad_Trigger()
    {
        FSM.SetTrigger(To_OnTheRoad_Trigger);
    }
    private void SetTo_InsideABuilding_Trigger()
    {
        FSM.SetTrigger(To_InsideABuilding_Trigger);
    }
    private void SetTo_InGashaponBoxView_Trigger()
    {
        FSM.SetTrigger(To_InGashaponBoxView_Trigger);
    }
    private void SetTo_InGashaponView_Trigger()
    {
        FSM.SetTrigger(To_InGashaponView_Trigger);
    }
    #endregion

    private void CheckShopOpen(ShopBase _shop)
    {
        if (_shop.IsOpen)
            SetTo_InsideABuilding_Trigger();
    }
}
