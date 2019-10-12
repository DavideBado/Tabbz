using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tabboz_Base
{
    [CreateAssetMenu(fileName = "Month Config Data", menuName = "Month", order = 0)]
    public class MonthsConfigData : ScriptableObject
    {
        [SerializeField]
        protected List<int> Holidays = new List<int>();
        [SerializeField]
        protected int Days;       
        public string Name;
        public int currentDay = 1;
        public bool day_used;

        public void Setup()
        {
            currentDay = 1;
        }
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

        public int CurrentDay()
        {
            return currentDay;
        }
        public int NextDay()
        {
            int _nextDay = currentDay + 1;
            currentDay = _nextDay;
            day_used = false;
            if(_nextDay > Days)
            {
                return -1;
            }
            return _nextDay;
        }
    }
}

