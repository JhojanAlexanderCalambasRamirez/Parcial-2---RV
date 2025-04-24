using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PanelManager : MonoBehaviour
{
    // Referencias a los paneles
    public GameObject panelRegistro;
    public GameObject panelMuseoInicio;
    public GameObject panelExperienciaUAO;
    public GameObject panelQuizFinal;
    public GameObject panelResultados;

    // Referencias a los botones
    public Button buttonRegistrarse;
    public Button buttonIniciarExperiencia;
    public Button buttonContinuarExp;
    public Button buttonSiguientePieza;
    public Button buttonRealizarQuiz;
    public Button buttonReintentar;
    public Button buttonResultados;

    // Referencia al InputField de nombre
    public TMP_InputField inputFieldNombre;
    public TMP_Text TMP_Text_ResultadosQuiz;

    private string nombreUsuario;

    void Start()
    {
        // Inicializa los paneles y los botones
        MostrarPanelRegistro();

        // Asignar los listeners a los botones
        buttonRegistrarse.onClick.AddListener(RegistrarUsuario);
        buttonIniciarExperiencia.onClick.AddListener(IniciarExperiencia);
        buttonContinuarExp.onClick.AddListener(IniciarExperienciaUAO);
        buttonSiguientePieza.onClick.AddListener(MostrarSiguientePieza);
        buttonRealizarQuiz.onClick.AddListener(IrAlQuiz);
        buttonReintentar.onClick.AddListener(ReiniciarQuiz);
        buttonResultados.onClick.AddListener(MostrarResultados);

        // Deshabilitar los botones inicialmente
        buttonRegistrarse.interactable = false;
        buttonIniciarExperiencia.interactable = false;
        buttonSiguientePieza.interactable = true;  // Siempre habilitar el botón siguiente
        buttonRealizarQuiz.interactable = false;
        buttonReintentar.gameObject.SetActive(false);

        // Añadir el listener al InputField para validar el nombre
        inputFieldNombre.onValueChanged.AddListener(ValidarNombre);
    }

    // Mostrar el panel de registro y ocultar los demás
    void MostrarPanelRegistro()
    {
        panelRegistro.SetActive(true);
        panelMuseoInicio.SetActive(false);
        panelExperienciaUAO.SetActive(false);
        panelQuizFinal.SetActive(false);
        panelResultados.SetActive(false);

        // Reiniciar el input de nombre y los botones
        inputFieldNombre.text = "";
        buttonRegistrarse.interactable = false;
        buttonIniciarExperiencia.interactable = false;
    }

    // Validar el nombre y habilitar el botón de registro
    public void ValidarNombre(string nombre)
    {
        if (nombre.Length >= 4)
        {
            buttonRegistrarse.interactable = true;  // Activar el botón de registrarse si el nombre tiene 4 o más caracteres
        }
        else
        {
            buttonRegistrarse.interactable = false;  // Desactivar el botón si el nombre tiene menos de 4 caracteres
        }
    }

    // Guardar el nombre en el archivo JSON y habilitar el botón de iniciar experiencia
    void RegistrarUsuario()
    {
        nombreUsuario = inputFieldNombre.text;
        Debug.Log("Nombre del usuario registrado: " + nombreUsuario);

        // Verificar si la instancia de UsuarioManager está inicializada
        if (UsuarioManager.Instance != null)
        {
            // Guardar el nombre en el archivo JSON (instancia del UsuarioManager)
            UsuarioManager.Instance.GuardarUsuarios(new UsuarioManager.Usuario(nombreUsuario, 0));

            // Deshabilitar el botón de registrarse y habilitar el botón de iniciar experiencia
            buttonRegistrarse.interactable = false;
            buttonIniciarExperiencia.interactable = true;
        }
        else
        {
            Debug.LogError("La instancia de UsuarioManager no está inicializada correctamente.");
        }
    }

    // Mostrar el panel de inicio de la experiencia
    void IniciarExperiencia()
    {
        MostrarPanelMuseoInicio();
    }

    // Mostrar el panel de la experiencia
    void IniciarExperienciaUAO()
    {
        MostrarPanelExperienciaUAO();
    }

    // Mostrar el siguiente objeto en el museo
    void MostrarSiguientePieza()
    {
        buttonRealizarQuiz.interactable = true;  // Habilitar el botón de quiz una vez se hayan visto todas las piezas
    }

    // Ir al panel del quiz
    void IrAlQuiz()
    {
        MostrarPanelQuizFinal();
    }

    // Mostrar el panel de quiz final
    void MostrarPanelQuizFinal()
    {
        panelRegistro.SetActive(false);
        panelMuseoInicio.SetActive(false);
        panelExperienciaUAO.SetActive(false);
        panelQuizFinal.SetActive(true);
        panelResultados.SetActive(false);
    }

    // Reiniciar el quiz
    void ReiniciarQuiz()
    {
        buttonReintentar.gameObject.SetActive(false);
        MostrarPanelQuizFinal();
    }

    // Mostrar los resultados
    void MostrarResultados()
    {
        Debug.Log("Resultados mostrados");
    }

    // Mostrar el PanelMuseoInicio
    void MostrarPanelMuseoInicio()
    {
        panelRegistro.SetActive(false);
        panelMuseoInicio.SetActive(true);
        panelExperienciaUAO.SetActive(false);
        panelQuizFinal.SetActive(false);
        panelResultados.SetActive(false);
    }

    // Mostrar el PanelExperienciaUAO
    void MostrarPanelExperienciaUAO()
    {
        panelRegistro.SetActive(false);
        panelMuseoInicio.SetActive(false);
        panelExperienciaUAO.SetActive(true);
        panelQuizFinal.SetActive(false);
        panelResultados.SetActive(false);
    }
}
