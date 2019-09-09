using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestNPC_CamminaState : StateMachineBehaviour
{
    NPCMoveTest Character;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Character = animator.GetComponent<NPCMoveTest>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        MoveTheCharacter();
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    private void MoveTheCharacter()
    {
        Character.transform.Translate(new Vector3((Character.direction * Character.configData.Speed), 0));
        CheckDistance();
    }

    private void CheckDistance()
    {

    }
}

