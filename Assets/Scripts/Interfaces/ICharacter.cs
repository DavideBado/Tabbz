using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Bado_City
{
    public interface ICharacter
    {
        string Name { get; set; }
        Sprite Icon { get; set; }
    }
}
