using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Selectable : MonoBehaviour
{
    public SelectableType Type;
    public enum SelectableType
    {
        Door,
        Shop,
        Bed,
        Computer,
        CosoOrari
    }
}
