using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe base per tutti i negozzi presumendo che in ogni negozio si possa comprare un solo tipo di oggetti
/// </summary>
namespace Tabboz_Base
{
    [CreateAssetMenu(fileName = "Shop ConfigData", menuName = "Shop/New Shop", order = 1)]
    public class ShopConfigData : ScriptableObject, IShop
    {
        [SerializeField]
        protected string Name_Insp;
        public string Name { get { return Name_Insp; } set { Name = Name_Insp; } }
        [SerializeField]
        protected List<int> WorkingDays_Insp;
        public List<int> WorkingDays { get { return WorkingDays_Insp; } set { WorkingDays = WorkingDays_Insp; } }
        [SerializeField]
        protected float OpeningTime_Insp;
        public float OpeningTime { get { return OpeningTime_Insp; } set { OpeningTime = OpeningTime_Insp; } }
        [SerializeField]
        protected float ClosingTime_Insp;
        public float ClosingTime { get { return ClosingTime_Insp; } set { ClosingTime = ClosingTime_Insp; } }

        [SerializeField]
        internal List<ClothesConfigData> SaleableObjects = new List<ClothesConfigData>(); // Quali oggetti si possono comprare
    }
}