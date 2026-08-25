using UnityEngine;

public class Enemigo : Personaje
{
    private string tipo;
    
    public float speed = 2f;
    public Transform[] points;

    private int i;

    void Start()
    {

    }

    void Update()
    {
        Mover();
    }

    public override void Mover()
    {
        if (Vector2.Distance(transform.position, points[i].position) < 0.25f)
        {
            i++;

            if (i == points.Length)
            {
                i = 0;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
    }
}
