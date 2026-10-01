using UnityEngine;

// SRP: Se encarga del patrullaje entre puntos y del daño por contacto.
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

    private void Update()
    {
        Patrullar();
    }

    public void Patrullar()
    {
        if (puntosPatrulla == null || puntosPatrulla.Length == 0) return;

        transform.position = Vector2.MoveTowards(
            transform.position,
            puntosPatrulla[puntoActual].position,
            velocidadPatrulla * Time.deltaTime
        );

        if (Vector2.Distance(transform.position, puntosPatrulla[puntoActual].position) < 0.1f)
        {
            puntoActual = (puntoActual + 1) % puntosPatrulla.Length;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // ISP / DIP: Desacoplado mediante interfaz IDaniable
            IDaniable objetivo = collision.gameObject.GetComponent<IDaniable>();
            if (objetivo != null)
            {
                objetivo.RecibirDanio(dano);
                Atacar();
            }
        }
    }
}