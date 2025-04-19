using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    private Vector2 touchStart;
    private float initialDistance;
    private Vector3 initialScale;

    void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                float rotX = touch.deltaPosition.x * 0.5f;
                transform.Rotate(0, -rotX, 0);
            }
        }

        if (Input.touchCount == 2)
        {
            Touch t1 = Input.GetTouch(0);
            Touch t2 = Input.GetTouch(1);

            if (t1.phase == TouchPhase.Began || t2.phase == TouchPhase.Began)
            {
                initialDistance = Vector2.Distance(t1.position, t2.position);
                initialScale = transform.localScale;
            }
            else if (t1.phase == TouchPhase.Moved || t2.phase == TouchPhase.Moved)
            {
                float currentDistance = Vector2.Distance(t1.position, t2.position);
                float factor = currentDistance / initialDistance;
                transform.localScale = initialScale * factor;
            }
        }
    }
}
