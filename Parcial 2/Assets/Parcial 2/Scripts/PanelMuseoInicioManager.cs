using UnityEngine;
using UnityEngine.UI;

public class PanelMuseoInicioManager : MonoBehaviour
{
    public Button botonContinuar;

    private void Start()
    {
        botonContinuar.onClick.AddListener(IniciarImageTargets);
    }

    // Función para iniciar la experiencia de Image Targets de Vuforia
    private void IniciarImageTargets()
    {
        // Aquí iría el código para inicializar Vuforia y los Image Targets
        Debug.Log("Iniciando los Image Targets...");
    }
}
