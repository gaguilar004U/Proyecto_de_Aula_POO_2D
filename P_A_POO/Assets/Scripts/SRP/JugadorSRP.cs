using UnityEngine;

public class JugadorSRP : MonoBehaviour
{
    [Header("Jugador")]
    [SerializeField] private float limiteCaida = -10f;

    private MovimientoPersonajeSRP movimiento;
    private VidaPersonajeSRP vida;

    private void Start()
    {
        movimiento = GetComponent<MovimientoPersonajeSRP>();
        vida = GetComponent<VidaPersonajeSRP>();

        Debug.Log("Start ejecutado");
    }

    private void Update()
    {
        Debug.Log("Update ejecutado");

        // Movimiento horizontal
        float direccion = Input.GetAxis("Horizontal");

        movimiento.Mover(direccion);

        // Salto
        if (Input.GetKeyDown(KeyCode.Space))
        {
            movimiento.Saltar();
        }

        // Si el jugador cae fuera del mapa
        if (transform.position.y < limiteCaida)
        {
            vida.RecibirDanio(vida.Vida);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Dano"))
        {
            vida.RecibirDanio(25);
        }
    }

    public void Atacar()
    {
        // Pendiente de integrar
    }

    public void RecogerObjeto()
    {
        // Pendiente de integrar
    }
}
