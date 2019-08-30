using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsideABuildingState : StateBase
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        GoInside();
        cameraManager.Action_InsideOrNearBuildCamera();
    }

    override public void GoBack_KDown()
    {
        m_FSMManager.Act_InsideABuilding_GoBack();
    }

    private void GoInside()
    {
        Tabboz.transform.position = new Vector3(inputManager.SavedDoor.InsidePosition.x, Tabboz.transform.position.y, inputManager.SavedDoor.InsidePosition.z);
    }
}
