using UnityEngine;

public class PanelManager : MonoBehaviour
{
    public static PanelManager Instance;  // Agregar la propiedad est�tica Instance
    public GameObject panelRegistro;
    public GameObject panelMuseoInicio;
    public GameObject panelExperienciaUAO;
    public GameObject panelQuizFinal;
    public GameObject panelResultados;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Inicializamos con el panel de registro visible
        MostrarPanel(panelRegistro);
    }

    // Funci�n para cambiar entre paneles
    public void MostrarPanel(GameObject panel)
    {
        // Desactivar todos los paneles
        panelRegistro.SetActive(false);
        panelMuseoInicio.SetActive(false);
        panelExperienciaUAO.SetActive(false);
        panelQuizFinal.SetActive(false);
        panelResultados.SetActive(false);

        // Activar el panel que se pasa como argumento
        panel.SetActive(true);
    }

    // Funci�n para cambiar al PanelRegistro y resetear el estado
    public void IrAlPanelRegistro()
    {
        // Resetear variables de los otros paneles
        ResetearPanelQuizFinal();
        ResetearPanelExperienciaUAO();

        MostrarPanel(panelRegistro);  // Cambia al PanelRegistro
    }

    // Resetear el estado del PanelQuizFinal
    private void ResetearPanelQuizFinal()
    {
        // Resetear el estado de PanelQuizFinal
        PanelQuizFinal quizPanel = panelQuizFinal.GetComponent<PanelQuizFinal>();
        quizPanel.ResetearEstado();
    }

    // Resetear el estado del PanelExperienciaUAO
    private void ResetearPanelExperienciaUAO()
    {
        // Resetear el progreso de PanelExperienciaUAO
        PanelExperienciaUAO piezaPanel = panelExperienciaUAO.GetComponent<PanelExperienciaUAO>();
        piezaPanel.ResetearEstado();
    }

    // Funci�n para cambiar al PanelMuseoInicio
    public void IrAlPanelMuseoInicio()
    {
        MostrarPanel(panelMuseoInicio);
    }

    // Funci�n para cambiar al PanelExperienciaUAO
    public void IrAlPanelExperienciaUAO()
    {
        MostrarPanel(panelExperienciaUAO);
    }

    // Funci�n para cambiar al PanelQuizFinal
    public void IrAlPanelQuizFinal()
    {
        MostrarPanel(panelQuizFinal);
    }

    // Funci�n para cambiar al PanelResultados
    public void IrAlPanelResultados()
    {
        MostrarPanel(panelResultados);
        panelResultados.GetComponent<PanelResultados>().MostrarResultados();
    }
}