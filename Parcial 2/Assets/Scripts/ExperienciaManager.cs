using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ExperienciaManager : MonoBehaviour
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

    // Variable para almacenar el nombre del usuario
    private string nombreUsuario;

    void Start()
    {
        // Deshabilitar los botones inicialmente
        buttonRegistrarse.interactable = false;
        buttonIniciarExperiencia.interactable = false;
        buttonSiguientePieza.interactable = false;
        buttonRealizarQuiz.interactable = false;
        buttonReintentar.gameObject.SetActive(false);

        // Añadir el listener al InputField para validar el nombre
        inputFieldNombre.onValueChanged.AddListener(ValidarNombre);
    }

    // Mostrar el panel de registro y ocultar los demás
    public void MostrarPanelRegistro()
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
            buttonRegistrarse.interactable = true; // Activar el botón de registrarse si el nombre tiene 4 o más caracteres
        }
        else
        {
            buttonRegistrarse.interactable = false; // Desactivar el botón si el nombre tiene menos de 4 caracteres
        }
    }

    // Guardar el nombre en el archivo JSON y habilitar el botón de iniciar experiencia
    public void RegistrarUsuario()
    {
        nombreUsuario = inputFieldNombre.text;
        Debug.Log("Nombre del usuario registrado: " + nombreUsuario);

        // Aquí puedes agregar el código para guardar el nombre del usuario en un archivo JSON o PlayerPrefs

        // Deshabilitar el botón de registrarse y habilitar el botón de iniciar experiencia
        buttonRegistrarse.interactable = false;
        buttonIniciarExperiencia.interactable = true;
    }

    // Mostrar el panel de inicio de la experiencia
    public void IniciarExperiencia()
    {
        MostrarPanelMuseoInicio();
    }

    // Mostrar el panel de la experiencia
    public void MostrarPanelMuseoInicio()
    {
        panelRegistro.SetActive(false);
        panelMuseoInicio.SetActive(true);
        panelExperienciaUAO.SetActive(false);
        panelQuizFinal.SetActive(false);
        panelResultados.SetActive(false);
    }

    // Mostrar el panel de la experiencia
    public void MostrarPanelExperienciaUAO()
    {
        panelRegistro.SetActive(false);
        panelMuseoInicio.SetActive(false);
        panelExperienciaUAO.SetActive(true);
        panelQuizFinal.SetActive(false);
        panelResultados.SetActive(false);

        // Habilitar el botón "SiguientePieza" al comenzar la experiencia
        buttonSiguientePieza.interactable = true;
    }

    // Mostrar el PanelQuizFinal
    public void MostrarPanelQuizFinal()
    {
        panelRegistro.SetActive(false);
        panelMuseoInicio.SetActive(false);
        panelExperienciaUAO.SetActive(false);
        panelQuizFinal.SetActive(true);
        panelResultados.SetActive(false);
    }

    // Función para reiniciar todos los paneles y botones
    public void ReiniciarExperiencia()
    {
        // Reiniciar los paneles
        MostrarPanelRegistro();

        // Limpiar el nombre del usuario
        inputFieldNombre.text = "";

        // Deshabilitar los botones de registro e inicio de experiencia
        buttonRegistrarse.interactable = false;
        buttonIniciarExperiencia.interactable = false;

        // Opcionalmente puedes borrar el nombre del usuario en PlayerPrefs si estás usando eso
        PlayerPrefs.DeleteKey("NombreUsuario");

        // Reiniciar cualquier otra cosa que sea necesario en la experiencia
        // ...
    }
}
