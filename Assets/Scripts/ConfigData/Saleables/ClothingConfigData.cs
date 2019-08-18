﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bado_City
{
    [CreateAssetMenu(fileName = "Clothing Congid Data", menuName = "Saleable/Clothing", order = 2)]
    public class ClothingConfigData : ScriptableObject, ISaleable
    {
        [SerializeField]
        protected string Name_Insp;
        public string Name { get { return Name_Insp; } set { Name = Name_Insp; } }
        [SerializeField]
        protected Sprite Icon_Insp;
        public Sprite Icon { get { return Icon_Insp; } set { Icon = Icon_Insp; } }
        [SerializeField]
        protected int Price_Insp;
        public int Price { get { return Price_Insp; } set { Price = Price_Insp; } }

        [SerializeField]
        protected int Type; // Identificatore per la zona del corpo di destinazione
    }
}
