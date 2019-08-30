using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGashaponBoxViewState : StateBase
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        SetTheBox();
        cameraManager.Action_POVCamera();
    }

    public override void GoLeft()
    {
        inputManager.GashaponBox.transform.Rotate(Vector3.left * inputManager.GashaponRotationSpeed * Time.deltaTime);
    }
    public override void GoRight()
    {
        inputManager.GashaponBox.transform.Rotate(Vector3.right * inputManager.GashaponRotationSpeed * Time.deltaTime);
    }
    public override void GoForward()
    {
        inputManager.GashaponBox.transform.Rotate(Vector3.forward * inputManager.GashaponRotationSpeed * Time.deltaTime);
    }
    public override void GoBack()
    {
        inputManager.GashaponBox.transform.Rotate(Vector3.down * inputManager.GashaponRotationSpeed * Time.deltaTime);
    }
    public override void OnSubmit()
    {
        m_FSMManager.Act_GashaponBoxView_Submit();
    }

    private void SetTheBox()
    {
        inputManager.GashaponBox.SetActive(true);
        inputManager.GashaponBox.GetComponent<MeshRenderer>().enabled = true;
        inputManager.GashaponBox.GetComponent<MeshRenderer>().material = inputManager.GashaponBox_Materials[UnityEngine.Random.Range(0, inputManager.GashaponBox_Materials.Count)];
    }
}
