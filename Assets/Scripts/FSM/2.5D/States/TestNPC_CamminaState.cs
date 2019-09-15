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
        CheckDistance(animator);
        UpdateNPCValues();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        MoveTheCharacter(animator);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    private void MoveTheCharacter(Animator _animator)
    {
        CheckDistance(_animator);
        Character.transform.Translate(new Vector3((Character.direction * Character.configData.Speed), 0));
    }

    private void CheckDistance(Animator _animator)
    {
        RaycastHit _hit;
        if(Physics.Raycast(Character.transform.position, new Vector3(Character.direction, 0), out _hit, 5f))
        {
            if(_hit.transform.GetComponent<NPCMoveTest>() != null)
            {
                float _distance = Vector3.Distance(Character.transform.position, _hit.transform.position);
                _animator.SetFloat("Distanza", _distance);
            }
        }
    }

    private void UpdateNPCValues()
    {
        if(Character.MyZone == null)
        {
            RaycastHit _hit;
            if(Physics.Raycast(Character.transform.position, Vector3.down, out _hit, 2f))
            {
                if (_hit.transform.GetComponent<ZonaPedonale>() != null)
                    Character.MyZone = _hit.transform.GetComponent<ZonaPedonale>();
            }
        }
    }
}

