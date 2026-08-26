using UnityEngine;

public class Cura : MonoBehaviour
{
    public int cantidadCuracion = 25;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Jugador jugador = other.GetComponent<Jugador>();

            if (jugador != null)
            {
                jugador.RecibirCura(cantidadCuracion);
                Destroy(gameObject);
            }
        }
    }
}
