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