using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_Pedoni : MonoBehaviour
{
    public List<PedoneConfigData> pedoneConfigs = new List<PedoneConfigData>();
    public GameObject prefabPedone;
    EnvironmentManager environmentManager;
    private void OnEnable()
    {
        environmentManager.SpawnaUnPedone += SpawnPedone;
    }

    private void OnDisable()
    {
        environmentManager.SpawnaUnPedone -= SpawnPedone;
    }

    private void SpawnPedone()
    {
        GameObject NewPedone = Instantiate(prefabPedone, transform.position, Quaternion.identity);
        NewPedone.GetComponent<NPCMoveTest>().Setup(pedoneConfigs[Random.Range(0, pedoneConfigs.Count)], Random.Range(-1, 2));
    }
}
