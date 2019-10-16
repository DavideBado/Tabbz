﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Tabboz_3D
{
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
        public string To_InventoryOpenClose_Trigger;
        public string To_InventoryStay_Trigger;
        public string To_EndLevelLeft_Trigger;
        public string To_EndLevelRight_Trigger;
        public string To_LoadLevel_Trigger;
        #endregion

        #region Actions
        public Action Act_StartGame;
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
        public Action Act_ToInventory;
        public Action Act_InventoryOn;
        public Action Act_InventoryOff;
        public Action Act_EndLevelLeft;
        public Action Act_EndLevelRight;
        public Action Act_EndLevelBack;
        public Action Act_LoadLevel;
        #endregion

        #region DelegatesDef
        public delegate void MyCheckShopDelegate(ShopBase _shop);
        public delegate void MyCheckSelectionDelegate(Selectable _selectableobj);
        #endregion

        #region Delegates
        public MyCheckShopDelegate CheckShopOpenDelegate;
        public MyCheckShopDelegate OpenMenuShopDelegate;
        public MyCheckSelectionDelegate CheckSelectionDelegate;
        #endregion
        private void Awake()
        {
            FSM = GetComponent<Animator>();
        }
        public void Init()
        {
            ActSub();
            DelegSub();
        }

        //private void OnEnable()
        //{
        //    ActSub();
        //    DelegSub();
        //}
        private void OnDisable()
        {
            ActUnsub();
            DelegUnsub();
        }
        private void ActSub()
        {
            Act_StartGame += SetTo_OnTheRoad_Trigger;
            Act_OnTheRoad_DetectDoor += SetTo_OutsideTheDoor_Trigger;
            Act_OnTheRoad_DetectGashaMachine += SetTo_GashaponMachine_Trigger;
            Act_OutsideTheDoor_GoBack += SetTo_OnTheRoad_Trigger;
            //Act_OutsideTheDoor_GoForward += SetTo_InsideABuilding_Trigger;
            Act_InsideABuilding_GoBack += SetTo_OnTheRoad_Trigger;
            Act_OnGashaponMachine_GoForward += SetTo_InGashaponBoxView_Trigger;
            Act_OnGashaponMachine_GoBack += SetTo_OnTheRoad_Trigger;
            Act_GashaponBoxView_Submit += SetTo_InGashaponView_Trigger;
            Act_GashaponView_Submit += SetTo_GashaponMachine_Trigger;
            Act_ToInventory += SetTo_InventoryOpenClose_Trigger;
            Act_InventoryOn += SetTo_InventoryStay_Trigger;
            Act_InventoryOff += SetTo_OnTheRoad_Trigger;
            Act_EndLevelLeft += SetTo_EndLevelLeft_Trigger;
            Act_EndLevelRight += SetTo_EndLevelRight_Trigger;
            Act_EndLevelBack += SetTo_OnTheRoad_Trigger;
            Act_LoadLevel += SetTo_LoadLevel_Trigger;
        }
        private void ActUnsub()
        {
            Act_StartGame -= SetTo_OnTheRoad_Trigger;
            Act_OnTheRoad_DetectDoor -= SetTo_OutsideTheDoor_Trigger;
            Act_OnTheRoad_DetectGashaMachine -= SetTo_GashaponMachine_Trigger;
            Act_OutsideTheDoor_GoBack -= SetTo_OnTheRoad_Trigger;
            //Act_OutsideTheDoor_GoForward -= SetTo_InsideABuilding_Trigger;
            Act_InsideABuilding_GoBack -= SetTo_OnTheRoad_Trigger;
            Act_OnGashaponMachine_GoForward -= SetTo_InGashaponBoxView_Trigger;
            Act_OnGashaponMachine_GoBack -= SetTo_OnTheRoad_Trigger;
            Act_GashaponBoxView_Submit -= SetTo_InGashaponView_Trigger;
            Act_GashaponView_Submit -= SetTo_GashaponMachine_Trigger;
            Act_ToInventory -= SetTo_InventoryOpenClose_Trigger;
            Act_InventoryOn -= SetTo_InventoryStay_Trigger;
            Act_InventoryOff -= SetTo_OnTheRoad_Trigger;
            Act_EndLevelLeft -= SetTo_EndLevelLeft_Trigger;
            Act_EndLevelRight -= SetTo_EndLevelRight_Trigger;
            Act_EndLevelBack -= SetTo_OnTheRoad_Trigger;
            Act_LoadLevel -= SetTo_LoadLevel_Trigger;
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
        private void SetTo_InventoryOpenClose_Trigger()
        {
            FSM.SetTrigger(To_InventoryOpenClose_Trigger);
        }
        private void SetTo_InventoryStay_Trigger()
        {
            FSM.SetTrigger(To_InventoryStay_Trigger);
        }
        private void SetTo_EndLevelLeft_Trigger()
        {
            FSM.SetTrigger(To_EndLevelLeft_Trigger);
        }
        private void SetTo_EndLevelRight_Trigger()
        {
            FSM.SetTrigger(To_EndLevelRight_Trigger);
        }
        private void SetTo_LoadLevel_Trigger()
        {
            FSM.SetTrigger(To_LoadLevel_Trigger);
        }
        #endregion

        private void CheckShopOpen(ShopBase _shop)
        {
            if (_shop.IsOpen)
                SetTo_InsideABuilding_Trigger();
        }

        private void SetTriggerToSelection(Selectable _selectableobj)
        {
            switch (_selectableobj.Type)
            {
                case Selectable.SelectableType.Door:
                    SetTo_InsideABuilding_Trigger();
                    break;
                case Selectable.SelectableType.Shop:
                    break;
                case Selectable.SelectableType.Bed:
                    break;
                case Selectable.SelectableType.Computer:
                    break;
                case Selectable.SelectableType.CosoOrari:
                    break;
                default:
                    break;
            }
        }
    }
}
