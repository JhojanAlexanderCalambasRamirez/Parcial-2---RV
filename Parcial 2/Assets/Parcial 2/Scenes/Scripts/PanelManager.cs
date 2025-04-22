using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PanelManager : MonoBehaviour
{
    // Instancia estática para el acceso global
    public static PanelManager Instance;

    // Referencias a los paneles
    public GameObject panelRegistro;
    public GameObject panelMuseoInicio;
    public GameObject panelExperienciaUAO;  // Panel donde se vive la experiencia del museo
    public GameObject panelQuizFinal;
    public GameObject panelResultados;  // Asegurándonos de tener este panel

    // Referencias a los botones
    public Button buttonRegistrarse;
    public Button buttonIniciarExperiencia;
    public Button buttonContinuarExp;

    // Referencia al InputField de nombre
    public TMP_InputField inputFieldNombre;

    // Variable para almacenar el nombre del usuario
    private string nombreUsuario;

    // Referencia a los textos donde mostrar el nombre
    public TMP_Text TMP_Text_ResultadosQuiz;

    void Awake()
    {
        // Si no hay ninguna instancia, asignar esta como la instancia.
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);  // Si ya existe una instancia, destruir el objeto actual.
        }
        DontDestroyOnLoad(gameObject); // Evitar que se destruya al cargar nuevas escenas
    }

    void Start()
    {
        // Asegurarnos de que el PanelRegistro sea el único visible al inicio
        MostrarPanelRegistro();

        // Agregar los listeners a los botones
        buttonRegistrarse.onClick.AddListener(RegistrarUsuario);
        buttonIniciarExperiencia.onClick.AddListener(IniciarExperiencia);
        buttonContinuarExp.onClick.AddListener(IniciarExperienciaUAO);

        // Deshabilitar los botones hasta que el nombre sea válido
        buttonRegistrarse.interactable = false;
        buttonIniciarExperiencia.interactable = false;

        // Asegurarnos de que el InputField sea interactuable
        inputFieldNombre.interactable = true;

        // Añadir el listener para el cambio en el InputField para validar el nombre
        inputFieldNombre.onValueChanged.AddListener(ValidarNombre);

        // Cargar el nombre guardado (si existe)
        if (PlayerPrefs.HasKey("NombreUsuario"))
        {
            nombreUsuario = PlayerPrefs.GetString("NombreUsuario");
            inputFieldNombre.text = nombreUsuario;  // Mostrar el nombre guardado en el InputField
        }
    }

    // Mostrar el PanelRegistro y ocultar el resto
    void MostrarPanelRegistro()
    {
        panelRegistro.SetActive(true);
        panelMuseoInicio.SetActive(false);
        panelExperienciaUAO.SetActive(false); // Aseguramos que este panel no esté visible aún
        panelQuizFinal.SetActive(false);
        panelResultados.SetActive(false);  // Asegurándonos de que este panel esté oculto al principio

        // Reiniciar el InputField y los botones
        inputFieldNombre.text = "";  // Limpiar el input de nombre
        buttonRegistrarse.interactable = false;
        buttonIniciarExperiencia.interactable = false;
    }

    // Mostrar el PanelMuseoInicio y ocultar el resto
    void MostrarPanelMuseoInicio()
    {
        panelRegistro.SetActive(false);
        panelMuseoInicio.SetActive(true);
        panelExperienciaUAO.SetActive(false);
        panelQuizFinal.SetActive(false);
        panelResultados.SetActive(false);  // Asegurándonos de que este panel esté oculto al ir al Museo
    }

    // Mostrar el PanelExperienciaUAO (la experiencia del museo) y ocultar los demás
    void MostrarPanelExperienciaUAO()
    {
        panelRegistro.SetActive(false);
        panelMuseoInicio.SetActive(false);
        panelExperienciaUAO.SetActive(true);
        panelQuizFinal.SetActive(false);
        panelResultados.SetActive(false);  // Asegurándonos de que este panel esté oculto
    }

    // Mostrar el PanelQuizFinal y ocultar el resto (al final de la experiencia)
    void MostrarPanelQuizFinal()
    {
        panelRegistro.SetActive(false);
        panelMuseoInicio.SetActive(false);
        panelExperienciaUAO.SetActive(false);
        panelQuizFinal.SetActive(true);
        panelResultados.SetActive(false);  // Asegurándonos de que este panel esté oculto al final del quiz
    }

    // Habilitar el botón de registro cuando el nombre tenga al menos 4 caracteres
    public void ValidarNombre(string nombre)
    {
        if (nombre.Length >= 4)
        {
            buttonRegistrarse.interactable = true;  // Habilitar el botón de registrarse
        }
        else
        {
            buttonRegistrarse.interactable = false; // Deshabilitar el botón si el nombre es menor a 4 caracteres
        }
    }

    // Guardar el nombre del usuario y almacenarlo en PlayerPrefs
    void RegistrarUsuario()
    {
        nombreUsuario = inputFieldNombre.text;
        Debug.Log("Nombre del usuario registrado: " + nombreUsuario);

        // Guardar el nombre en PlayerPrefs (persistencia)
        PlayerPrefs.SetString("NombreUsuario", nombreUsuario);
        PlayerPrefs.Save();  // Asegurarse de guardar los datos

        // Deshabilitar el botón de registrarse y habilitar el botón para iniciar la experiencia
        buttonRegistrarse.interactable = false;
        buttonIniciarExperiencia.interactable = true;
    }

    // Mostrar el PanelMuseoInicio cuando el usuario hace clic en "IniciarExperiencia"
    void IniciarExperiencia()
    {
        MostrarPanelMuseoInicio();
    }

    // Lógica para cambiar al PanelExperienciaUAO después de presionar "Button_ContinuarExp"
    void IniciarExperienciaUAO()
    {
        MostrarPanelExperienciaUAO();
        Debug.Log("Iniciando la experiencia del museo...");
    }

    // Aquí podrías implementar la lógica para comenzar a mostrar las piezas del museo (Image Targets de Vuforia)
    void IniciarPiezasMuseo()
    {
        Debug.Log("Iniciando la experiencia del museo...");
        MostrarPanelQuizFinal();
    }

    // Método para actualizar el nombre del usuario en el panel de resultados
    public void SetNombreUsuario(string nombre)
    {
        // Asignar el nombre al texto de resultados
        TMP_Text_ResultadosQuiz.text = nombre;
    }

    // Método para reiniciar la experiencia, se ejecuta cuando se termina el quiz
    public void ReiniciarExperiencia()
    {
        // Limpiar los campos y deshabilitar botones
        inputFieldNombre.text = "";  // Limpiar el input de nombre
        buttonRegistrarse.interactable = false;
        buttonIniciarExperiencia.interactable = false;

        // Mostrar el panel de registro y ocultar los demás
        MostrarPanelRegistro();

        // Eliminar el nombre guardado de PlayerPrefs, reiniciando todo
        PlayerPrefs.DeleteKey("NombreUsuario");

        // Reiniciar cualquier estado relevante que deba resetearse en el juego
        // Ejemplo: limpiar los contadores o variables específicas
    }
}
