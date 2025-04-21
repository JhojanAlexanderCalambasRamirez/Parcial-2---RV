using UnityEngine;
using Vuforia;

public class ImageTargetManager : MonoBehaviour
{
    public GameObject panelRegistro; // El panel de registro
    private ObserverBehaviour observer;

    void Start()
    {
        // Obtén el componente ObserverBehaviour del Image Target
        observer = GetComponent<ObserverBehaviour>();

        // Verifica que el ObserverBehaviour esté presente
        if (observer)
        {
            // Suscríbete al evento de cambio de estado del marcador
            observer.OnTargetStatusChanged += OnTargetStatusChanged;
        }
    }

    private void OnDestroy()
    {
        if (observer)
        {
            // Desuscríbete del evento cuando el objeto se destruya
            observer.OnTargetStatusChanged -= OnTargetStatusChanged;
        }
    }

    // Este método se ejecuta cuando el estado del marcador cambia
    private void OnTargetStatusChanged(ObserverBehaviour behaviour, TargetStatus status)
    {
        // Si la imagen es detectada (TRACKED o EXTENDED_TRACKED), muestra el PanelRegistro
        if (status.Status == Status.TRACKED || status.Status == Status.EXTENDED_TRACKED)
        {
            panelRegistro.SetActive(true); // Mostrar el PanelRegistro
        }
        else
        {
            panelRegistro.SetActive(false); // Ocultar el PanelRegistro si no se detecta la imagen
        }
    }
}
