
using UnityEngine;

public class TrafficCar : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float destroyY = -8f;

    void Update()
    {
        transform.Translate( Vector3.down * moveSpeed * Time.deltaTime, Space.World  );

        if (transform.position.y < destroyY)
        {
            Destroy(gameObject);
        }
    }
}
