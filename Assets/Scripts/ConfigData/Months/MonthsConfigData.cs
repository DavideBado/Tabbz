using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bado_City
{
    [CreateAssetMenu(fileName = "Month Config Data", menuName = "Month", order = 0)]
    public class MonthsConfigData : ScriptableObject
    {
        [SerializeField]
        protected List<int> Holidays = new List<int>();
        [SerializeField]
        protected int Days;
        int currentDay;
        public bool day_used; 

        public bool CanWork()
        {
            foreach (int _day in Holidays)
            {
                if(_day == currentDay)
                {
                    return false;
                }
            }
            return true;
        }

        public int NextDay()
        {
            int _nextDay = currentDay + 1;
            day_used = false;
            if(_nextDay > Days)
            {
                return -1;
            }
            return _nextDay;
        }
    }
}

