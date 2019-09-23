using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Tabboz_Base
{
    public class DayManager : MonoBehaviour
    {      
        [SerializeField]
        private List<MonthsConfigData> Months = new List<MonthsConfigData>();
        [SerializeField]
        private List<string> WeekDays = new List<string>();
        int currentMonth;
        [HideInInspector]
        public int currentWeekDay;
        public TimeManager timeManager;
        
        #region DelegatesDef
        public delegate void MyDayDelegate(int _dayNum, string _dayName);
        public delegate void MyMonthDelegate(MonthsConfigData _month);
        #endregion
        #region Delegates
        public MyDayDelegate UpdateDayDelegate;
        public MyMonthDelegate UpdateMonth;
        #endregion
        private void Start()
        {
            currentMonth = 0;
            Months[currentMonth].Setup();
        }
        private void OnEnable()
        {
            timeManager.UpdateTime24h += UpdateDay;
        }
        private void OnDisable()
        {
            timeManager.UpdateTime24h -= UpdateDay;
        }
        private void UpdateDay()
        {
            if (Months[currentMonth].NextDay() == -1)
            {
                currentMonth++;
                if (currentMonth >= Months.Count)
                {
                    currentMonth = 0;
                }
                Months[currentMonth].Setup();
                UpdateMonth(Months[currentMonth]);
            }
            UpdateWeek();
            UpdateDayDelegate(Months[currentMonth].CurrentDay(), WeekDays[currentWeekDay]);
        }
        private void UpdateWeek()
        {
            currentWeekDay++;
            if (currentWeekDay >= WeekDays.Count)
                currentWeekDay = 0;
        }       
    }
}
