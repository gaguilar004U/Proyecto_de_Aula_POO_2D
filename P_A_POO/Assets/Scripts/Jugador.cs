using System.Collections;
using UnityEngine;

public class Jugador : Personaje
{
    public float limiteCaida = -10f;
    // Atributos propios del jugador
    private int energia = 100;
    private int nivel = 1;
    private bool tocoCura = false;
    private Rigidbody2D rb;
    private int vidaJugador;
    private int monedas = 0;

    
    // Ataque
    //private int ataque = 20;

    // Propiedades para que la UI pueda consultar los datos
    public int VidaJugador => vidaJugador;
    public int Energia => energia;
    public int Nivel => nivel;
    public int Monedas => monedas;

    // Movimiento
    public float moveSpeed = 5f;

    // Salto
    public float jumpForce = 10f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    private bool isGrounded;

    void Start()
    {
        Debug.Log("Start ejecutado");
        rb = GetComponent<Rigidbody2D>();
        vidaJugador = Vida;
    }

    void Update()
    {
        Debug.Log("Update ejecutado");

        //direccion con teclas
        Mover();

        if (Input.GetKeyDown(KeyCode.Space) &&isGrounded)
        {
            Saltar();
        }

        if (transform.position.y < limiteCaida)
        {
            RecibirDanio(vidaJugador);
        }
    }
    public override void Mover()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
    }
    public override void Saltar()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            /*energia -= 25; agregar que por salto se agote la energia y no pueda saltar hasta que vuelva a llegar a 100*/
    }
    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(
            groundCheck.position,
            groundCheckRadius,
            groundLayer
        );
    }
    
    /*public override void RecibirDanio()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Dano")
        {
            vidaJugador -= 25;
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);

            //Debug
            Debug.Log("Vida: " + vidaJugador);

            if (vidaJugador <= 0)
            {
                Morir();
            }
        }
    }*/



    public override void RecibirDanio(int cantidad)
    {
        // Comportamiento adicional
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);

        // Ejecuta la lógica propia
        vidaJugador -= 25;
        if (vidaJugador <= 0)
        {
            Morir();
        }

        Debug.Log("Vida: " + vidaJugador);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Dano"))
        {
            RecibirDanio(25);
        }
    }
    public void atacar()
    {
        //Pendiente de integrar
    }
    
    public void recogerObjeto()
    {
        //Pendiente de integrar
    }

}