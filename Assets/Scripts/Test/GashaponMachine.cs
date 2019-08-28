using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GashaponMachine : MonoBehaviour
{
    public int Price;
    public List<GameObject> Gashapons = new List<GameObject>();

    public GameObject BuyOne()
    {
        int randomIndex = Random.Range(0, Gashapons.Count);
        return Gashapons[randomIndex];
    }
}
