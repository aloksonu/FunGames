
using UnityEngine;

public class SteeringUI : MonoBehaviour
{
    public CarController carController;

    private bool controlsEnabled;

    public void SetControlsEnabled(bool enabled)
    {
        controlsEnabled = enabled;

        if (!enabled)
            carController.SetSteering(0f);
    }

    public void SteerLeft()
    {
        if (controlsEnabled)
            carController.SetSteering(-1f);
    }

    public void SteerRight()
    {
        if (controlsEnabled)
            carController.SetSteering(1f);
    }

    public void StopSteering()
    {
        if (controlsEnabled)
            carController.SetSteering(0f);
    }
}
