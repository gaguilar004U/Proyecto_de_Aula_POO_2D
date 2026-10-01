using UnityEngine;

// HERENCIA
public abstract class EnemigoBase : Personaje
{
    [Header("Datos del Enemigo")]
    [SerializeField] protected int dano = 20;
    [SerializeField] protected float rangoDeteccion = 7f;

    protected Transform jugador;

    public int Dano => dano;
    public float RangoDeteccion => rangoDeteccion;

    protected virtual void Start()
    {
        BuscarJugador();
    }

    protected void BuscarJugador()
    {
        GameObject objetoJugador = GameObject.FindGameObjectWithTag("Player");
        if (objetoJugador != null)
        {
            jugador = objetoJugador.transform;
        }
    }

    // POLIMORFISMO
    public override void Morir()
    {
        Debug.Log($"El enemigo {gameObject.name} murió.");
        Destroy(gameObject);
    }

    public override void Atacar()
    {
        Debug.Log($"El enemigo {gameObject.name} atacó.");
    }
}