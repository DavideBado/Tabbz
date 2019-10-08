using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tabboz_3D;

namespace Tabboz_Base
{
    [CreateAssetMenu(fileName = "Drink Congid Data", menuName = "Saleable/Drink", order = 0)]
    public class DrinksConfigData : BuyableBase, ISaleable
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
        public string Description()
        {
            string _description = "";
            _description = string.Format("Vol:{0}\n", Vol);
            return _description;
        }

        [SerializeField]
        protected float Vol;

        public void EquipMe() // Da sostituire con evento e differenziare 3D e 2D
        {
            GameManager3D.instance.tabboz.MyDrinks.Add(this);
        }
    }
}
