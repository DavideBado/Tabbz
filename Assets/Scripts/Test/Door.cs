using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe per test da eliminare e inserire i valori nella base di ogni edificio visitabile
/// </summary>
public class Door : Selectable
{
    public Vector3 InsidePosition;
    public List<MeshRenderer> SelectableObjects = new List<MeshRenderer>();
    public ShopBase Shop;
}
