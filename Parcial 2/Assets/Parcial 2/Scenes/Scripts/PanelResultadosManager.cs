using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PanelResultadosManager : MonoBehaviour
{
    // Referencias a los paneles
    public GameObject panelRegistro;
    public GameObject panelQuizFinal;
    public GameObject panelResultados;

    // Referencias a los botones
    public Button botonFinalizar;
    public Button botonVolverPanelQuiz;

    // Referencia al texto que muestra los resultados
    public TMP_Text TMP_Text_ResultadosQuiz;

    // Variable para almacenar el nombre del usuario y su puntaje
    private string nombreUsuario;
    private int puntajeFinal;

    void Start()
    {
        // Configuración inicial: desactivar el panel de resultados hasta que sea necesario
        panelResultados.SetActive(false);

        // Asignar los listeners a los botones
        botonFinalizar.onClick.AddListener(Finalizar);
        botonVolverPanelQuiz.onClick.AddListener(VolverAlPanelQuiz);

        // Obtener el nombre del usuario desde PlayerPrefs si existe
        nombreUsuario = PlayerPrefs.GetString("NombreUsuario", "Invitado");
    }

    // Este método se llamará desde el script QuizManager.cs para establecer los resultados
    public void MostrarResultados(string nombre, int puntaje)
    {
        // Usamos el nombre pasado desde QuizManager en lugar de leerlo de PlayerPrefs nuevamente
        nombreUsuario = nombre;

        puntajeFinal = puntaje;

        // Mostrar el nombre del usuario y su puntaje final en el texto de resultados
        TMP_Text_ResultadosQuiz.text = $"{nombreUsuario}\nPuntaje: {puntajeFinal}/5";

        // Mostrar el panel de resultados
        panelQuizFinal.SetActive(false);  // Desactivar el panel del quiz
        panelResultados.SetActive(true);  // Activar el panel de resultados
    }

    // Cuando el usuario presiona "Finalizar", lo llevamos al panel de registro para iniciar con otro usuario
    void Finalizar()
    {
        panelResultados.SetActive(false);
        panelRegistro.SetActive(true);  // Regresar al panel de registro
    }

    // Cuando el usuario presiona "Volver al Panel Quiz", lo regresamos al panel de preguntas
    void VolverAlPanelQuiz()
    {
        panelResultados.SetActive(false);
        panelQuizFinal.SetActive(true);  // Regresar al panel de quiz para reiniciar las preguntas
    }
}
