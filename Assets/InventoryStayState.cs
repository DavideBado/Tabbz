using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tabboz_3D
{
    public class InventoryStayState : StateBase
    {
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateEnter(animator, stateInfo, layerIndex);
            inputManager.InventoryKeyDownCall += InventoryKeyDown;
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            inputManager.InventoryKeyDownCall -= InventoryKeyDown;
            base.OnStateExit(animator, stateInfo, layerIndex);
        }

        private void InventoryKeyDown()
        {
            m_FSMManager.Act_ToInventory?.Invoke();
        }
    }
}