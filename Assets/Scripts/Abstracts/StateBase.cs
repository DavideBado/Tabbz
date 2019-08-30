using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateBase : StateMachineBehaviour, IStateInputCheck
{
    protected FSMManager m_FSMManager;
    protected CameraManager cameraManager;
    protected InputManager inputManager;
    protected GameObject Tabboz;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        inputManager = animator.GetComponent<InputManager>();
        cameraManager = inputManager.GetComponent<CameraManager>();
        m_FSMManager = inputManager.GetComponent<FSMManager>();
        Tabboz = inputManager.gameObject;
        inputManager.LeftKeyCall += GoLeft;
        inputManager.RightKeyCall += GoRight;
        inputManager.UpKeyCall += GoForward;
        inputManager.DownKeyCall += GoBack;
        inputManager.UpKeyDownCall += GoForward_KDown;
        inputManager.DownKeyDownCall += GoBack_KDown;
        inputManager.SubmitKeyDownCall += OnSubmit;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{

    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        inputManager.LeftKeyCall -= GoLeft;
        inputManager.RightKeyCall -= GoRight;
        inputManager.UpKeyCall -= GoForward;
        inputManager.DownKeyCall -= GoBack;
        inputManager.UpKeyDownCall -= GoForward_KDown;
        inputManager.DownKeyDownCall -= GoBack_KDown;
        inputManager.SubmitKeyDownCall -= OnSubmit;
    }

    public virtual void GoBack_KDown()
    {    

    }

    public virtual void GoForward_KDown()
    {

    }

    public virtual void GoLeft()
    {

    }

    public virtual void GoRight()
    {

    }

    public virtual void OnSubmit()
    {

    }

    public virtual void GoForward()
    {

    }

    public virtual void GoBack()
    {

    }
}
