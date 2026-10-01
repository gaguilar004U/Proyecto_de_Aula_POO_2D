using UnityEngine;

public class VidaPersonajeSRP : MonoBehaviour
{
    [Header("Vida")]
    [SerializeField] private int vidaInicial = 100;

    private int vida;

    private MuertePersonajeSRP muerte;
    private MovimientoPersonajeSRP movimiento;

    public int Vida
    {
        get { return vida; }
        private set { vida = value; }
    }

    private void Awake()
    {
        vida = vidaInicial;

        muerte = GetComponent<MuertePersonajeSRP>();
        movimiento = GetComponent<MovimientoPersonajeSRP>();
    }

    public void RecibirDanio(int cantidad)
    {
        Vida -= cantidad;

        Debug.Log("Vida: " + Vida);

        if (movimiento != null)
        {
            movimiento.ImpulsarHaciaArriba();
        }

        if (Vida <= 0)
        {
            Vida = 0;

            if (muerte != null)
            {
                muerte.Morir();
            }
        }
    }

    public void Curar(int cantidad)
    {
        Vida += cantidad;

        Debug.Log("Vida: " + Vida);
    }
}