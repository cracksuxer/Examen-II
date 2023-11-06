using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Este script se creo de nuevo para que las sillas se unan a la llamada del evento cuando el Ghoul toca la cama
public class SillaScript : MonoBehaviour
{
    public BedScript cama;

    // Start se suscribe al evento OnPersonTouchedBed de la cama
    private void Start()
    {
        cama.OnPersonTouchedBed += HandlePersonTouchedBed;
    }

    // Este método se llama cuando el Ghoul toca la cama
    private void HandlePersonTouchedBed()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb?.AddForce(Vector3.up * 5, ForceMode.Impulse);
    }

    private void OnDestroy()
    {
        cama.OnPersonTouchedBed -= HandlePersonTouchedBed;
    }
}
