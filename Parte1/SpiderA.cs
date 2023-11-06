using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderA : MonoBehaviour
{
    public Transform chairPosition;
    public Transform tablePosition;
    private bool moveToTable = true;
    
    void Update()
    {
        if (moveToTable)
        {
            transform.position = Vector3.MoveTowards(transform.position, tablePosition.position, 1f * Time.deltaTime);
            if (transform.position == tablePosition.position)
                moveToTable = false;
        }
        else
        {
            // Cambie aquí que antes movía de vuela la araña a la silla, ahora una vez que llega a la silla se queda ahí
            if (transform.position == chairPosition.position)
                moveToTable = true;
        }
    }
}
