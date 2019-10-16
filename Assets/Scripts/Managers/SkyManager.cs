using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Tabboz_Base;

/// <summary>
/// Classe temporanea per gestione dello sfondo in base alle ore del giorno
/// </summary>
namespace Tabboz_3D
{
    public class SkyManager : MonoBehaviour
    {
        private TimeManager timeManager;
        private CameraManager cameraManager;
        [HideInInspector]
        public Image SkyBar;
        public int test;
        private float K = 21.25f; // Costante per gestire il cambiamento della percentuale di verde = 255/12h
       
        public void Init()
        {
            cameraManager = GameManager3D.instance.cameraManager;
            timeManager = GameManager3D.instance.timeManager;
            timeManager.UpdateTime3h += UpdateColor;
        }

        //private void OnEnable()
        //{
        //    timeManager.UpdateTime3h += UpdateColor;
        //}
        //private void OnDisable()
        //{
        //    timeManager.UpdateTime3h -= UpdateColor;
        //}

        private void UpdateColor()
        {
            Color SkyColor = new Color32(0, (byte)(255 - Mathf.Abs((timeManager._Hours * K) - 255)), 255, 50); // Sono le 3 di notte, è da rivedere
            RenderSettings.skybox.SetColor("_Tint", SkyColor);
            if(SkyBar)
                SkyBar.color = SkyColor;
        }
    }
}