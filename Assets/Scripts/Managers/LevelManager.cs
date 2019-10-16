using System;
using System.Collections.Generic;
using UnityEngine;

namespace Tabboz_3D
{
    public class LevelManager : MonoBehaviour // Manca interfaccia IManager
    {
        [HideInInspector]
        public float EndLevel_L, EndLevel_R;
        [HideInInspector]
        public int NextLevel_L, NextLevel_R; // Mah, pensare meglio come organizzare questi dati es. SceneManager

        #region DelegatesDef
        public delegate void SetLevelDelegate(int _LevelIndex);
        #endregion

        #region Delegates
        public SetLevelDelegate MySetLevelDelegate;
        #endregion

        public void Init()
        {
            MySetLevelDelegate += SetNextScene;
        }

        private void OnDisable()
        {
            MySetLevelDelegate -= SetNextScene;
        }

        private void SetNextScene(int _SceneIndex)
        {
            GameManager3D.instance.NextSceneIndex = _SceneIndex;
        }
    } 
}
