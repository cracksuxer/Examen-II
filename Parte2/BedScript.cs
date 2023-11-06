using UnityEngine;

// Ese script se creo de nuevo para que cuando se toque la cama, las sillas se muevan y 
// mueva además las otras camas aleatoriamente a la izquierda o derecha
public class BedScript : MonoBehaviour
{
    // Creamos un delegado para que las sillas se suscriban al evento
    public delegate void PersonTouchedBedHandler();
    // Creamos el evento en sí para que las sillas se suscriban
    public event PersonTouchedBedHandler OnPersonTouchedBed;

    public float desplazamientoVelocidad = 2.0f;
    private bool moverCama = false;

    // Cuando colisione el ghoul hará que se muevan las camas e invocará el evento para que las sillas se muevan
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Ghoul")
        {
            moverCama = true;
            
            OnPersonTouchedBed?.Invoke();
        }
    }

    // Eso de aqui coge las objectos con el tag Bed y las mueve aleatoriamente a la izquierda o derecha
    void Update()
    {
        if (moverCama)
        {
            GameObject[] beds = GameObject.FindGameObjectsWithTag("Bed");

            foreach (GameObject bed in beds)
            {
                float desplazamiento = Random.value > 0.5f ? desplazamientoVelocidad : -desplazamientoVelocidad;
                Rigidbody rb = bed.GetComponent<Rigidbody>();
                rb?.AddForce(Vector3.left * desplazamiento, ForceMode.Impulse);
            }

            moverCama = false;
        }
    }
}
