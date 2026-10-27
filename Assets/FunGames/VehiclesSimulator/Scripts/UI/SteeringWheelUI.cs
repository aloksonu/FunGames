
using UnityEngine;
using UnityEngine.EventSystems;

public class SteeringWheelUI : MonoBehaviour,
    IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public CarController carController;
    public float maxRotation = 90f;

    private float currentAngle;
    private float previousPointerAngle;
    private bool isDragging;
    private bool controlsEnabled;

    public void SetControlsEnabled(bool enabled)
    {
        controlsEnabled = enabled;
        isDragging = false;

        if (!enabled)
        {
            carController.SetSteering(0f);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!controlsEnabled) return;

        isDragging = true;

        Vector2 direction = eventData.position -
            (Vector2)RectTransformUtility.WorldToScreenPoint(
                eventData.pressEventCamera, transform.position);

        previousPointerAngle =
            Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!controlsEnabled || !isDragging) return;

        Vector2 direction = eventData.position -
            (Vector2)RectTransformUtility.WorldToScreenPoint(
                eventData.pressEventCamera, transform.position);

        float pointerAngle =
            Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        currentAngle -= Mathf.DeltaAngle(
            previousPointerAngle, pointerAngle);

        currentAngle = Mathf.Clamp(
            currentAngle, -maxRotation, maxRotation);

        previousPointerAngle = pointerAngle;

        transform.localRotation =
            Quaternion.Euler(0f, 0f, currentAngle);

        carController.SetSteering(currentAngle / maxRotation);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isDragging = false;

        if (controlsEnabled)
            carController.SetSteering(0f);
    }
}
