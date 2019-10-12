using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tabboz_3D
{
    public class OnGashaponMachineState : StateBase
    {
        // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateEnter(animator, stateInfo, layerIndex);
            cameraManager.Action_InsideOrNearBuildCamera();
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
        {
            TimeManager.UpdateTime?.Invoke();
        }

        override public void GoForward_KDown()
        {
            m_FSMManager.Act_OnGashaponMachine_GoForward();
        }
        override public void GoBack_KDown()
        {
            m_FSMManager.Act_OnGashaponMachine_GoBack();
        }
    } 
}