using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    [System.Serializable]
    public class Pregunta
    {
        public string enunciado;
        public string[] opciones;
        public int respuestaCorrecta;
    }

    public Pregunta[] preguntas;
    public TMP_Text textoPregunta;
    public Button[] botonesRespuesta;
    public GameObject panelQuiz;
    public TMP_Text resultadoFinal;

    private int preguntaActual = 0;
    private int respuestasCorrectas = 0;

    void Start()
    {
        MostrarPregunta();
    }

    public void MostrarPregunta()
    {
        if (preguntaActual >= preguntas.Length)
        {
            MostrarResultados();
            return;
        }

        Pregunta p = preguntas[preguntaActual];
        textoPregunta.text = p.enunciado;

        for (int i = 0; i < botonesRespuesta.Length; i++)
        {
            botonesRespuesta[i].GetComponentInChildren<TMP_Text>().text = p.opciones[i];
            int index = i;
            botonesRespuesta[i].onClick.RemoveAllListeners();
            botonesRespuesta[i].onClick.AddListener(() => SeleccionarRespuesta(index));
        }
    }

    void SeleccionarRespuesta(int index)
    {
        if (index == preguntas[preguntaActual].respuestaCorrecta)
            respuestasCorrectas++;

        preguntaActual++;
        MostrarPregunta();
    }

    void MostrarResultados()
    {
        panelQuiz.SetActive(false);
        resultadoFinal.gameObject.SetActive(true);
        resultadoFinal.text = $"Tuviste {respuestasCorrectas} de {preguntas.Length} correctas.";
    }
}
