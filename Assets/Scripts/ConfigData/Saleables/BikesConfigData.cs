using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bado_City
{
    [CreateAssetMenu(fileName = "Bike Config Data", menuName = "Saleable/Bike", order = 1)]
    public class BikesConfigData : ScriptableObject, ISaleable
    {
        [SerializeField]
        protected string Name_Insp;
        public string Name { get { return Name; } set { Name = Name_Insp; } }
        [SerializeField]
        protected Sprite Icon_Insp;
        public Sprite Icon { get { return Icon; } set { Icon = Icon_Insp; } }
        [SerializeField]
        protected int Price_Insp;
        public int Price { get { return Price; } set { Price = Price_Insp; } }

        [SerializeField]
        protected float SpeedMax, Endurance, FuelMax; // Ogni moto avrà una velocità massima, una resistenza all'usura e una capienza del serbatoio. Da rivedere nel dettaglio le gare.
    }
}
