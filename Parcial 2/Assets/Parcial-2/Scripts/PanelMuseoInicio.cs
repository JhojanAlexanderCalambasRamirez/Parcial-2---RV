using UnityEngine;
using UnityEngine.UI;

public class PanelMuseoInicio : MonoBehaviour
{
    public Button buttonContinuarExp;
    private PanelManager panelManager;  // Referencia al PanelManager

    void Start()
    {
        panelManager = FindObjectOfType<PanelManager>();  // Encuentra el PanelManager en la escena
        buttonContinuarExp.onClick.AddListener(ContinuarExperiencia);
    }

    void ContinuarExperiencia()
    {
        // Cambiar al siguiente panel (PanelExperienciaUAO)
        Debug.Log("Iniciando la experiencia...");
        panelManager.IrAlPanelExperienciaUAO();  // Activa el PanelExperienciaUAO
    }
}
