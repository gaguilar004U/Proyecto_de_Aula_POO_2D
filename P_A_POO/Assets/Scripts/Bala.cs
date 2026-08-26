using UnityEngine;

public class Bala : MonoBehaviour
{
    [SerializeField] private int dano = 20;
    [SerializeField] private float tiempoMaximo = 3f;

    private Rigidbody2D rb;
    private float tiempoVida;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        tiempoVida = 0f;

        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
            rb.angularVelocity = 0f;
        }
    }

    private void Update()
    {
        tiempoVida += Time.deltaTime;

        // Si pasan 3 segundos, se reutiliza
        if (tiempoVida >= tiempoMaximo)
        {
            DesactivarBala();
        }
    }

    public void Disparar(Vector2 direccion, float velocidad)
    {
        if (rb != null)
        {
            rb.linearVelocity = direccion * velocidad;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Si toca al jugador
        if (collision.gameObject.CompareTag("Player"))
        {
            Jugador jugador = collision.gameObject.GetComponent<Jugador>();

            if (jugador != null)
            {
                jugador.RecibirDanio(dano);
            }

            DesactivarBala();
            return;
        }

        // Si toca el suelo
        if (collision.gameObject.CompareTag("Suelo"))
        {
            DesactivarBala();
        }
    }

    private void DesactivarBala()
    {
        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
        }

        gameObject.SetActive(false);
    }
}