using UnityEngine;

public class Jugador : Personaje
{
    // Atributos propios del jugador
    private int energia = 100;
    private int nivel = 1;
    private bool tocoCura = false;

    // Métodos propios del jugador
    void Update()
    {
        //direccion con teclas
        float direccion = Input.GetAxisRaw("Horizontal");
        Mover(direccion);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Saltar();
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            Atacar();
        }
    }
    public void Atacar()
    {
        Debug.Log(Nombre + "ataca");
    }

    public void RecogerObjeto()
    {
        Debug.Log(Nombre + " recogió");
    }
}