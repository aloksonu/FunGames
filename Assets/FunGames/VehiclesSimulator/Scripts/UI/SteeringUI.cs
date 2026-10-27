
using UnityEngine;
using UnityEngine.EventSystems;

public class SteeringUI : MonoBehaviour
{
    public CarController carController;

    public void SteerLeft()
    {
        carController.SetSteering(-1f);
    }

    public void SteerRight()
    {
        carController.SetSteering(1f);
    }

    public void StopSteering()
    {
        carController.SetSteering(0f);
    }
}
