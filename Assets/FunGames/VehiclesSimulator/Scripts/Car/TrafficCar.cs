
using UnityEngine;

public class TrafficCar : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float steerSpeed = 5f;
    public float destroyY = -8f;

    public float detectionRange = 12f;
    public LayerMask playerLayer;

    private float targetX;
    private bool changingLane;

    void Start()
    {
        targetX = transform.position.x;
    }

    void Update()
    {
        transform.Translate(
            Vector3.down * moveSpeed * Time.deltaTime,
            Space.World
        );

        if (changingLane)
        {
            Vector3 position = transform.position;

            position.x = Mathf.MoveTowards(
                position.x,
                targetX,
                steerSpeed * Time.deltaTime
            );

            transform.position = position;

            if (Mathf.Abs(position.x - targetX) < 0.01f)
            {
                changingLane = false;
            }
        }

        if (transform.position.y < destroyY)
        {
            Destroy(gameObject);
        }
    }

    public bool IsPlayerAhead()
    {
        RaycastHit2D hit = Physics2D.Raycast(
            transform.position,
            Vector2.up,
            detectionRange,
            playerLayer
        );

        Debug.DrawRay(
            transform.position,
            Vector2.up * detectionRange,
            hit.collider != null ? Color.green : Color.red
        );

        return hit.collider != null;
    }

    public void ChangeLane(float newX)
    {
        targetX = newX;
        changingLane = true;
    }
}
