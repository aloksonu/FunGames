
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float steerSpeed = 5f;

    [Header("Road Limits")]
    public float leftLimit = -2f;
    public float rightLimit = 2f;

    private float steeringInput;

    void Update()
    {
        float keyboardInput = Input.GetAxisRaw("Horizontal");

        float input = Mathf.Abs(keyboardInput) > 0
            ? keyboardInput
            : steeringInput;

        Vector3 position = transform.position;

        position.x += input * steerSpeed * Time.deltaTime;
        position.x = Mathf.Clamp(position.x, leftLimit, rightLimit);

        transform.position = position;
    }

    public void SetSteering(float input)
    {
        steeringInput = input;
    }
}
