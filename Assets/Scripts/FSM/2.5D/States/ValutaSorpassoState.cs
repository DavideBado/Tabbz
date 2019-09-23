using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValutaSorpassoState : StateMachineBehaviour
{
    ZonaPedonale _OvertakeZone;
    NPCMoveTest ThisNPC;
    private List<ZonaPedonale> _ZonePedonali = new List<ZonaPedonale>();
    private List<NPCMoveTest> _others = new List<NPCMoveTest>();
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ThisNPC = animator.transform.GetComponent<NPCMoveTest>();
        ZoneCheck();
        CheckDistance();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

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

    private void ZoneCheck()
    {
        List<Quaternion> _Rotations = new List<Quaternion>();
        Quaternion rotation1 = Quaternion.AngleAxis(45.0f, ThisNPC.transform.right);
        _Rotations.Add(rotation1);
        Quaternion rotation2 = Quaternion.AngleAxis(135.0f, ThisNPC.transform.right);
        _Rotations.Add(rotation2);
        Debug.DrawRay(ThisNPC.transform.position, rotation1 * ThisNPC.transform.forward * 4, Color.red);
        Debug.DrawRay(ThisNPC.transform.position, rotation2 * ThisNPC.transform.forward * 4, Color.red);
        foreach (Quaternion _rotation in _Rotations)
        {
            RaycastHit _hit;
            if(Physics.Raycast(ThisNPC.transform.position, _rotation * ThisNPC.transform.forward * 4, out _hit, 10f))
            {
                if(_hit.transform.GetComponent<ZonaPedonale>() != null)
                {
                    _ZonePedonali.Add(_hit.transform.GetComponent<ZonaPedonale>());
                }
            }
        }
        foreach (ZonaPedonale _zona in _ZonePedonali)
        {
            LateralCheck(_zona);
        }
        
    }
    private void LateralCheck(ZonaPedonale _zona)
    {
        float _direction = _zona.transform.position.z - ThisNPC.transform.position.z;
        Debug.DrawRay(ThisNPC.transform.position, new Vector3(0, 0, _direction), Color.blue);
        RaycastHit _hit;
        if (!Physics.Raycast(ThisNPC.transform.position, new Vector3(0, 0, _direction), out _hit, 1.4f) || _hit.transform.GetComponent<NPCMoveTest>() == null)
        {
            ForwNBackCheck(_zona);
        }
    }
    private void ForwNBackCheck(ZonaPedonale _zona)
    {
        _OvertakeZone = _zona;
        Vector3 RayStartPos = new Vector3(_zona.transform.position.x, ThisNPC.transform.position.y, _zona.transform.position.z);
        Debug.DrawRay(RayStartPos, Vector3.left * 50, Color.green);
        Debug.DrawRay(RayStartPos, Vector3.right * 50, Color.green);
        RaycastHit _hit;
        if (Physics.Raycast(RayStartPos, Vector3.left, out _hit, 50f))
        {
            if (_hit.transform.GetComponent<NPCMoveTest>() != null)
            {
                _others.Add(_hit.transform.GetComponent<NPCMoveTest>());
            }
        }
        if (Physics.Raycast(RayStartPos, Vector3.right, out _hit, 50f))
        {
            if (_hit.transform.GetComponent<NPCMoveTest>() != null)
            {
                _others.Add(_hit.transform.GetComponent<NPCMoveTest>());
            }
        }
        if (_others.Count == 0)
            CheckOvertake(null);
        else
            foreach (NPCMoveTest _other in _others)
            {
                CheckOvertake(_other);
            }
    }
    private void CheckOvertake(NPCMoveTest _other)
    {
        if (_other != null)
        {
            float _distance = Vector3.Distance(ThisNPC.transform.position, _other.transform.position);
            if ((_distance > 5f && !_other.Overtaking) || _other.direction == ThisNPC.direction)
            {
                ThisNPC.OvertakeZone = _OvertakeZone;
                ThisNPC.GetComponent<Animator>().SetBool("CanOvertake", true);
            }
        }
        else
        {
            ThisNPC.OvertakeZone = _OvertakeZone;
            ThisNPC.GetComponent<Animator>().SetBool("CanOvertake", true);
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
}
