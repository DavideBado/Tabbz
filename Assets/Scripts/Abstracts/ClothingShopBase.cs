using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe comune a tutti i negozi di vestiti
/// </summary>
public class ClothingShopBase : MonoBehaviour, IShop
{
    public string Name { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public List<int> WorkingDays { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public float OpeningTime { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public float ClosingTime { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public List<ClothingBase> Clothings = new List<ClothingBase>(); // Quali vestiti si possono comprare
}
