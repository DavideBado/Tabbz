using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Clase comune a tutti i tabaccai
/// </summary>
public abstract class TabacchiBase : MonoBehaviour, IShop
{
    public string Name { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public List<int> WorkingDays { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public float OpeningTime { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public float ClosingTime { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public List<CigarettesBase> cigarettes = new List<CigarettesBase>(); // Quante e quali sigarette vende
}
