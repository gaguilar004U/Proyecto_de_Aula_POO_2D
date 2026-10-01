using UnityEngine;
using UnityEngine.SceneManagement;

public class ManejoEscenaSRP : MonoBehaviour
{
    public void ReiniciarNivel()
    {
        int indiceEscenaActual = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(indiceEscenaActual);
    }
    public void SiguienteNivel()
    {
        Time.timeScale = 1f;
        int siguienteIndice = SceneManager.GetActiveScene().buildIndex + 1;
        if (siguienteIndice >= SceneManager.sceneCountInBuildSettings)
        {
            siguienteIndice = 0;
        }
        SceneManager.LoadScene(siguienteIndice);
    }
}
