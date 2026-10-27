
using UnityEngine;

public class GyroCarController : MonoBehaviour
{
    public CarController carController;

    [Header("Gyro Settings")]
    public float sensitivity = 3f;
    public float deadZone = 0.08f;
    public bool invertSteering = false;

    private float centerRotation;
    private bool gyroEnabled;

    public void EnableGyro()
    {
        if (SystemInfo.supportsGyroscope)
        {
            Input.gyro.enabled = true;
            centerRotation = Input.acceleration.x;
            gyroEnabled = true;
        }
        else
        {
            Debug.LogWarning("Gyroscope is not supported on this device.");
            gyroEnabled = false;
        }
    }

    public void DisableGyro()
    {
        gyroEnabled = false;
        carController.SetSteering(0f);
    }

    void Update()
    {
        if (!gyroEnabled)
            return;

        float tilt = Input.acceleration.x - centerRotation;

        if (Mathf.Abs(tilt) < deadZone)
            tilt = 0f;

        float steering = Mathf.Clamp(tilt * sensitivity, -1f, 1f);

        if (invertSteering)
            steering = -steering;

        carController.SetSteering(steering);
    }
}
