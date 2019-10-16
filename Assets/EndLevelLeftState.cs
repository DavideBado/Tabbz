using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tabboz_3D
{
    public class EndLevelLeftState : StateBase
    {
        LevelManager m_levelManager;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateEnter(animator, stateInfo, layerIndex);
            m_levelManager = GameManager3D.instance.levelManager;
        }

        public override void GoLeft()
        {
            m_levelManager.MySetLevelDelegate(m_levelManager.NextLevel_L);
            m_FSMManager.Act_LoadLevel();
        }

        public override void GoRight()
        {
            Tabboz.transform.Translate(Vector3.right * inputManager.WalkSpeed * Time.deltaTime);
            if (Tabboz.transform.position.x > m_levelManager.EndLevel_L)
                m_FSMManager.Act_EndLevelBack?.Invoke();
        }
    } 
}
