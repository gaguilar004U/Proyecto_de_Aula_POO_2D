using UnityEngine;

public class MovimientoPersonajeSRP : MonoBehaviour
{
    private PersonajeSRP personaje;
    private Rigidbody2D rb;

    [Header("Movimiento")]
    [SerializeField] private float moveSpeed = 5f;

    [Header("Salto")]
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.2f;
    [SerializeField] private LayerMask groundLayer;

    private bool isGrounded;

    public bool EstaEnElSuelo
    {
        get { return isGrounded; }
    }

    private void Awake()
    {
        personaje = GetComponent<PersonajeSRP>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void Mover(float direccion)
    {
        rb.linearVelocity = new Vector2(
            direccion * moveSpeed,
            rb.linearVelocity.y
        );
    }

    public void Saltar()
    {
        if (isGrounded)
        {
            rb.linearVelocity = new Vector2(
                rb.linearVelocity.x,
                jumpForce
            );
        }
    }

    private void FixedUpdate()
    {
        if (groundCheck != null)
        {
            isGrounded = Physics2D.OverlapCircle(
                groundCheck.position,
                groundCheckRadius,
                groundLayer
            );
        }
    }

    public void ImpulsarHaciaArriba()
    {
        rb.linearVelocity = new Vector2(
            rb.linearVelocity.x,
            jumpForce
        );
    }
}
