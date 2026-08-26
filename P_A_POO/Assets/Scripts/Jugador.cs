using System.Collections;
using UnityEngine;

public class Jugador : Personaje
{
    // Atributos propios del jugador
    private int energia = 100;
    private int nivel = 1;
    private bool tocoCura = false;
    private Rigidbody2D rb;
    private int vidaJugador;

    // Ataque
    //private int ataque = 20;

    // Propiedades para que la UI pueda consultar los datos
    public int VidaJugador => vidaJugador;
    public int Energia => energia;
    public int Nivel => nivel;
   

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
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            /*energia -= 25; agregar que por salto se agote la energia y no pueda saltar hasta que vuelva a llegar a 100*/
        }
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(
            groundCheck.position,
            groundCheckRadius,
            groundLayer
        );
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
    }
}