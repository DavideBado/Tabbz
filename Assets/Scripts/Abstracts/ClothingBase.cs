using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe comune a tutti i vestiti
/// </summary>
public class ClothingBase : MonoBehaviour, ISaleable
{
    public string Name { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public Sprite Icon { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public int Price { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public int Type; // Identificatore per la zona del corpo di destinazione
}
