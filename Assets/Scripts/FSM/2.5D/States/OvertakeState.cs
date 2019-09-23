using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvertakeState : StateMachineBehaviour
{
    NPCMoveTest ThisNPC, OtherNPC;
    float _OvertSpeed;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ThisNPC = animator.transform.GetComponent<NPCMoveTest>();
        SaveOtherNPC();
        ThisNPC.Overtaking = true;
        _OvertSpeed = ThisNPC.configData.Speed /** 2*/;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ChangeZone();
        Move();
        LateralCheck();
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
        CheckDistance();
        ThisNPC.transform.Translate(new Vector3((ThisNPC.direction * _OvertSpeed), 0));        
    }

    private void LateralCheck()
    {
        float _distance, _MyPosXAbs, _OthPosXAbs;
        _MyPosXAbs = System.Math.Abs(ThisNPC.transform.position.x);
        _OthPosXAbs = System.Math.Abs(OtherNPC.transform.position.x);
        _distance = _MyPosXAbs - _OthPosXAbs;
        if (_distance > (ThisNPC.GetComponent<CapsuleCollider>().bounds.size.x + 0.5f))
        {
            ThisNPC.GetComponent<Animator>().SetTrigger("Overtaken");
        }
    }
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

    private void SaveOtherNPC()
    {
        RaycastHit _Hit;
        if(Physics.Raycast(ThisNPC.transform.position, new Vector3(ThisNPC.direction, 0), out _Hit, 5f))
        {
            if(_Hit.transform.GetComponent<NPCMoveTest>() != null)
            {
                OtherNPC = _Hit.transform.GetComponent<NPCMoveTest>();
            }
        }
    }
}
