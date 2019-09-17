using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bado_City;

public class ShopBase : MonoBehaviour
{
    [HideInInspector]
    public bool IsOpen;
    public MeshRenderer OpnClsPanel;
    public ShopConfigData ShopData;
    public TimeManager timeManager;
    public DayManager dayManager;
    public List<MeshRenderer> SelectableObjects = new List<MeshRenderer>();

    private void OnEnable()
    {
        timeManager.UpdateTime1h += OpenCheck;
    }

    private void OnDisable()
    {
        timeManager.UpdateTime1h -= OpenCheck;        
    }
    private void OpenCheck()
    {
        if (ShopData != null)
        {
            foreach (int _day in ShopData.WorkingDays)
            {
                if(_day == (dayManager.currentWeekDay + 1))
                {
                    if (timeManager._Hours >= ShopData.OpeningTime && timeManager._Hours < ShopData.ClosingTime)
                    {
                        IsOpen = true;
                    }
                    else IsOpen = false;
                    SetThePanel(IsOpen);
                    return;
                }
            }
            IsOpen = false;
            SetThePanel(IsOpen);
        }
    }

    private void SetThePanel(bool Open)
    {
        if (OpnClsPanel != null)
        {
            if (Open)
                OpnClsPanel.material.color = Color.green;
            else
                OpnClsPanel.material.color = Color.red;
        }
    }
}
