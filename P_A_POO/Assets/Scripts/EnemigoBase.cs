using UnityEngine;

public class EnemigoBase : Personaje
{
    [Header("Datos del enemigo")]
    [SerializeField] protected int dano = 20;
    [SerializeField] protected float rangoDeteccion = 5f;

    protected Transform jugador;

    protected virtual void Start()
    {
        GameObject objetoJugador = GameObject.FindGameObjectWithTag("Player");

        if (objetoJugador != null)
        {
            jugador = objetoJugador.transform;
        }
    }

    public int Dano => dano;

    public override void Morir()
    {
        Debug.Log("El enemigo murió.");
        Destroy(gameObject);
    }

    public override void Atacar()
    {
        Debug.Log("El enemigo atacó.");
    }
}