using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Bado_City
{
    public class DayManager : MonoBehaviour
    {
        public TMP_Text Day_txt, Month_txt;
        [SerializeField]
        private List<MonthsConfigData> Months = new List<MonthsConfigData>();
        int current;
        public TimeManager timeManager;

        private void Start()
        {
            current = 0;
            Months[current].Setup();
            UpdateText();
        }
        private void OnEnable()
        {
            timeManager.UpdateTime24h += DayCheck;
        }
        private void OnDisable()
        {
            timeManager.UpdateTime24h -= DayCheck;
        }
        private void DayCheck()
        {
            if (Months[current].NextDay() == -1)
            {
                current++;
                if (current >= Months.Count)
                {
                    current = 0;
                }
                Months[current].Setup();
            }
            UpdateText();
        }
        private void UpdateText()
        {
            Day_txt.text = Months[current].CurrentDay().ToString("D2") + "-";
            Month_txt.text = Months[current].Name;
        }
    }
}
