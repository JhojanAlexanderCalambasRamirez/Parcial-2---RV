using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    private float initialDistance;
    private Vector3 initialScale;

    public float rotationSpeed = 0.5f;
    public float scaleSpeed = 0.005f;
    public float scaleSmoothness = 0.1f;

    void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                float rotX = touch.deltaPosition.x * rotationSpeed;
                transform.Rotate(0, -rotX, 0);
            }
        }
        else if (Input.touchCount == 2)
        {
            // Obtener ambos toques
            Touch touch0 = Input.GetTouch(0);
            Touch touch1 = Input.GetTouch(1);

            // Calcular distancia entre los dos toques
            float currentDistance = Vector2.Distance(touch0.position, touch1.position);

            if (touch1.phase == TouchPhase.Began)
            {
                initialDistance = currentDistance;
                initialScale = transform.localScale;
            }
            else if (touch0.phase == TouchPhase.Moved || touch1.phase == TouchPhase.Moved)
            {
                if (Mathf.Approximately(initialDistance, 0))
                    return;

                float scaleFactor = (currentDistance / initialDistance);

                Vector3 targetScale = initialScale * scaleFactor;

                // Limitar la escala mínima y máxima
                targetScale = Vector3.Max(targetScale, Vector3.one * 0.1f);
                targetScale = Vector3.Min(targetScale, Vector3.one * 5f);

                transform.localScale = Vector3.Lerp(transform.localScale, targetScale, scaleSmoothness);
            }
        }
        else
        {
            // Rotación con mouse en escritorio
            if (Input.GetMouseButton(0))
            {
                float rotX = Input.GetAxis("Mouse X") * rotationSpeed;
                transform.Rotate(0, -rotX, 0);
            }

            // Escalado con mouse (botón derecho)
            if (Input.GetMouseButton(1))
            {
                float mouseDeltaY = Input.GetAxis("Mouse Y");

                if (initialDistance == 0)
                {
                    initialDistance = Input.mousePosition.y;
                    initialScale = transform.localScale;
                }

                float scaleFactor = 1 + (mouseDeltaY * scaleSpeed);

                Vector3 targetScale = initialScale * scaleFactor;
                targetScale = Vector3.Max(targetScale, Vector3.one * 0.1f);
                targetScale = Vector3.Min(targetScale, Vector3.one * 5f);

                transform.localScale = Vector3.Lerp(transform.localScale, targetScale, scaleSmoothness);
            }
            else
            {
                // Reset el valor inicial cuando no estamos escalando
                initialDistance = 0;
            }
        }
    }
}
