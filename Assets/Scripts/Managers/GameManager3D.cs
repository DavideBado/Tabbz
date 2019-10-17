using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tabboz_Base;

namespace Tabboz_3D
{
    public class GameManager3D : MonoBehaviour
    {
        [HideInInspector]
        public static GameManager3D instance = null;             
        [HideInInspector]
        public TimeManager timeManager;
        [HideInInspector]
        public InputManager inputManager;
        [HideInInspector]
        public CameraManager cameraManager;
        [HideInInspector]
        public DayManager dayManager;
        [HideInInspector]
        public FSMManager fSMManager;
        [HideInInspector]
        public UIManager uIManager;
        [HideInInspector]
        public SkyManager skyManager;
        [HideInInspector]
        public LevelManager levelManager;
        [HideInInspector]
        public Tabboz3D tabboz;
        public int CurrentSceneIndex, NextSceneIndex;

        //Awake is always called before any Start functions
        void Awake()
        {            
            if (instance == null)
                instance = this;
            else if (instance != this)
                Destroy(gameObject);
            DontDestroyOnLoad(gameObject);
            Init();
            //GameManagerSetup();
        }
        //public void GameManagerSetup()
        //{
        //    Init();
        //    //InitManagers();
        //}
        private void Init()
        {
            timeManager = GetComponentInChildren<TimeManager>();
            inputManager = GetComponentInChildren<InputManager>();
            cameraManager = GetComponentInChildren<CameraManager>();
            dayManager = GetComponentInChildren<DayManager>();
            fSMManager = GetComponentInChildren<FSMManager>();
            uIManager = GetComponentInChildren<UIManager>();
            skyManager = GetComponentInChildren<SkyManager>();
            levelManager = GetComponentInChildren<LevelManager>();
            tabboz = GetComponentInChildren<Tabboz3D>();
        }
        public void InitManagers()
        {
            inputManager.Init();
            fSMManager.Init();
            timeManager.Init();
            cameraManager.Init();
            dayManager.Init();
            skyManager.Init();
            uIManager.Init();            
            levelManager.Init();            
        }
    } 
}
