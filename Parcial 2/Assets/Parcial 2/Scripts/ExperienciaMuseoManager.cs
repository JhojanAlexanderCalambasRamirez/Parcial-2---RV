using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ExperienciaMuseoManager : MonoBehaviour
{
    public GameObject[] piezas3D;  // Prefabs 3D de las piezas
    public string[] titulosPiezas;  // Títulos de las piezas
    public string[] textosInformativos;  // Textos informativos de las piezas

    public TMP_Text textTituloPieza;
    public TMP_Text textContextoPieza;
    public TMP_Text textCantidadPiezas;

    public Button buttonSiguientePieza;
    public Button buttonRealizarQuiz;

    public GameObject panelExperienciaUAO;
    public GameObject panelQuizFinal;

    private int indicePiezaActual = 0;

    void Start()
    {
        buttonSiguientePieza.onClick.AddListener(MostrarSiguientePieza);
        buttonRealizarQuiz.onClick.AddListener(IrAlQuiz);

        buttonRealizarQuiz.interactable = false; // Inicialmente deshabilitado
        buttonSiguientePieza.interactable = true; // Siempre habilitado

        MostrarPiezaActual();
    }

    void MostrarPiezaActual()
    {
        if (indicePiezaActual >= 0 && indicePiezaActual < piezas3D.Length)
        {
            foreach (var pieza in piezas3D)
            {
                pieza.SetActive(false);
            }

            piezas3D[indicePiezaActual].SetActive(true);

            textTituloPieza.text = titulosPiezas[indicePiezaActual];
            textContextoPieza.text = textosInformativos[indicePiezaActual];
            textCantidadPiezas.text = $"{indicePiezaActual + 1}/{piezas3D.Length}";

            if (indicePiezaActual == piezas3D.Length - 1)
            {
                buttonRealizarQuiz.interactable = true;  // Habilitar el botón de realizar quiz
            }
        }
    }

    void MostrarSiguientePieza()
    {
        indicePiezaActual++;
        if (indicePiezaActual >= piezas3D.Length)
        {
            indicePiezaActual = 0;  // Reiniciar al inicio
        }
        MostrarPiezaActual();
    }

    void IrAlQuiz()
    {
        panelExperienciaUAO.SetActive(false);
        panelQuizFinal.SetActive(true);
    }

    public void ReiniciarExperiencia()
    {
        indicePiezaActual = 0;

        foreach (var pieza in piezas3D)
        {
            pieza.SetActive(false);
        }

        panelExperienciaUAO.SetActive(false);
        panelQuizFinal.SetActive(false);

        buttonSiguientePieza.interactable = true;  // Siempre habilitar el botón siguiente
        buttonRealizarQuiz.interactable = false;  // Deshabilitar el botón de realizar quiz

        MostrarPiezaActual();
    }
}
