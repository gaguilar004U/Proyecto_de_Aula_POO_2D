using UnityEngine;

public class MuertePersonajeSRP : MonoBehaviour
{
    private PersonajeSRP personaje;
    private ManejoEscenaSRP manejoEscenaSRP;

    private void Awake()
    {
        personaje = GetComponent<PersonajeSRP>();
        manejoEscenaSRP = FindFirstObjectByType<ManejoEscenaSRP>();

        // Advertencia si no se encuentra en la escena
        if (manejoEscenaSRP == null)
        {
            Debug.LogError("Falta el componente ManejoEscenaSRP en la escena. Asegúrate de asignarlo a un GameObject.");
        }
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
        else
        {
            Debug.LogError("No se pudo reiniciar el nivel: ManejoEscenaSRP no existe en la escena.");
        }
    }
}