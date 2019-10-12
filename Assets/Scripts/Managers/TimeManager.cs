using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Tabboz_Base
{
    public class TimeManager : MonoBehaviour
    {
        // Idea, mettere una bool in ogni state per uodate o meno del tempo, oppure nello state update
        public float Moltiplic;
        [HideInInspector]
        public float _Minutes;
        [HideInInspector]
        public int _Hours = 1;
        #region Actions
        public Action UpdateTime;
        public Action UpdateTime1h;
        public Action UpdateTime3h;
        public Action UpdateTime24h;
        #endregion

        public void Init()
        {
            UpdateTime += UpdateMinutes;
            UpdateTime1h?.Invoke();
            UpdateTime3h?.Invoke();
        }
        private void OnDisable()
        {
            UpdateTime -= UpdateMinutes;
        }
        //private void Start()
        //{
        //    UpdateTime1h?.Invoke();
        //    UpdateTime3h?.Invoke();
        //}
        //private void Update()
        //{
        //    //UpdateMinutes();
        //}

        private void UpdateMinutes()
        {
            _Minutes += (Time.deltaTime * Moltiplic);
            if (_Minutes >= 60)
            {
                UpdateHours();
                _Minutes = 0;
            }
            //if (_Minutes % 1 == 0)
            //UpdateTime?.Invoke();
        }
        private void UpdateHours()
        {
            _Hours++;
            if (_Hours % 3 == 0)
            {
                UpdateTime3h?.Invoke();
            }
            if (_Hours == 24)
            {
                UpdateTime24h?.Invoke();
            }
            if (_Hours >= 24)
            {
                _Hours = 0;
            }
            UpdateTime1h();
        }        
    }
}