﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe base per tutti i negozzi presumendo che in ogni negozio si possa comprare un solo tipo di oggetti
/// </summary>
namespace Bado_City
{
    [CreateAssetMenu(fileName = "Clothing Shop ConfigData", menuName = "Shop/New Shop", order = 1)]
    public class ShopConfigData : ScriptableObject, IShop
    {
        [SerializeField]
        protected string Name_Insp;
        public string Name { get { return Name; } set { Name = Name_Insp; } }
        [SerializeField]
        protected List<int> WorkingDays_Insp;
        public List<int> WorkingDays { get { return WorkingDays; } set { WorkingDays = WorkingDays_Insp; } }
        [SerializeField]
        protected float OpeningTime_Insp;
        public float OpeningTime { get { return OpeningTime; } set { OpeningTime = OpeningTime_Insp; } }
        [SerializeField]
        protected float ClosingTime_Insp;
        public float ClosingTime { get { return ClosingTime; } set { ClosingTime = ClosingTime_Insp; } }

        [SerializeField]
        internal List<ScriptableObject> SaleableObjects = new List<ScriptableObject>(); // Quali oggetti si possono comprare
    }
}
