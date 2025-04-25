using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PanelExperienciaUAO : MonoBehaviour
{
    public Button buttonSiguientePieza;
    public Button buttonAnteriorPieza;  // Botón para retroceder a la pieza anterior
    public Button buttonRealizarQuiz;
    public TMP_Text textoTituloPieza;
    public TMP_Text textoDescripcionPieza;
    public TMP_Text textoCantidadPiezas;
    public GameObject[] piezas;  // Array para las piezas y sus prefabs (debe configurarse en el Inspector)

    // Arrays de textos y títulos, pueden ser modificados en el Inspector
    public string[] titulosPiezas;
    public string[] descripcionesPiezas;

    private int piezasVistas = 0;
    private int totalPiezas;

    private PanelManager panelManager;  // Referencia al PanelManager

    void Start()
    {
        panelManager = FindObjectOfType<PanelManager>();  // Obtener el PanelManager en la escena

        totalPiezas = piezas.Length;

        // Inicializar botones
        buttonSiguientePieza.onClick.AddListener(AvanzarPieza);
        buttonAnteriorPieza.onClick.AddListener(RegresarPieza);  // Acción para retroceder a la pieza anterior
        buttonRealizarQuiz.interactable = false;  // Inicialmente inhabilitado

        // Mostrar la primera pieza al inicio
        MostrarPieza(piezasVistas);
    }

    void AvanzarPieza()
    {
        piezasVistas++;

        // Si hay más piezas, mostramos la siguiente
        if (piezasVistas < totalPiezas)
        {
            MostrarPieza(piezasVistas);
        }
        else
        {
            // Si hemos visto todas las piezas, habilitamos el botón para realizar el quiz
            buttonRealizarQuiz.interactable = true;
        }
    }

    void RegresarPieza()
    {
        // Si no estamos en la primera pieza, retrocedemos una
        if (piezasVistas > 0)
        {
            piezasVistas--;
            MostrarPieza(piezasVistas);  // Muestra la pieza anterior
        }
    }

    void MostrarPieza(int indice)
    {
        // Asegurarnos de que hay datos disponibles para la pieza actual
        if (indice < titulosPiezas.Length && indice < descripcionesPiezas.Length)
        {
            // Mostrar los textos relacionados con la pieza
            textoTituloPieza.text = titulosPiezas[indice];  // Título de la pieza
            textoDescripcionPieza.text = descripcionesPiezas[indice];  // Descripción de la pieza

            // Mostrar cuántas piezas se han visto
            textoCantidadPiezas.text = (indice + 1) + "/" + totalPiezas;

            // Activar solo la pieza correspondiente
            for (int i = 0; i < piezas.Length; i++)
            {
                piezas[i].SetActive(i == indice);  // Activar solo la pieza actual
            }

            Debug.Log("Pieza " + (indice + 1) + " de " + totalPiezas + " vista.");
        }
        else
        {
            Debug.LogError("Índice fuera de rango para títulos o descripciones.");
        }
    }

    // Función para resetear el estado del panel
    public void ResetearEstado()
    {
        piezasVistas = 0;
        buttonRealizarQuiz.interactable = false;
        MostrarPieza(piezasVistas);
    }

    public void IniciarQuiz()
    {
        // Aquí se cambia al PanelQuizFinal
        Debug.Log("Iniciando el quiz");
        panelManager.IrAlPanelQuizFinal();  // Llamada al PanelManager para cambiar de panel
    }
}
