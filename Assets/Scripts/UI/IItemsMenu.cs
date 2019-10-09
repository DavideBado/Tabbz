using System.Collections.Generic;
using UnityEngine;

namespace Tabboz_3D
{
    public interface IItemsMenu
    {
        GameObject Panel { get;}
        GameObject Content { get;}
        GameObject ItemPrefab { get;}
        List<ISaleable> Items { get;}
        void UpdateItems();
    } 
}