using UnityEngine;
using Tabboz_3D;

public class OpenCloseInventoryState : StateBase
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        UIManager m_uIManager = GameManager3D.instance.uIManager;
        m_uIManager.InventoryOnOff();
        if (m_uIManager.InventoryPanel.gameObject.activeSelf)
            m_FSMManager.Act_InventoryOn();
        else
            m_FSMManager.Act_InventoryOff();
    }
}