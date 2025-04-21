using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    private float initialMouseY;
    private Vector3 initialScale;

    // Velocidad de rotación (más alto = más rápido)
    public float rotationSpeed = 0.5f;

    // Factor de escalado (más alto = más sensible)
    public float scaleSpeed = 0.1f;

    // Tasa de interpolación para un escalado más suave
    public float scaleSmoothness = 0.1f;

    private void Update()
    {
        // Para dispositivos táctiles (un solo dedo para rotación)
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                float rotX = touch.deltaPosition.x * rotationSpeed; // Usa la variable de velocidad
                transform.Rotate(0, -rotX, 0); // Rotación en el eje Y
            }
        }

        // Para escritorio (mouse para rotación)
        if (Input.GetMouseButton(0)) // 0 es el botón izquierdo del ratón
        {
            float rotX = Input.GetAxis("Mouse X") * rotationSpeed; // Usa la variable de velocidad
            transform.Rotate(0, -rotX, 0); // Rotación en el eje Y
        }

        // Para escalar con el ratón (botón derecho presionado y movimiento hacia arriba/abajo)
        if (Input.GetMouseButton(1)) // Si el botón derecho del ratón está presionado
        {
            // Calculamos la diferencia de movimiento en el eje Y del mouse
            float mouseDeltaY = Input.GetAxis("Mouse Y");

            // Si es la primera vez que detectamos el movimiento, guardamos la posición inicial
            if (initialMouseY == 0)
            {
                initialMouseY = Input.mousePosition.y;
                initialScale = transform.localScale;
            }

            // Calculamos el factor de escalado
            float scaleFactor = 1 + (mouseDeltaY * scaleSpeed);  // Puedes ajustar la velocidad multiplicando por scaleSpeed

            // Usamos Lerp para suavizar el cambio de escala (escalado progresivo)
            transform.localScale = Vector3.Lerp(transform.localScale, initialScale * scaleFactor, scaleSmoothness);

            // También puedes ajustar la escala mínima y máxima para evitar que el objeto se haga demasiado pequeño o grande
            transform.localScale = Vector3.Max(transform.localScale, Vector3.one * 0.1f); // Escala mínima
            transform.localScale = Vector3.Min(transform.localScale, Vector3.one * 5f); // Escala máxima
        }
    }
}
