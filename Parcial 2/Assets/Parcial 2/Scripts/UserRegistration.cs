using UnityEngine;
using UnityEngine.UI;

public class UserRegistration : MonoBehaviour
{
    public InputField userNameInput; // Campo para ingresar el nombre
    public Button startButton; // Botón para comenzar la experiencia
    public GameObject panelMuseoInicio; // Panel de la experiencia

    void Start()
    {
        startButton.interactable = false;
        userNameInput.onValueChanged.AddListener(ValidateName);
        startButton.onClick.AddListener(StartExperience);
    }

    void ValidateName(string name)
    {
        startButton.interactable = name.Length >= 4; // Verificar longitud mínima
    }

    void StartExperience()
    {
        // Cambiar de panel
        panelMuseoInicio.SetActive(true);
        gameObject.SetActive(false);
    }
}
