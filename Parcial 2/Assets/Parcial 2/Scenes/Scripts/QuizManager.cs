using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    // Arrays para preguntas y opciones
    public string[] preguntas;
    public string[] opcionesA;
    public string[] opcionesB;
    public string[] opcionesC;
    public int[] respuestasCorrectas;  // 0 = A, 1 = B, 2 = C

    // Referencias a los UI Elements
    public TMP_Text TMP_Text_CantidadPreguntas;
    public TMP_Text TMP_Text_Pregunta;
    public TMP_Text TMP_Text_Opciones;

    public Button botonOpcionA;
    public Button botonOpcionB;
    public Button botonOpcionC;
    public Button botonResultados;
    public Button botonReintentar;

    // Referencias a los Paneles
    public GameObject PanelQuizFinal;  // Referencia al panel del quiz
    public GameObject PanelResultados;  // Referencia al panel de resultados

    // Referencia para mostrar los resultados del quiz
    public TMP_Text TMP_Text_ResultadosQuiz;

    private int preguntaActual = 0;
    private int respuestasCorrectasCount = 0;
    private string nombreUsuario;

    void Start()
    {
        // Obtener el nombre del usuario desde PlayerPrefs
        nombreUsuario = PlayerPrefs.GetString("NombreUsuario", "Invitado");  // Cargar el nombre guardado en PlayerPrefs

        // Inicializamos el quiz
        botonResultados.interactable = false;  // Deshabilitar el botón de resultados hasta el final
        botonReintentar.gameObject.SetActive(false);  // Deshabilitar el botón de reintentar al inicio

        // Agregar listeners a las opciones
        botonOpcionA.onClick.AddListener(() => ComprobarRespuesta(0));
        botonOpcionB.onClick.AddListener(() => ComprobarRespuesta(1));
        botonOpcionC.onClick.AddListener(() => ComprobarRespuesta(2));

        botonResultados.onClick.AddListener(MostrarResultados);
        botonReintentar.onClick.AddListener(ReiniciarQuiz);

        MostrarPregunta();
    }

    // Mostrar la pregunta y las opciones actuales
    void MostrarPregunta()
    {
        if (preguntaActual < preguntas.Length)
        {
            TMP_Text_Pregunta.text = preguntas[preguntaActual];
            TMP_Text_Opciones.text = $"A) {opcionesA[preguntaActual]}\nB) {opcionesB[preguntaActual]}\nC) {opcionesC[preguntaActual]}";
            TMP_Text_CantidadPreguntas.text = $"{preguntaActual + 1}/{preguntas.Length}";
        }
    }

    // Comprobar la respuesta seleccionada
    void ComprobarRespuesta(int opcionSeleccionada)
    {
        if (opcionSeleccionada == respuestasCorrectas[preguntaActual])
        {
            respuestasCorrectasCount++;
        }

        // Pasar a la siguiente pregunta
        preguntaActual++;

        if (preguntaActual < preguntas.Length)
        {
            MostrarPregunta();
        }
        else
        {
            // Al finalizar las preguntas, habilitar el botón de resultados
            botonResultados.interactable = true;
        }
    }

    // Mostrar los resultados al final
    void MostrarResultados()
    {
        int puntaje = Mathf.FloorToInt((float)respuestasCorrectasCount / preguntas.Length * 5); // Calificación de 0 a 5

        // Mostrar el nombre y puntaje del usuario
        string resultado = $"{nombreUsuario}\nPuntaje: {puntaje}/5";
        TMP_Text_ResultadosQuiz.text = resultado;  // Aquí asignamos el texto para mostrar el puntaje

        // Ocultar el Panel Quiz y mostrar el Panel de Resultados
        PanelQuizFinal.SetActive(false);  // Asegúrate de tener este objeto en la jerarquía
        PanelResultados.SetActive(true);  // Asegúrate de tener este objeto en la jerarquía
        botonReintentar.gameObject.SetActive(true);  // Mostrar el botón de reintentar
    }

    // Reiniciar el quiz
    void ReiniciarQuiz()
    {
        preguntaActual = 0;
        respuestasCorrectasCount = 0;
        MostrarPregunta();
        botonResultados.interactable = false;
        botonReintentar.gameObject.SetActive(false);

        PanelResultados.SetActive(false);
        PanelQuizFinal.SetActive(true);  // Volver a mostrar el panel del quiz
    }
}
