using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tabboz_3D
{
    public class OnTheRoadState : StateBase
    {
        // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateEnter(animator, stateInfo, layerIndex);
            SetPosition();
            cameraManager.Action_OnTheRoadCamera();
            inputManager.InventoryKeyDownCall += InventoryKeyDown;
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            SavePosition();
            inputManager.InventoryKeyDownCall -= InventoryKeyDown;
            base.OnStateExit(animator, stateInfo, layerIndex);
        }

        override public void GoLeft()
        {
            Tabboz.transform.Translate(Vector3.left * inputManager.WalkSpeed * Time.deltaTime);
        }

        override public void GoRight()
        {
            Tabboz.transform.Translate(Vector3.right * inputManager.WalkSpeed * Time.deltaTime);
        }

        override public void GoForward_KDown()
        {
            RaycastHit hit;
            if (Physics.Raycast(Tabboz.transform.position, Vector3.forward, out hit, 5f))
            {
                if (hit.transform.GetComponent<Door>() != null)
                {
                    SaveTheDoor(hit);
                    m_FSMManager.Act_OnTheRoad_DetectDoor();
                }
                else if (hit.transform.GetComponent<GashaponMachine>() != null)
                {
                    SaveGashaponMachine(hit);
                    m_FSMManager.Act_OnTheRoad_DetectGashaMachine();
                }
            }
        }
        private void SavePosition()
        {
            inputManager.OutsideSavedPosX = Tabboz.transform.position.x;
        }
        private void SaveTheDoor(RaycastHit _hit)
        {
            inputManager.SavedDoor = _hit.transform.GetComponent<Door>();
        }
        private void SaveGashaponMachine(RaycastHit _hit)
        {
            inputManager.SavedGashaponMachine = _hit.transform.GetComponent<GashaponMachine>();
        }

        private void SetPosition()
        {
            Tabboz.transform.position = new Vector3(inputManager.OutsideSavedPosX, Tabboz.transform.position.y, 1.5f);
        }

        private void InventoryKeyDown()
        {
            m_FSMManager.Act_ToInventory?.Invoke();
        }
    } 
}