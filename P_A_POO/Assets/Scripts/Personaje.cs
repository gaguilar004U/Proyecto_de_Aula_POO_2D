using UnityEngine;
using UnityEngine.SceneManagement;

public class Personaje : MonoBehaviour
{
    //base
    private string nombre;
    private int vida = 100;
    private int velocidad = 5;
    // Variables de solo lectura
    public string Nombre => nombre;
    public int Vida => vida;
    public int Velocidad => velocidad;
    
    public void Mover(float direccionX)
    {
        
        transform.Translate(Vector2.right * direccionX * velocidad * Time.deltaTime);
    }
    public void Saltar()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up, ForceMode2D.Impulse);
    }

    public void RecibirDanio(int cantidad)
    {
        vida -= cantidad;
        if (vida <= 0)
        {
            Morir();
        }
    }

    public virtual void Morir()
    {
        Debug.Log(nombre + "murió");
        //Destroy(GameObject.FindGameObjectWithTag("Player"));
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public virtual void Atacar()
    {
        Debug.Log(nombre + " atacó.");
    }
}