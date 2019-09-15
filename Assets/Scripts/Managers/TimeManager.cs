using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private float _Minutes;
    private int _Hours;
    #region Actions
    public Action UpdateTime;
    public Action UpdateTime3h;
    public Action UpdateTime24h;
    #endregion

    private void Update()
    {
        UpdateMinutes();
    }

    private void UpdateMinutes()
    {
        _Minutes += (Time.deltaTime / 2);
        if(_Minutes >= 60)
        {
            UpdateHours();
            _Minutes = 0;
        }
        //if (_Minutes % 1 == 0)
            UpdateTime?.Invoke();
    }
    private void UpdateHours()
    {
        _Hours++;
        if(_Hours > 24)
        {
            _Hours = 1;
        }
        if(_Hours % 3 == 0)
        {
            UpdateTime3h?.Invoke();
        }
        if(_Hours == 24)
        {
            UpdateTime24h?.Invoke();
        }
    }
}
