using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutsideTheDoorState : StateBase
{
    int _CurrentMeshIndex, _OldMeshIndex;
    Door _door;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        cameraManager.Action_InsideOrNearBuildCamera();
        _door = inputManager.SavedDoor;
        _CurrentMeshIndex = 0;
        SetOutline(_door.SelectableObjects[_OldMeshIndex], _door.SelectableObjects[_CurrentMeshIndex]);
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        SetOutline(_door.SelectableObjects[_CurrentMeshIndex], null);
        base.OnStateExit(animator, stateInfo, layerIndex);
    }

    override public void GoForward_KDown()
    {
        m_FSMManager.Act_OutsideTheDoor_GoForward();
    }
    override public void GoBack_KDown()
    {
        m_FSMManager.Act_OutsideTheDoor_GoBack();
    }
    public override void GoLeft_KDown()
    {
        UpdateSelectedMesh(-1);
    }
    public override void GoRight_KDown()
    {
        UpdateSelectedMesh(1);
    }

    private void UpdateSelectedMesh(int _indexMod)
    {
        _OldMeshIndex = _CurrentMeshIndex;
        if((_CurrentMeshIndex + _indexMod) < _door.SelectableObjects.Count && (_CurrentMeshIndex + _indexMod) >= 0)
        {
            _CurrentMeshIndex = _CurrentMeshIndex + _indexMod;
        }
        else if ((_CurrentMeshIndex + _indexMod) >= _door.SelectableObjects.Count)
        {
            _CurrentMeshIndex = 0;
        }
        else if ((_CurrentMeshIndex + _indexMod) < 0)
        {
            _CurrentMeshIndex = (_door.SelectableObjects.Count - 1);
        }
        SetOutline(_door.SelectableObjects[_OldMeshIndex], _door.SelectableObjects[_CurrentMeshIndex]);
    }

    private void SetOutline(MeshRenderer _OldMesh, MeshRenderer _CurrentMesh)
    {
        if(_OldMesh != null)
        {
            _OldMesh.material.SetFloat("_OutlineWidth", 1);
        }
        if (_CurrentMesh != null)
        {
            _CurrentMesh.material.SetFloat("_OutlineWidth", 1.1f);
        }
    }
}