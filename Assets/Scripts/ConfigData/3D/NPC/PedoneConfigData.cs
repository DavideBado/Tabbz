using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New_PedoneConfigData", menuName = "NPC/NewPedone", order = 1)]
public class PedoneConfigData : ScriptableObject
{
    [Range(0, 10)]public float Speed;
    public Carattere m_Carattere;
}

public enum Carattere
{
    Aggressivo,
    Flessibile,
    Rilassato
}
