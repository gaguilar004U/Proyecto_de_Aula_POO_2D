    using System.Collections;
using UnityEngine;

public class Jugador : Personaje
{
    public float limiteCaida = -10f;
    private Rigidbody2D rb;
    private int vidaJugador;

    public float moveSpeed = 5f;

    public float jumpForce = 10f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    private bool isGrounded;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Falta el componente Rigidbody2D en " + gameObject.name);
        }
    }
    void Start()
    {
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

    public override void RecibirDanio(int cantidad)
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);

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
}