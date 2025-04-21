using UnityEngine;
using UnityEngine.UI;

public class PanelNavigationManager : MonoBehaviour
{
    public GameObject panelRegistro;
    public GameObject panelMuseoInicio;
    public GameObject panelQuizFinal;
    public GameObject panelGuiaVirtual; // Si lo tienes en el flujo

    public Button botonIniciar;
    public Button botonContinuar; // Botón para continuar en PanelMuseoInicio

    private void Start()
    {
        // Asegurarnos de que solo se muestre el Panel de Registro al inicio
        MostrarPanelRegistro();

        // Agregar listeners a los botones
        botonIniciar.onClick.AddListener(IniciarExperiencia);
        botonContinuar.onClick.AddListener(IniciarImageTargets); // Este inicia la experiencia en el museo
    }

    // Mostrar el Panel de Registro y ocultar los demás
    private void MostrarPanelRegistro()
    {
        panelRegistro.SetActive(true);
        panelMuseoInicio.SetActive(false);
        panelQuizFinal.SetActive(false);
        panelGuiaVirtual.SetActive(false); // Si lo tienes en el flujo
    }

    // Mostrar el Panel de Museo y ocultar los demás
    private void MostrarPanelMuseo()
    {
        panelRegistro.SetActive(false);
        panelMuseoInicio.SetActive(true);
        panelQuizFinal.SetActive(false);
        panelGuiaVirtual.SetActive(false); // Si lo tienes en el flujo
    }

    // Mostrar el Panel de Quiz al final
    private void MostrarPanelQuiz()
    {
        panelRegistro.SetActive(false);
        panelMuseoInicio.SetActive(false);
        panelQuizFinal.SetActive(true);
        panelGuiaVirtual.SetActive(false); // Si lo tienes en el flujo
    }

    // Lógica cuando el usuario presiona el botón "Iniciar" en el PanelRegistro
    private void IniciarExperiencia()
    {
        // Aquí puedes guardar el nombre en JSON si lo necesitas
        // Mostrar el PanelMuseoInicio
        MostrarPanelMuseo();
    }

    // Lógica para iniciar la experiencia en el museo cuando el usuario presiona "Continuar" en el PanelMuseoInicio
    private void IniciarImageTargets()
    {
        // Aquí se inicia la experiencia de RA con Vuforia
        // Mostrar el Panel de la Guía Virtual o el siguiente paso si es necesario
        MostrarPanelQuiz();
    }
}
