using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe comune a tutti i negozi di moto
/// </summary>
public class BikeShopBase : MonoBehaviour, IShop
{
    public string Name { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public List<int> WorkingDays { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public float OpeningTime { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public float ClosingTime { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public List<BikeBase> Bikes = new List<BikeBase>(); // Quante e quali moto si possono comprare
}
