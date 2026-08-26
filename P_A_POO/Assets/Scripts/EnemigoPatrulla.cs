using UnityEngine;

public class EnemigoPatrulla : EnemigoBase
{
    [Header("Patrulla")]
    [SerializeField] private float velocidadPatrulla = 2f;
    [SerializeField] private Transform[] puntosPatrulla;

    private int puntoActual = 0;

    protected override void Start()
    {
        base.Start();
    }

    void Update()
    {
        Patrullar();
    }

    public void Patrullar()
    {
        if (puntosPatrulla.Length == 0)
        {
            return;
        }

        transform.position = Vector2.MoveTowards(
            transform.position,
            puntosPatrulla[puntoActual].position,
            velocidadPatrulla * Time.deltaTime
        );

        if (Vector2.Distance(
            transform.position,
            puntosPatrulla[puntoActual].position) < 0.1f)
        {
            puntoActual++;

            if (puntoActual >= puntosPatrulla.Length)
            {
                puntoActual = 0;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Personaje personaje = collision.gameObject.GetComponent<Personaje>();

            if (personaje != null)
            {
                personaje.RecibirDanio(dano);
                Atacar();
            }
        }
    }
}