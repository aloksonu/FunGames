using UnityEngine;

public class TrafficMovement : MonoBehaviour
{
    public float trafficSpeed;
    public float desiredSpeed;
    public float playerSpeed;
    public int currentLane;
    public float laneChangeTime;
    public float destroyAboveY;
    public float destroyBelowY;

    void Start()
    {
        desiredSpeed = trafficSpeed;
    }

    void Update()
    {
        TrafficMovements();
        CheckCarPosition();
    }

    public void TrafficMovements()
    {
        float relativeSpeed = trafficSpeed - playerSpeed;

        transform.Translate(Vector3.up * relativeSpeed * Time.deltaTime , Space.World);
    }

    public void CheckCarPosition()
    {
        if (transform.position.y > destroyAboveY)
        {
            Destroy(gameObject);
        }

        else if (transform.position.y < destroyBelowY)
        {

            Destroy(gameObject);
        }
    }
}
