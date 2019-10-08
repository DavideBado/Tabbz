using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tabboz_Base
{
    [CreateAssetMenu(fileName = "TipaConfigData", menuName = "NPC/New Tipa", order = 0)]
    public class TipaConfigData : ScriptableObject, ICharacter
    {
        [SerializeField]
        protected string Name_Insp;
        public string Name { get { return Name; } set { Name = Name_Insp; } }
        [SerializeField]
        protected Sprite Icon_Insp;
        public Sprite Icon { get { return Icon; } set { Icon = Icon_Insp; } }
        [Range(0, 100)] public int Figosit;
    }
}
