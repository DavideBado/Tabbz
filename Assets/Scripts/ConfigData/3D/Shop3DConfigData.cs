using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe base per tutti i negozzi 
/// </summary>
namespace Tabboz_3D
{
    [CreateAssetMenu(fileName = "Shop3D ConfigData", menuName = "3D/Shop3D/New Shop3D", order = 1)]
    public class Shop3DConfigData : ScriptableObject, IShop
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
        internal List<BuyableBase> SaleableObjects = new List<BuyableBase>(); // Quali oggetti si possono comprare
    }
}