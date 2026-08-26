using UnityEngine;

public class EnemigoAtacante : EnemigoBase
{
    [Header("Disparo")]
    [SerializeField] private GameObject prefabBala;
    [SerializeField] private Transform firePoint;
    [SerializeField] private int cantidadBalas = 10;
    [SerializeField] private float velocidadBala = 15f;
    [SerializeField] private float tiempoEntreDisparos = 2f;

    private GameObject[] poolBalas;
    private float tiempoDisparo;

    protected override void Start()
    {
        base.Start();

        // Crear las balas una sola vez
        poolBalas = new GameObject[cantidadBalas];

        for (int i = 0; i < cantidadBalas; i++)
        {
            poolBalas[i] = Instantiate(prefabBala);
            poolBalas[i].SetActive(false);
        }
    }

    private void Update()
    {
        MirarAlJugador();

        if (jugador == null)
            return;

        float distancia = Vector2.Distance(transform.position, jugador.position);

        // Solo dispara si el jugador está dentro del rango
        if (distancia <= rangoDeteccion)
        {
            tiempoDisparo += Time.deltaTime;

            if (tiempoDisparo >= tiempoEntreDisparos)
            {
                Disparar();
                tiempoDisparo = 0f;
            }
        }
        else
        {
            tiempoDisparo = 0f;
        }
    }

    private void Disparar()
    {
        GameObject bala = ObtenerBala();

        if (bala == null)
            return;

        bala.transform.position = firePoint.position;
        bala.transform.rotation = firePoint.rotation;

        bala.SetActive(true);

        Bala scriptBala = bala.GetComponent<Bala>();

        if (scriptBala != null)
        {
            Vector2 direccion = (jugador.position - firePoint.position).normalized;

            scriptBala.Disparar(direccion, velocidadBala);
        }
    }

    private GameObject ObtenerBala()
    {
        for (int i = 0; i < poolBalas.Length; i++)
        {
            if (!poolBalas[i].activeInHierarchy)
            {
                return poolBalas[i];
            }
        }

        return null;
    }

    private void MirarAlJugador()
    {
        if (jugador == null) return;

        if (jugador.position.x < transform.position.x)
        {
            // Jugador está a la izquierda
            transform.localScale = new Vector3(
                Mathf.Abs(transform.localScale.x),
                transform.localScale.y,
                transform.localScale.z
            );
        }
        else
        {
            // Jugador está a la derecha
            transform.localScale = new Vector3(
                -Mathf.Abs(transform.localScale.x),
                transform.localScale.y,
                transform.localScale.z
            );
        }
    }
}