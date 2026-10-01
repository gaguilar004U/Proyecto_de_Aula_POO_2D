using UnityEngine;

// SRP: Administra la persecución terrestre, la superación de obstáculos (salto) y el ataque al jugador.
public class EnemigoPerseguidor : EnemigoBase
{
    [Header("Persecución")]
    [SerializeField] private float velocidadPersecucion = 1f;

    [Header("Salto")]
    [SerializeField] private float fuerzaSalto = 7f;
    [SerializeField] private bool estaSaltando = false;
    [SerializeField] private Transform detectorSuelo;
    [SerializeField] private float distanciaDetector = 1f;
    [SerializeField] private LayerMask capaSuelo;

    [Header("Ataque y Daño")]
    [SerializeField] private float tiempoEntreAtaques = 1f;
    private float tiempoSiguienteAtaque = 0f;

    private Rigidbody2D rb;
    private bool puedePerseguir;

    protected override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (jugador == null) return;

        float distancia = Vector2.Distance(transform.position, jugador.position);
        puedePerseguir = distancia <= rangoDeteccion;

        if (puedePerseguir)
        {
            Perseguir();
        }
    }

    private void Perseguir()
    {
        Vector2 direccion = jugador.position - transform.position;

        if (Mathf.Abs(direccion.x) > 0.1f)
        {
            float movimiento = Mathf.Sign(direccion.x);

            rb.linearVelocity = new Vector2(
                movimiento * velocidadPersecucion,
                rb.linearVelocity.y
            );

            DetectarObstaculo(movimiento);
        }
    }

    private void DetectarObstaculo(float direccion)
    {
        if (detectorSuelo == null) return;

        bool estaEnSuelo = Physics2D.OverlapCircle(
            detectorSuelo.position,
            0.2f,
            capaSuelo
        );

        if (!estaEnSuelo)
        {
            estaSaltando = true;
            return;
        }

        estaSaltando = false;

        RaycastHit2D obstaculo = Physics2D.Raycast(
            detectorSuelo.position,
            Vector2.right * direccion,
            distanciaDetector,
            capaSuelo
        );

        if (obstaculo.collider != null && !estaSaltando)
        {
            rb.linearVelocity = new Vector2(
                rb.linearVelocity.x,
                fuerzaSalto
            );

            estaSaltando = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ProcesarContacto(collision.gameObject);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        ProcesarContacto(collision.gameObject);
    }

    private void ProcesarContacto(GameObject objetoColisionado)
    {
        if (objetoColisionado.CompareTag("Player"))
        {
            if (Time.time >= tiempoSiguienteAtaque)
            {
                // ISP / DIP: Desacoplado mediante la interfaz IDaniable
                IDaniable objetivo = objetoColisionado.GetComponent<IDaniable>();

                if (objetivo != null)
                {
                    objetivo.RecibirDanio(dano);
                    Atacar();
                    tiempoSiguienteAtaque = Time.time + tiempoEntreAtaques;
                }
            }
        }
    }
}