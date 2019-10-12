using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tabboz_3D
{
    public class InsideABuildingState : StateBase
    {
        int _CurrentMeshIndex, _OldMeshIndex;
        ShopBase _Shop;
        // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateEnter(animator, stateInfo, layerIndex);
            GoInside();
            cameraManager.Action_InsideOrNearBuildCamera();
            _Shop = inputManager.SavedDoor.Shop;
            _CurrentMeshIndex = 0;
            SetOutline(_Shop.SelectableObjects[_OldMeshIndex], _Shop.SelectableObjects[_CurrentMeshIndex]);
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
        {
            TimeManager.UpdateTime?.Invoke();
        }
        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            SetOutline(_Shop.SelectableObjects[_CurrentMeshIndex], null);
            _CurrentMeshIndex = 0;
            _OldMeshIndex = 0;
            base.OnStateExit(animator, stateInfo, layerIndex);
        }

        public override void GoForward_KDown()
        {
            m_FSMManager.OpenMenuShopDelegate(_Shop);
        }
        override public void GoBack_KDown()
        {
            m_FSMManager.Act_InsideABuilding_GoBack();
            m_FSMManager.Act_InsideAShopMenu_GoBack();
        }
        public override void GoLeft_KDown()
        {
            UpdateSelectedMesh(-1);
        }
        public override void GoRight_KDown()
        {
            UpdateSelectedMesh(1);
        }


        private void GoInside()
        {
            Tabboz.transform.position = new Vector3(inputManager.SavedDoor.InsidePosition.x, Tabboz.transform.position.y, inputManager.SavedDoor.InsidePosition.z);
        }

        private void UpdateSelectedMesh(int _indexMod)
        {
            _OldMeshIndex = _CurrentMeshIndex;
            if ((_CurrentMeshIndex + _indexMod) < _Shop.SelectableObjects.Count && (_CurrentMeshIndex + _indexMod) >= 0)
            {
                _CurrentMeshIndex = _CurrentMeshIndex + _indexMod;
            }
            else if ((_CurrentMeshIndex + _indexMod) >= _Shop.SelectableObjects.Count)
            {
                _CurrentMeshIndex = 0;
            }
            else if ((_CurrentMeshIndex + _indexMod) < 0)
            {
                _CurrentMeshIndex = (_Shop.SelectableObjects.Count - 1);
            }
            SetOutline(_Shop.SelectableObjects[_OldMeshIndex], _Shop.SelectableObjects[_CurrentMeshIndex]);
        }

        private void SetOutline(MeshRenderer _OldMesh, MeshRenderer _CurrentMesh)
        {
            if (_OldMesh != null)
            {
                _OldMesh.material.SetFloat("_OutlineWidth", 1);
            }
            if (_CurrentMesh != null)
            {
                _CurrentMesh.material.SetFloat("_OutlineWidth", 1.1f);
            }
        }
    } 
}