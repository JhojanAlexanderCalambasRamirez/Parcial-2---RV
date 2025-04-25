using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class PanelQuizFinal : MonoBehaviour
{
    public TMP_Text TMP_Text_CantidadPreguntas;
    public TMP_Text TMP_Text_Pregunta;
    public TMP_Text TMP_Text_Opciones;

    public Button BotonOpcionA;
    public Button BotonOpcionB;
    public Button BotonOpcionC;
    public Button BotonResultados;

    private int preguntaActual = 0;
    private int respuestasCorrectas = 0;

    public string[] Preguntas;
    public string[] OpcionesA;
    public string[] OpcionesB;
    public string[] OpcionesC;

    public enum RespuestaCorrecta { OpcionA, OpcionB, OpcionC }
    public RespuestaCorrecta[] RespuestasCorrectas;

    private PanelManager panelManager;

    void Start()
    {
        panelManager = FindObjectOfType<PanelManager>();

        BotonOpcionA.onClick.AddListener(() => ResponderPregunta(0));
        BotonOpcionB.onClick.AddListener(() => ResponderPregunta(1));
        BotonOpcionC.onClick.AddListener(() => ResponderPregunta(2));
        BotonResultados.onClick.AddListener(MostrarResultados);

        BotonResultados.interactable = false;
        CargarPregunta();
    }

    void CargarPregunta()
    {
        TMP_Text_CantidadPreguntas.text = "Pregunta " + (preguntaActual + 1) + " de " + Preguntas.Length;
        TMP_Text_Pregunta.text = Preguntas[preguntaActual];
        TMP_Text_Opciones.text = "A. " + OpcionesA[preguntaActual] + "\nB. " + OpcionesB[preguntaActual] + "\nC. " + OpcionesC[preguntaActual];

        BotonOpcionA.interactable = true;
        BotonOpcionB.interactable = true;
        BotonOpcionC.interactable = true;

        if (preguntaActual == Preguntas.Length - 1)
        {
            BotonResultados.interactable = true;
        }
    }

    void ResponderPregunta(int opcionElegida)
    {
        if (opcionElegida == (int)RespuestasCorrectas[preguntaActual])
        {
            respuestasCorrectas++;
        }

        BotonOpcionA.interactable = false;
        BotonOpcionB.interactable = false;
        BotonOpcionC.interactable = false;

        if (preguntaActual < Preguntas.Length - 1)
        {
            preguntaActual++;
            CargarPregunta();
        }
        else
        {
            BotonResultados.interactable = true;
        }
    }

    void MostrarResultados()
    {
        // Guardamos el puntaje del usuario actual
        UsuarioManager.Instance.GuardarUsuario(UsuarioManager.nombreUsuarioActual, respuestasCorrectas);

        // Cambiamos al panel de resultados (este ya se encarga de cargar y mostrar el TMP_Text)
        panelManager.IrAlPanelResultados();
    }


    public void ResetearEstado()
    {
        preguntaActual = 0;
        respuestasCorrectas = 0;

        BotonResultados.interactable = false;
        TMP_Text_Pregunta.text = "";
        TMP_Text_Opciones.text = "";

        BotonOpcionA.interactable = true;
        BotonOpcionB.interactable = true;
        BotonOpcionC.interactable = true;
    }
}
