using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Bado_City
{
    public class DayManager : MonoBehaviour
    {
        public TMP_Text WeekDay_txt, Day_txt, Month_txt;
        [SerializeField]
        private List<MonthsConfigData> Months = new List<MonthsConfigData>();
        [SerializeField]
        private List<string> WeekDays = new List<string>();
        int currentMonth;
        [HideInInspector]
        public int currentWeekDay;
        public TimeManager timeManager;

        private void Start()
        {
            currentMonth = 0;
            Months[currentMonth].Setup();
            UpdateText();
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
            }
            UpdateWeek();
            UpdateText();
        }
        private void UpdateWeek()
        {
            currentWeekDay++;
            if (currentWeekDay >= WeekDays.Count)
                currentWeekDay = 0;
        }
        private void UpdateText()
        {
            WeekDay_txt.text = WeekDays[currentWeekDay];
            Day_txt.text = Months[currentMonth].CurrentDay().ToString("D2") + "-";
            Month_txt.text = Months[currentMonth].Name;
        }
    }
}
