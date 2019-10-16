using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tabboz_3D
{
    public class EndLevelRightState : StateBase
    {
        LevelManager m_levelManager;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateEnter(animator, stateInfo, layerIndex);
            m_levelManager = GameManager3D.instance.levelManager;
        }

        public override void GoRight()
        {
            m_levelManager.MySetLevelDelegate(m_levelManager.NextLevel_R);
            m_FSMManager.Act_LoadLevel();
        }

        public override void GoLeft()
        {
            Tabboz.transform.Translate(Vector3.left * inputManager.WalkSpeed * Time.deltaTime);
            if (Tabboz.transform.position.x < m_levelManager.EndLevel_R)
                m_FSMManager.Act_EndLevelBack?.Invoke();
        }
    } 
}
