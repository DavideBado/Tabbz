using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrenaState : StateMachineBehaviour
{
    NPCMoveTest ThisNPC;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ThisNPC = animator.transform.GetComponent<NPCMoveTest>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        CheckDistance();
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    private void CheckDistance()
    {
        RaycastHit _hit;
        if (Physics.Raycast(ThisNPC.transform.position, new Vector3(ThisNPC.direction, 0), out _hit, 5f))
        {
            if (_hit.transform.GetComponent<NPCMoveTest>() != null)
            {
                float _distance = Vector3.Distance(ThisNPC.transform.position, _hit.transform.position);
                ThisNPC.GetComponent<Animator>().SetFloat("Distanza", _distance);
            }
        }
    }
}
