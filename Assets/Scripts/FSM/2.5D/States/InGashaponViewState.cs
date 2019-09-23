using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tabboz_3D
{
    public class InGashaponViewState : StateBase
    {
        // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateEnter(animator, stateInfo, layerIndex);
            SetTheGashapon();
            cameraManager.Action_POVCamera();
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            SaveTheGashapon();
            base.OnStateExit(animator, stateInfo, layerIndex);
        }
        public override void GoLeft()
        {
            inputManager.NewGashapon.transform.Rotate(Vector3.left * inputManager.GashaponRotationSpeed * Time.deltaTime);
        }
        public override void GoRight()
        {
            inputManager.NewGashapon.transform.Rotate(Vector3.right * inputManager.GashaponRotationSpeed * Time.deltaTime);
        }
        public override void GoForward()
        {
            inputManager.NewGashapon.transform.Rotate(Vector3.forward * inputManager.GashaponRotationSpeed * Time.deltaTime);
        }
        public override void GoBack()
        {
            inputManager.NewGashapon.transform.Rotate(Vector3.down * inputManager.GashaponRotationSpeed * Time.deltaTime);
        }
        public override void OnSubmit()
        {
            m_FSMManager.Act_GashaponView_Submit();
        }

        private void SetTheGashapon()
        {
            inputManager.NewGashapon = GameObject.Instantiate(inputManager.SavedGashaponMachine.BuyOne());
            inputManager.NewGashapon.transform.parent = inputManager.GashaponBox.transform;
            inputManager.NewGashapon.transform.SetPositionAndRotation(inputManager.GashaponBox.transform.position, Quaternion.identity);
            inputManager.GashaponBox.GetComponent<MeshRenderer>().enabled = false;
        }

        private void SaveTheGashapon()
        {
            Destroy(inputManager.NewGashapon); //Temporaneo, dovrà salvare il gasha
        }
    } 
}