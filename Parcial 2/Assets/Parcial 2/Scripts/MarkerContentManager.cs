using UnityEngine;
using Vuforia;
using TMPro;

public class MarkerContentManager : MonoBehaviour
{
    public GameObject[] modelos3D;  // Modelos 3D asociados a los marcadores
    public AudioClip[] audios;      // Audios asociados a los marcadores
    public string[] textosInformativos;  // Textos informativos asociados a los marcadores
    public string[] titulosPieza;      // Títulos de las piezas

    public UIManager uiManager;
    public AudioManager audioManager;

    public ObserverBehaviour[] imageTargets;  // Array para manejar múltiples Image Targets

    private int markerIndex;

    void Awake()
    {
        // Asegúrate de que haya al menos un Image Target en el array
        if (imageTargets.Length == 0)
        {
            Debug.LogError("No se han asignado Image Targets.");
            return;
        }

        // Asigna el comportamiento de cada Image Target
        foreach (var observer in imageTargets)
        {
            observer.OnTargetStatusChanged += OnTargetStatusChanged;
        }
    }

    private void OnDestroy()
    {
        // Desuscribirse de los eventos al destruir el objeto
        foreach (var observer in imageTargets)
        {
            if (observer != null)
            {
                observer.OnTargetStatusChanged -= OnTargetStatusChanged;
            }
        }
    }

    private void OnTargetStatusChanged(ObserverBehaviour behaviour, TargetStatus status)
    {
        // Identifica el índice del Image Target detectado
        markerIndex = System.Array.IndexOf(imageTargets, behaviour);

        // Si el marcador es detectado (TRACKED o EXTENDED_TRACKED)
        if (status.Status == Status.TRACKED || status.Status == Status.EXTENDED_TRACKED)
        {
            ActivarContenido();
        }
        else
        {
            DesactivarContenido();
        }
    }

    // Activar el contenido cuando el marcador es detectado
    void ActivarContenido()
    {
        if (modelos3D.Length > markerIndex && modelos3D[markerIndex] != null)
            modelos3D[markerIndex].SetActive(true);  // Activar el modelo 3D

        if (textosInformativos.Length > markerIndex)
            uiManager.MostrarTexto(textosInformativos[markerIndex]);  // Mostrar el texto informativo

        if (titulosPieza.Length > markerIndex)
            uiManager.MostrarTitulo(titulosPieza[markerIndex]);  // Mostrar el título de la pieza

        if (audios.Length > markerIndex)
            audioManager.ReproducirAudio(audios[markerIndex]);  // Reproducir el audio correspondiente
    }

    // Desactivar el contenido cuando el marcador deja de ser detectado
    void DesactivarContenido()
    {
        if (modelos3D.Length > markerIndex && modelos3D[markerIndex])
            modelos3D[markerIndex].SetActive(false);  // Desactivar el modelo 3D

        uiManager.OcultarTexto();  // Ocultar el texto
        uiManager.OcultarTitulo();  // Ocultar el título
        audioManager.DetenerAudio();  // Detener el audio
    }
}
