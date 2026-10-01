using UnityEngine;
public class Ganar : MonoBehaviour
{
    [SerializeField] private GameObject canvasVictoria;
    [SerializeField] private float tiempoEspera = 5f;
    private ManejoEscenaSRP escena;
    
    private void Awake()
    {
        escena = FindFirstObjectByType<ManejoEscenaSRP>();

        if (escena == null)
        {
            Debug.LogError("No se encontró el componente ManejoEscenaSRP en la escena.");
        }
    }
    private void Start()
    {
        canvasVictoria.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Win"))
        {
            canvasVictoria.SetActive(true);
            Time.timeScale = 0f;
            escena.SiguienteNivel();
        }
    }
}