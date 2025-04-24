using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public string[] preguntas;
    public string[] opcionesA;
    public string[] opcionesB;
    public string[] opcionesC;
    public int[] respuestasCorrectas;

    public TMP_Text TMP_Text_CantidadPreguntas;
    public TMP_Text TMP_Text_Pregunta;
    public TMP_Text TMP_Text_Opciones;

    public Button botonOpcionA;
    public Button botonOpcionB;
    public Button botonOpcionC;
    public Button botonResultados;
    public Button botonReintentar;

    public GameObject PanelQuizFinal;
    public GameObject PanelResultados;
    public TMP_Text TMP_Text_ResultadosQuiz;

    private int preguntaActual = 0;
    private int respuestasCorrectasCount = 0;
    private string nombreUsuario;

    void Start()
    {
        nombreUsuario = PlayerPrefs.GetString("NombreUsuario", "Invitado");

        botonResultados.interactable = false;
        botonReintentar.gameObject.SetActive(false);

        botonOpcionA.onClick.AddListener(() => ComprobarRespuesta(0));
        botonOpcionB.onClick.AddListener(() => ComprobarRespuesta(1));
        botonOpcionC.onClick.AddListener(() => ComprobarRespuesta(2));

        botonResultados.onClick.AddListener(MostrarResultados);
        botonReintentar.onClick.AddListener(ReiniciarQuiz);

        MostrarPregunta();
    }

    void MostrarPregunta()
    {
        if (preguntaActual < preguntas.Length)
        {
            TMP_Text_Pregunta.text = preguntas[preguntaActual];
            TMP_Text_Opciones.text = $"A) {opcionesA[preguntaActual]}\nB) {opcionesB[preguntaActual]}\nC) {opcionesC[preguntaActual]}";
            TMP_Text_CantidadPreguntas.text = $"{preguntaActual + 1}/{preguntas.Length}";
        }
    }

    void ComprobarRespuesta(int opcionSeleccionada)
    {
        if (opcionSeleccionada == respuestasCorrectas[preguntaActual])
        {
            respuestasCorrectasCount++;
        }

        preguntaActual++;

        if (preguntaActual < preguntas.Length)
        {
            MostrarPregunta();
        }
        else
        {
            botonResultados.interactable = true;
        }
    }

    void MostrarResultados()
    {
        int puntaje = Mathf.FloorToInt((float)respuestasCorrectasCount / preguntas.Length * 5);

        // Guardamos el puntaje y el nombre en el archivo JSON (instancia del UsuarioManager)
        UsuarioManager.Instance.GuardarUsuarios(new UsuarioManager.Usuario(nombreUsuario, puntaje));

        // Mostrar el panel de resultados
        TMP_Text_ResultadosQuiz.text = $"{nombreUsuario}\nPuntaje: {puntaje}/5";
        PanelQuizFinal.SetActive(false);
        PanelResultados.SetActive(true);
        botonReintentar.gameObject.SetActive(true);
    }

    void ReiniciarQuiz()
    {
        preguntaActual = 0;
        respuestasCorrectasCount = 0;
        MostrarPregunta();
        botonResultados.interactable = false;
        botonReintentar.gameObject.SetActive(false);

        PanelResultados.SetActive(false);
        PanelQuizFinal.SetActive(true);
    }
}
