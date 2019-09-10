using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMoveTest : MonoBehaviour
{
    [HideInInspector]
    public ZonaPedonale MyZone;
    [HideInInspector]
    public ZonaPedonale OvertakeZone;
    [HideInInspector]
    public bool Overtaking;
    public int SpeedMax;
    public Animator IAController;
    public PedoneConfigData configData;    
    [Range(-1,1)] public int direction;

    public void Setup(PedoneConfigData _configData, int _direction)
    {
        configData = _configData;
        direction = _direction;
    }
}