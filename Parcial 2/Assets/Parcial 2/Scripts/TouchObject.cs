using UnityEngine;

public class TouchObject : MonoBehaviour
{
    private Vector3 initialTouchPosition;
    private Vector3 initialObjectPosition;
    private float initialDistance;
    private float initialScale;

    private void Update()
    {
        // Detect touch inputs for manipulation
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                initialTouchPosition = touch.position;
                initialObjectPosition = transform.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                // Convert initialTouchPosition to Vector2 to match touch.position (Vector2)
                Vector2 touchDelta = touch.position - (Vector2)initialTouchPosition;
                transform.position = initialObjectPosition + new Vector3(touchDelta.x, touchDelta.y, 0) * 0.01f;
            }
        }

        if (Input.touchCount == 2)
        {
            Touch touch1 = Input.GetTouch(0);
            Touch touch2 = Input.GetTouch(1);
            if (touch1.phase == TouchPhase.Began || touch2.phase == TouchPhase.Began)
            {
                initialDistance = Vector2.Distance(touch1.position, touch2.position);
                initialScale = transform.localScale.x;
            }
            else if (touch1.phase == TouchPhase.Moved || touch2.phase == TouchPhase.Moved)
            {
                float currentDistance = Vector2.Distance(touch1.position, touch2.position);
                float scaleFactor = currentDistance / initialDistance;
                transform.localScale = new Vector3(initialScale * scaleFactor, initialScale * scaleFactor, initialScale * scaleFactor);
            }
        }
    }

    // Reset object state (called when switching between pieces)
    public void ResetObjectState()
    {
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        transform.localScale = Vector3.one;
    }
}
