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
        public Tabboz tabboz;

        //Awake is always called before any Start functions
        void Awake()
        {            
            if (instance == null)
                instance = this;
            else if (instance != this)
                Destroy(gameObject);
            DontDestroyOnLoad(gameObject);
        }
        public void GameManagerSetup()
        {
            Init();
        }
        private void Init()
        {

        }
    } 
}
