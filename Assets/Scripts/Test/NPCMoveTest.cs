using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMoveTest : MonoBehaviour
{
    public float Speed;
    Vector3 CurrentTarget;
    int i = 0;
    public List<Vector3> targets = new List<Vector3>();
    // Start is called before the first frame update
    void Start()
    {
        CurrentTarget = targets[i]; // Ecco la mia prima destinazione
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, CurrentTarget, Speed * Time.deltaTime); // Mi muovo verso la mia destinazione
        if (transform.position == CurrentTarget) // Quando arrivo a destinazione
        {
            if (i == (targets.Count - 1)) // Se era l'ultima destinazione
            {
                i = 0; // Torno alla prima
            }
            else i++; // Se non lo era allora passo alla prossima
            CurrentTarget = targets[i]; // Aggiorno la destinazione
        }
    }

}