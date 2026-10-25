using UnityEngine;

public class TrafficFollowing : MonoBehaviour
{
    public float lookDistance;
    public float checkWidth;
    public float carHalfLength;
    public LayerMask trafficLayer;
    public float acceleration;

    private TrafficMovement movement;

    void Start()
    {
        movement = GetComponent<TrafficMovement>();
    }

    void Update()
    {
        if (movement == null) return;

        float targetSpeed = movement.desiredSpeed;

        Vector2 boxCenter = (Vector2)transform.position + (Vector2)transform.up * (carHalfLength + (lookDistance * 0.5f));

        Collider2D hit = Physics2D.OverlapBox(boxCenter, new Vector2(checkWidth, lookDistance), 0f, trafficLayer);

        if (hit != null && hit.gameObject != gameObject)
        {
            TrafficMovement otherCar = hit.GetComponent<TrafficMovement>();

            if (otherCar != null)
            {
                targetSpeed = Mathf.Min(movement.desiredSpeed, otherCar.trafficSpeed);
            }
        }

        movement.trafficSpeed = Mathf.MoveTowards(movement.trafficSpeed, targetSpeed, acceleration * Time.deltaTime);
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Vector2 boxCenter = (Vector2)transform.position + (Vector2)transform.up * (carHalfLength + (lookDistance * 0.5f));
        Gizmos.DrawWireCube(boxCenter, new Vector2(checkWidth, lookDistance));
    }
}