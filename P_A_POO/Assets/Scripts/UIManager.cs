using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("Textos")]
    [SerializeField] private TMP_Text textoVida;
    [SerializeField] private TMP_Text textoEnergia;
    [SerializeField] private TMP_Text textoMonedas;
    //[SerializeField] private TMP_Text textoKills;
    //[SerializeField] private TMP_Text textoObjetivos;
    [SerializeField] private TMP_Text textoNivel;
    [SerializeField] private TMP_Text textoTiempo;

    [Header("Jugador")]
    [SerializeField] private Jugador jugador;

    private float tiempo;
    //private int kills = 0;
    //private int objetivos = 0;
    //private int totalObjetivos = 10;
    private int nivel = 1;

    private void Update()
    {
        ActualizarTiempo();
        ActualizarUI();
    }

    private void ActualizarTiempo()
    {
        tiempo += Time.deltaTime;

        int minutos = Mathf.FloorToInt(tiempo / 60);
        int segundos = Mathf.FloorToInt(tiempo % 60);

        textoTiempo.text = "TIEMPO: " +
            minutos.ToString("00") + ":" +
            segundos.ToString("00");
    }

    private void ActualizarUI()
    {
        if (jugador == null)
            return;

        textoVida.text = "VIDA: " + jugador.VidaJugador;
        textoEnergia.text = "ENERGIA: " + jugador.Energia;
        textoMonedas.text = "MONEDAS: " + jugador.Monedas;
        //textoKills.text = "KILLS: " + kills;
        //textoObjetivos.text = "OBJETIVOS: " + objetivos + "/" + totalObjetivos;
        textoNivel.text = "NIVEL: " + nivel;
    }

  

    public void AgregarKill()
    {
        //kills++;
    }

    public void AgregarObjetivo()
    {
        //objetivos++;
    }

    public void SubirNivel()
    {
        nivel++;
    }
}