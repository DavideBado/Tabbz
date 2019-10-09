using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Tabboz_3D
{
    public class InputManager : MonoBehaviour
    {
        public int WalkSpeed;//Da spostare
        public KeyCode LeftKey, RightKey, UpKey, DownKey, SubmitKey, InventoryKey;
        public bool OnTheRoad, OutsideTheDoor, InsideABuilding;
        public bool InfrontOfTheGashaponMachine, InGashaponBoxView, InGashaponView;
        public List<Camera> Cameras = new List<Camera>();//Da spostare
        public float OutsideSavedPosX; //Da spostare
        public Door SavedDoor; //Da spostare
        public GashaponMachine SavedGashaponMachine; //Da spostare
        public GameObject GashaponBox; //Da spostare
        public List<Material> GashaponBox_Materials = new List<Material>();//Da spostare
        public float GashaponRotationSpeed;//Da spostare
        [HideInInspector]
        public GameObject NewGashapon;//Da spostare

        #region Actions
        public Action LeftKeyCall;
        public Action RightKeyCall;
        public Action LeftKeyDownCall;
        public Action RightKeyDownCall;
        public Action UpKeyDownCall;
        public Action DownKeyDownCall;
        public Action UpKeyCall;
        public Action DownKeyCall;
        public Action SubmitKeyDownCall;
        public Action InventoryKeyDownCall;
        #endregion

        public void Init()
        {

        }

        private void Update()
        {
            CheckInput();
        }

        private void CheckInput()
        {
            if (Input.GetKey(LeftKey))
            {
                LeftKeyCall?.Invoke();
            }
            if (Input.GetKeyDown(LeftKey))
            {
                LeftKeyDownCall?.Invoke();
            }
            if (Input.GetKey(RightKey))
            {
                RightKeyCall?.Invoke();
            }
            if (Input.GetKeyDown(RightKey))
            {
                RightKeyDownCall?.Invoke();
            }
            if (Input.GetKey(UpKey))
            {
                UpKeyCall?.Invoke();
            }
            if (Input.GetKeyDown(UpKey))
            {
                UpKeyDownCall?.Invoke();
            }
            if (Input.GetKey(DownKey))
            {
                DownKeyCall?.Invoke();
            }
            if (Input.GetKeyDown(DownKey))
            {
                DownKeyDownCall?.Invoke();
            }
            if (Input.GetKeyDown(SubmitKey))
            {
                SubmitKeyDownCall?.Invoke();
            }
            if (Input.GetKeyDown(InventoryKey))
            {
                InventoryKeyDownCall?.Invoke();
            }
        }
    } 
}