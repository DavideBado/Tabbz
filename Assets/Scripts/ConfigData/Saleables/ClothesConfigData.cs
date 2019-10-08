using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tabboz_3D;

namespace Tabboz_Base
{
    /// <summary>
    /// Classe base per i vestiti
    /// </summary>
    [CreateAssetMenu(fileName = "Clothes Config Data", menuName = "Saleable/Clothes", order = 2)]
    public class ClothesConfigData : BuyableBase, ISaleable
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
            _description = string.Format("Type:{0}\n", clothingType);
            return _description;
        }

        [HideInInspector]
        public int Type; // Identificatore per la zona del corpo di destinazione, penso di usarlo come index per la lista di sprite
        [SerializeField]
        protected ClothingType clothingType; // Più intuitivo di "int Type"
        
        public void Init()
        {
            switch (clothingType)
            {
                case ClothingType.Cap:
                    Type = 0;
                    break;
                case ClothingType.Jacket:
                    Type = 1;
                    break;
                case ClothingType.Trousers:
                    Type = 2;
                    break;
                case ClothingType.Shoes:
                    Type = 3;
                    break;
                default:
                    break;
            }
        }

        public void EquipMe() // Da sostituire con evento e differenziare 3D e 2D
        {
            GameManager3D.instance.tabboz.MyClothes.Add(this);
        }

        protected enum ClothingType
        {
            Cap,
            Jacket,
            Trousers,
            Shoes
        }
    }
}
