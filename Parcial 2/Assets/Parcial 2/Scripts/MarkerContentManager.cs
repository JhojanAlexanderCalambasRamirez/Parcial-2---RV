using UnityEngine;
using Vuforia;

public class MarkerContentManager : MonoBehaviour
{
    public GameObject[] modelos3D;
    public AudioClip[] audios;
    public string[] textosInformativos;
    public GameObject[] guiasVirtuales;

    public UIManager uiManager;
    public AudioManager audioManager;

    private int markerIndex;

    private ObserverBehaviour observer;

    void Awake()
    {
        observer = GetComponent<ObserverBehaviour>();
        markerIndex = transform.GetSiblingIndex(); // Puedes ajustar este índice si lo necesitas

        if (observer)
        {
            observer.OnTargetStatusChanged += OnTargetStatusChanged;
        }
    }

    private void OnDestroy()
    {
        if (observer)
        {
            observer.OnTargetStatusChanged -= OnTargetStatusChanged;
        }
    }

    private void OnTargetStatusChanged(ObserverBehaviour behaviour, TargetStatus status)
    {
        if (status.Status == Status.TRACKED || status.Status == Status.EXTENDED_TRACKED)
        {
            ActivarContenido();
        }
        else
        {
            DesactivarContenido();
        }
    }

    void ActivarContenido()
    {
        if (modelos3D.Length > markerIndex && modelos3D[markerIndex])
            modelos3D[markerIndex].SetActive(true);

        if (guiasVirtuales.Length > markerIndex && guiasVirtuales[markerIndex])
            guiasVirtuales[markerIndex].SetActive(true);

        if (textosInformativos.Length > markerIndex)
            uiManager.MostrarTexto(textosInformativos[markerIndex]);

        if (audios.Length > markerIndex)
            audioManager.ReproducirAudio(audios[markerIndex]);
    }

    void DesactivarContenido()
    {
        if (modelos3D.Length > markerIndex && modelos3D[markerIndex])
            modelos3D[markerIndex].SetActive(false);

        if (guiasVirtuales.Length > markerIndex && guiasVirtuales[markerIndex])
            guiasVirtuales[markerIndex].SetActive(false);

        uiManager.OcultarTexto();
        audioManager.DetenerAudio();
    }
}
