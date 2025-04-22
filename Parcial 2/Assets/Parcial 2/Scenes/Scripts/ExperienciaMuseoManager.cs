using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ExperienciaMuseoManager : MonoBehaviour
{
    // Arrays de las piezas
    public GameObject[] piezas3D;  // Prefabs 3D de las piezas
    public string[] titulosPiezas;  // Títulos de las piezas
    public string[] textosInformativos;  // Textos informativos de las piezas

    // Textos TMP en la escena
    public TMP_Text textTituloPieza;  // Título de la pieza
    public TMP_Text textContextoPieza;  // Texto descriptivo de la pieza
    public TMP_Text textCantidadPiezas;  // Contador de las piezas

    // Botón para pasar a la siguiente pieza
    public Button buttonSiguientePieza;
    public Button buttonRealizarQuiz;  // Nuevo botón para ir al quiz

    // Paneles
    public GameObject panelExperienciaUAO;  // Panel donde se gestionan las piezas
    public GameObject panelQuizFinal;  // Panel donde se realiza el quiz

    private int indicePiezaActual = 0;  // Contador de la pieza actual

    void Start()
    {
        // Asignamos el listener al botón
        buttonSiguientePieza.onClick.AddListener(MostrarSiguientePieza);
        buttonRealizarQuiz.onClick.AddListener(IrAlQuiz);  // Asignamos la acción al botón de realizar quiz

        // Deshabilitamos el botón de realizar quiz al inicio
        buttonRealizarQuiz.interactable = false;

        // Mostrar la primera pieza al inicio
        MostrarPiezaActual();
    }

    // Mostrar la pieza actual
    void MostrarPiezaActual()
    {
        // Verificar que la pieza actual esté dentro del rango del array
        if (indicePiezaActual >= 0 && indicePiezaActual < piezas3D.Length)
        {
            // Desactivar todas las piezas
            foreach (var pieza in piezas3D)
            {
                pieza.SetActive(false);
            }

            // Activar la pieza actual
            piezas3D[indicePiezaActual].SetActive(true);

            // Actualizar el título, contexto y contador
            textTituloPieza.text = titulosPiezas[indicePiezaActual];
            textContextoPieza.text = textosInformativos[indicePiezaActual];
            textCantidadPiezas.text = $"{indicePiezaActual + 1}/{piezas3D.Length}";

            // Habilitar el botón de realizar quiz si hemos visto todas las piezas
            if (indicePiezaActual == piezas3D.Length - 1)
            {
                buttonRealizarQuiz.interactable = true;  // Habilitar el botón de realizar quiz
            }
        }
    }

    // Cambiar a la siguiente pieza
    void MostrarSiguientePieza()
    {
        // Aumentar el índice de la pieza
        indicePiezaActual++;

        // Si llegamos al final del array, volvemos a la primera pieza
        if (indicePiezaActual >= piezas3D.Length)
        {
            indicePiezaActual = 0;  // Reiniciar al inicio
        }

        // Mostrar la pieza actual
        MostrarPiezaActual();
    }

    // Llamado cuando se presiona el botón "Button_RealizarQuiz"
    void IrAlQuiz()
    {
        // Mostrar el mensaje en consola para confirmar que la lógica se ejecuta correctamente
        Debug.Log("Navegando al Panel QuizFinal...");

        // Desactivar el PanelExperienciaUAO (si es que ya está activo)
        panelExperienciaUAO.SetActive(false);

        // Activar el PanelQuizFinal
        panelQuizFinal.SetActive(true);

        // Confirmar que se ha cambiado correctamente
        Debug.Log("Se activó el PanelQuizFinal");
    }
}
