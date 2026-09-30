using UnityEngine;

public class MuertePersonajeSRP : MonoBehaviour
{
    private PersonajeSRP personaje;
    private ManejoEscenaSRP manejoEscenaSRP;

    private void Awake()
    {
        personaje = GetComponent<PersonajeSRP>();

        manejoEscenaSRP = FindFirstObjectByType<ManejoEscenaSRP>();
    }

    public void Morir()
    {
        if (personaje != null)
        {
            Debug.Log(personaje.Nombre + " murió");
        }

        if (manejoEscenaSRP != null)
        {
            manejoEscenaSRP.ReiniciarNivel();
        }
    }
}
