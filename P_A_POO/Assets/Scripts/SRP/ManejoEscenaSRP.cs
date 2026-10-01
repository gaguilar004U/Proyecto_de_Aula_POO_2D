using UnityEngine;
using UnityEngine.SceneManagement;

public class ManejoEscenaSRP : MonoBehaviour
{
    public void ReiniciarNivel()
    {
        int indiceEscenaActual = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(indiceEscenaActual);
    }
}
