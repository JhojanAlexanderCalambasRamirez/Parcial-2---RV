using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BirdAssistantManager : MonoBehaviour
{
    // Panel de ayuda y texto asociado
    public GameObject helpPanel;
    public TMP_Text helpText;

    // Enum de paneles
    public enum PanelType
    {
        Registro,
        MuseoInicio,
        ExperienciaUAO,
        QuizFinal,
        Resultados
    }

    // Diccionario con mensajes
    private Dictionary<PanelType, string> helpMessages = new Dictionary<PanelType, string>();

    // Diccionario con audios por panel
    private Dictionary<PanelType, AudioClip> panelAudios = new Dictionary<PanelType, AudioClip>();

    [Header("Audio por panel")]
    public AudioSource audioSource;
    public AudioClip audioRegistro;
    public AudioClip audioMuseoInicio;
    public AudioClip audioExperienciaUAO;
    public AudioClip audioQuizFinal;
    public AudioClip audioResultados;

    [Header("Animador del pajarito")]
    public Animator birdAnimator;

    private bool panelVisible = false;

    private void Start()
    {
        // Textos de ayuda
        helpMessages[PanelType.Registro] =
@"
Ingresa tu nombre para comenzar tu viaje virtual por el museo.

¿Cómo navegar?
• Escribe tu nombre en el recuadro.
• El botón 'Registrarse' se activará.
• Luego haz clic en 'Iniciar experiencia'.";

        helpMessages[PanelType.MuseoInicio] =
@"
Conoce el propósito de esta exposición y preparate para la exploración.

Recuerda:
Estás a punto de descubrir objetos que han viajado en el tiempo.";

        helpMessages[PanelType.ExperienciaUAO] =
@"
Explora las piezas del museo en 3D y aprende sobre su historia.

¿Cómo navegar?
• Toca o arrastra las piezas para rotarlas o escalarlas.
• Usa el botón 'Siguiente' para ver otra pieza.
• Cuando termines, se activará el botón para hacer el quiz.";

        helpMessages[PanelType.QuizFinal] =
@"
Demuestra lo que aprendiste respondiendo un quiz interactivo.

¿Cómo navegar?
• Lee la pregunta y selecciona tu respuesta (A, B o C).
• Al final, se activará el botón 'Ver resultado'.";

        helpMessages[PanelType.Resultados] =
@" ¿Cómo navegar?
• Toca la x para volver al inicio y registrar un nuevo usuario.

Recuerda:
Tu huella ya quedó en esta experiencia. ¡Gracias por hacer parte de la memoria del territorio!";

        // Audios por panel
        panelAudios[PanelType.Registro] = audioRegistro;
        panelAudios[PanelType.MuseoInicio] = audioMuseoInicio;
        panelAudios[PanelType.ExperienciaUAO] = audioExperienciaUAO;
        panelAudios[PanelType.QuizFinal] = audioQuizFinal;
        panelAudios[PanelType.Resultados] = audioResultados;

        // Ocultar el panel al inicio
        if (helpPanel != null)
            helpPanel.SetActive(false);
    }

    public void ShowHelpAuto()
    {
        if (helpPanel == null || helpText == null || PanelManager.Instance == null)
        {
            Debug.LogWarning("Faltan referencias en BirdAssistantManager.");
            return;
        }

        PanelType panel = DetectarPanelActivo();

        // Mostrar texto
        helpText.text = helpMessages.ContainsKey(panel)
            ? helpMessages[panel]
            : "No se encontró ayuda para este panel.";

        // Reproducir audio
        ReproducirAudioDelPanel(panel);

        helpPanel.SetActive(true);
    }

    public void HideHelp()
    {
        if (helpPanel != null)
            helpPanel.SetActive(false);

        if (audioSource != null)
            audioSource.Stop();
    }

    private PanelType DetectarPanelActivo()
    {
        if (PanelManager.Instance.panelRegistro.activeSelf) return PanelType.Registro;
        if (PanelManager.Instance.panelMuseoInicio.activeSelf) return PanelType.MuseoInicio;
        if (PanelManager.Instance.panelExperienciaUAO.activeSelf) return PanelType.ExperienciaUAO;
        if (PanelManager.Instance.panelQuizFinal.activeSelf) return PanelType.QuizFinal;
        if (PanelManager.Instance.panelResultados.activeSelf) return PanelType.Resultados;

        return PanelType.Registro; // por defecto
    }

    private void ReproducirAudioDelPanel(PanelType panel)
    {
        if (audioSource != null && panelAudios.ContainsKey(panel))
        {
            AudioClip clip = panelAudios[panel];
            if (clip != null)
            {
                audioSource.Stop();
                audioSource.clip = clip;
                audioSource.Play();
            }
        }
    }

    void Update()
    {
        // PC
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            CheckRaycast(ray);
        }

        // Móvil
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            CheckRaycast(ray);
        }
    }

    void CheckRaycast(Ray ray)
    {
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.gameObject == this.gameObject)
            {
                panelVisible = !panelVisible;

                if (panelVisible)
                {
                    ShowHelpAuto();
                    if (birdAnimator != null)
                        birdAnimator.SetTrigger("activar");
                }
                else
                {
                    HideHelp();
                    if (birdAnimator != null)
                        birdAnimator.SetTrigger("volver");
                }
            }
        }
    }
}
