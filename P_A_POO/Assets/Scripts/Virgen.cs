using UnityEngine;

public class Virgen : MonoBehaviour
{
    [Header("Asigna aquí tu Canvas/Panel")]
    [SerializeField] private GameObject canvasGanar;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (canvasGanar != null)
            {
                canvasGanar.SetActive(true);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (canvasGanar != null)
            {
                canvasGanar.SetActive(true);
            }
        }
    }
}