using UnityEngine;

// OCP / HERENCIA
public class EnemigoPapaExplosiva : EnemigoBase
{
    [Header("Configuración Papa Explosiva")]
    [SerializeField] private float tiempoParaExplotar = 2f;
    [SerializeField] private float radioExplosion = 3f;
    [SerializeField] private LayerMask capasAfectadas;
    [SerializeField] private GameObject efectoExplosionPrefab;

    private bool activada = false;
    private float temporizador;

    protected override void Start()
    {
        base.Start();
        temporizador = tiempoParaExplotar;
    }

    private void Update()
    {
        if (jugador == null) return;

        float distancia = Vector2.Distance(transform.position, jugador.position);

        if (distancia <= rangoDeteccion && !activada)
        {
            ActivarMecha();
        }

        if (activada)
        {
            temporizador -= Time.deltaTime;

            if (temporizador <= 0f)
            {
                Atacar();
            }
        }
    }

    private void ActivarMecha()
    {
        activada = true;
        Debug.Log("¡La Papa Explosiva encendió su mecha!");
    }

    // POLIMORFISMO: Ejecuta la explosión al atacar
    public override void Atacar()
    {
        base.Atacar();
        Explotar();
    }

    private void Explotar()
    {
        if (efectoExplosionPrefab != null)
        {
            Instantiate(efectoExplosionPrefab, transform.position, Quaternion.identity);
        }

        Collider2D[] objetosImpactados = Physics2D.OverlapCircleAll(
            transform.position,
            radioExplosion,
            capasAfectadas
        );

        foreach (Collider2D col in objetosImpactados)
        {
            // ISP / DIP: Daña cualquier objeto que implemente IDaniable en el área de área
            IDaniable objetivo = col.GetComponent<IDaniable>();
            if (objetivo != null)
            {
                objetivo.RecibirDanio(dano);
            }
        }

        Morir();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radioExplosion);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, rangoDeteccion);
    }
}