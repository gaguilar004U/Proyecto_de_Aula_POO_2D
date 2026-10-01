using UnityEngine;

// SRP
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
        InicializarPool();
    }

    private void InicializarPool()
    {
        if (prefabBala == null) return;

        poolBalas = new GameObject[cantidadBalas];
        for (int i = 0; i < cantidadBalas; i++)
        {
            poolBalas[i] = Instantiate(prefabBala);
            poolBalas[i].SetActive(false);
        }
    }

    private void Update()
    {
        if (jugador == null) return;

        MirarAlJugador();

        float distancia = Vector2.Distance(transform.position, jugador.position);

        if (distancia <= rangoDeteccion)
        {
            tiempoDisparo += Time.deltaTime;
            if (tiempoDisparo >= tiempoEntreDisparos)
            {
                Atacar();
                tiempoDisparo = 0f;
            }
        }
        else
        {
            tiempoDisparo = 0f;
        }
    }

    // POLIMORFISMO
    public override void Atacar()
    {
        base.Atacar();
        Disparar();
    }

    private void Disparar()
    {
        GameObject bala = ObtenerBala();
        if (bala == null || firePoint == null) return;

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
        if (poolBalas == null) return null;

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

        float escalaX = Mathf.Abs(transform.localScale.x);
        transform.localScale = new Vector3(
            jugador.position.x < transform.position.x ? escalaX : -escalaX,
            transform.localScale.y,
            transform.localScale.z
        );
    }
}