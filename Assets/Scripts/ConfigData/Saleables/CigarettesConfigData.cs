using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bado_City
{
    [CreateAssetMenu(fileName = "Cigarette Congid Data", menuName = "Saleable/Cigarette", order = 3)]
    public class CigarettesConfigData : BuyableBase, ISaleable
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
        protected float Nicotine, Tar, CO; // Valori delle sigarette
        private float damagePower; // Valore di danno percepito, non reale, esempio un tabboz medio non ha idea di cosa sia il CO, mezza botta il Tar quindi guarderà la nicotina.

        /// <summary>
        /// Calcola quanto i tabboz credono che le loro sigarette siano forti
        /// </summary>
        private void setDamagePower()
        {

        }

        /// <summary>
        /// Incrementa la reputazione del tabboz nella compagnia
        /// </summary>
        private void upgradeStat()
        {

        }

        public void EquipMe()
        {
            throw new System.NotImplementedException();
        }
    }
}
