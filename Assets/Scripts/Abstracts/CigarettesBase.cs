using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe base per ogni sigaretta
/// </summary>
public abstract class CigarettesBase : MonoBehaviour, ISaleable
{
    public string Name { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public Sprite Icon { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public int Price { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public float Nicotine, Tar, CO; // Valori delle sigarette
    private float damagePower; // Valore di danno percepito, non reale, esempio un tabboz medio non ha idea di cosa sia il CO, mezza botta il Tar quindi guarderà la nicotina.

    /// <summary>
    /// Calcola quanto i tabboz credono che le loro sigarette siano forti
    /// </summary>
    private void setDamagePower()
    {

    }

    /// <summary>
    /// Incrementa la reputazione del tabboz nella compagnia
    /// </summary>
    private void upgradeStat()
    {

    }
}
