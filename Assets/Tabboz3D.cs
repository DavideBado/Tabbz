using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tabboz_Base;

namespace Tabboz_3D
{
    public class Tabboz3D : MonoBehaviour
    {
        public int Money;
        [HideInInspector]
        public List<BikesConfigData> MyBikes = new List<BikesConfigData>();
        [HideInInspector]
        public List<CigarettesConfigData> MyCigarettes = new List<CigarettesConfigData>();
        [HideInInspector]
        public List<ClothesConfigData> MyClothes = new List<ClothesConfigData>();
        [HideInInspector]
        public List<DrinksConfigData> MyDrinks = new List<DrinksConfigData>();
    } 
}
