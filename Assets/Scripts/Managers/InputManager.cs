using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Tabboz_3D
{
    public class InputManager : MonoBehaviour
    {
        public int WalkSpeed;
        public KeyCode LeftKey, RightKey, UpKey, DownKey, SubmitKey;
        public bool OnTheRoad, OutsideTheDoor, InsideABuilding;
        public bool InfrontOfTheGashaponMachine, InGashaponBoxView, InGashaponView;
        public List<Camera> Cameras = new List<Camera>();
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
        #endregion
        private void Update()
        {
            CheckInput();
        }

        private void CheckInput()
        {
            if (Input.GetKey(LeftKey))
            {
                LeftKeyCall();
            }
            if (Input.GetKeyDown(LeftKey))
            {
                LeftKeyDownCall();
            }
            if (Input.GetKey(RightKey))
            {
                RightKeyCall();
            }
            if (Input.GetKeyDown(RightKey))
            {
                RightKeyDownCall();
            }
            if (Input.GetKey(UpKey))
            {
                UpKeyCall();
            }
            if (Input.GetKeyDown(UpKey))
            {
                UpKeyDownCall();
            }
            if (Input.GetKey(DownKey))
            {
                DownKeyCall();
            }
            if (Input.GetKeyDown(DownKey))
            {
                DownKeyDownCall();
            }
            if (Input.GetKeyDown(SubmitKey))
            {
                SubmitKeyDownCall();
            }
        }
    } 
}