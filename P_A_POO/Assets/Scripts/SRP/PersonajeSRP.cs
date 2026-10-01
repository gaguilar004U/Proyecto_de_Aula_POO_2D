using UnityEngine;

public class PersonajeSRP : MonoBehaviour
{
    [Header("Datos del personaje")]
    [SerializeField] private string nombre;
    [SerializeField] private int velocidad = 5;

    public string Nombre
    {
        get { return nombre; }
        private set { nombre = value; }
    }

    public int Velocidad
    {
        get { return velocidad; }
        private set { velocidad = value; }
    }
}
