using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Classe temporanea per gestione dello sfondo in base alle ore del giorno
/// </summary>
public class SkyManager : MonoBehaviour
{
    public Image SkyBar; 
    public int test;
    private float K = 21.25f; // Costante per gestire il cambiamento della percentuale di verde = 255/12h
    CameraManager cameraManager;
    TimeManager timeManager;

    private void Awake()
    {
        cameraManager = FindObjectOfType<CameraManager>(); // FindObj osceni da sostituire assolutamente appena avrò il tempo di impostare la struttura di init
        timeManager = FindObjectOfType<TimeManager>();
    }
    
    private void OnEnable()
    {
        timeManager.UpdateTime3h += UpdateColor;
    }
    private void OnDisable()
    {
        timeManager.UpdateTime3h -= UpdateColor;
    }
    private void UpdateColor()
    {
        Color SkyColor = new Color32(0, (byte)(255 - Mathf.Abs((timeManager._Hours * K) - 255)), 255, 50); // Sono le 3 di notte, è da rivedere
        RenderSettings.skybox.SetColor("_Tint", SkyColor);
        SkyBar.color = SkyColor;
    }
}
