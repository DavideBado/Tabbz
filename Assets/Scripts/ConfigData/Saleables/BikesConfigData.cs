using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tabboz_Base
{
    [CreateAssetMenu(fileName = "Bike Config Data", menuName = "Saleable/Bike", order = 1)]
    public class BikesConfigData : BuyableBase, ISaleable
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
        public float Velocità, Cilindrata, Efficienza, Benzina, Stato; // Ogni moto avrà una velocità massima, una resistenza all'usura e una capienza del serbatoio. Da rivedere nel dettaglio le gare.

        public void EquipMe()
        {
            throw new System.NotImplementedException();
        }
    }
}
