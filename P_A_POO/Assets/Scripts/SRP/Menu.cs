using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject panelAjustes;
    [SerializeField] private string nombreEscenaJuego = "Nivel_1";

    public void Jugar()
    {
        SceneManager.LoadScene(nombreEscenaJuego);

        // Para el cambio de nivel
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void AbrirAjustes()
    {
        if (panelAjustes != null)
        {
            panelAjustes.SetActive(true);
        }
    }

    public void CerrarAjustes()
    {
        if (panelAjustes != null)
        {
            panelAjustes.SetActive(false);
        }
    }
    public void Salir()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
