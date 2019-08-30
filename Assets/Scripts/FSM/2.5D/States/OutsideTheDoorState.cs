using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutsideTheDoorState : StateBase
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        cameraManager.Action_InsideOrNearBuildCamera();
    }
   
    override public void GoForward_KDown()
    {
        m_FSMManager.Act_OutsideTheDoor_GoForward();
    }
    override public void GoBack_KDown()
    {
        m_FSMManager.Act_OutsideTheDoor_GoBack();
    }    
}