using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bado_City
{
    public class DayManager : MonoBehaviour
    {
        [SerializeField]
        private List<MonthsConfigData> Months = new List<MonthsConfigData>();
        int current;

        private void DayCheck()
        {
            if (Months[current].NextDay() == -1)
            {
                current++;
                if(current >= Months.Count)
                {
                    current = 0;
                }
            }
    }

    }

}
