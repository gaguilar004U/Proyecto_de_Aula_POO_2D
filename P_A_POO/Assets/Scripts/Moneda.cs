using UnityEngine;

public class Moneda : MonoBehaviour
{
    public int valor = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Jugador jugador = other.GetComponent<Jugador>();

            if (jugador != null)
            {
                jugador.AgregarMonedas(valor);
                Destroy(gameObject);
            }
        }
    }
}