using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvertakeState : StateMachineBehaviour
{
    NPCMoveTest ThisNPC;
    float _OvertSpeed;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ThisNPC = animator.transform.GetComponent<NPCMoveTest>();
        ThisNPC.Overtaking = true;
        _OvertSpeed = ThisNPC.configData.Speed * 2;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ChangeZone();
        Move();
        //LateralCheck();
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ThisNPC.Overtaking = false;
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}

    private void ChangeZone()
    {
        if (ThisNPC.transform.position.z != ThisNPC.OvertakeZone.transform.position.z)
        {
            //Vector3.MoveTowards(ThisNPC.transform.position, new Vector3(ThisNPC.transform.position.x, ThisNPC.transform.position.y, ThisNPC.OvertakeZone.transform.position.z), _OvertSpeed * Time.deltaTime);
            ThisNPC.transform.position = new Vector3(ThisNPC.transform.position.x, ThisNPC.transform.position.y, ThisNPC.OvertakeZone.transform.position.z);
        }      
    }

    private void Move()
    {
        ThisNPC.transform.Translate(new Vector3((ThisNPC.direction * _OvertSpeed), 0));        
    }

    private void LateralCheck()
    {
        float _direction = ThisNPC.MyZone.transform.position.z - ThisNPC.transform.position.z;
        Debug.DrawRay(ThisNPC.transform.position, new Vector3(0, 0, _direction), Color.blue);
        RaycastHit _hit;
        if (!Physics.Raycast(ThisNPC.transform.position, new Vector3(0, 0, _direction), out _hit, 1.4f) || _hit.transform.GetComponent<NPCMoveTest>() == null)
        {
            ThisNPC.GetComponent<Animator>().SetTrigger("Overtaken");
        }
    }
}
