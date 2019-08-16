using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe comune a tutti i drink
/// </summary>
public class DrinkBase : MonoBehaviour, ISaleable
{
    public string Name { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public Sprite Icon { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public int Price { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public float Vol;
}
