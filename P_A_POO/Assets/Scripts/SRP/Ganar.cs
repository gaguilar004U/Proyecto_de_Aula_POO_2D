using UnityEngine;
public class Ganar : MonoBehaviour
{
    [SerializeField] private GameObject canvasVictoria;

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
        }
    }
}