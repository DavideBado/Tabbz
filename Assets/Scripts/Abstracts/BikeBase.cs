using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe comune a tutte le moto
/// </summary>
public abstract class BikeBase : MonoBehaviour, ISaleable
{
    public string Name { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public Sprite Icon { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public int Price { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public float SpeedMax, Endurance, FuelMax; // Ogni moto avrà una velocità massima, una resistenza all'usura e una capienza del serbatoio. Da rivedere nel dettaglio le gare.
}
