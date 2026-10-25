using System.Collections;
using UnityEngine;

public class TrafficLaneChange : MonoBehaviour
{
    [Header("Lanes")]
    public float[] laneXPositions;

    [Header("Random lane change")]
    public float minChangeDelay;
    public float maxChangeDelay;
    public float changeChance;

    [Header("Safety check")]
    public Vector2 safeBoxSize;
    public LayerMask trafficLayer;

    private bool isChanging;   
    private float changeTimer;
    private TrafficMovement movement;

    void Start()
    {
        movement = GetComponent<TrafficMovement>();
        changeTimer = Random.Range(minChangeDelay, maxChangeDelay);
    }

    void Update()
    {
        if (movement == null) { return; }
        if (isChanging) { return; }

        changeTimer -= Time.deltaTime;

        if (changeTimer > 0f)
        {
            return;
        }

        changeTimer = Random.Range(minChangeDelay, maxChangeDelay);

        if (Random.value < changeChance)
        {
            TryChangeLane();
        }
    }

    public bool TryChangeLane()
    {
        if (movement == null) { return false; }
        if (isChanging) { return false; }

        int leftLane = movement.currentLane - 1;
        int rightLane = movement.currentLane + 1;

        bool leftFree = IsLaneFree(leftLane);
        bool rightFree = IsLaneFree(rightLane);

        int targetLane = -1;

        if (leftFree && rightFree)
        {
            targetLane = (Random.value < 0.5f) ? leftLane : rightLane;
        }
        else if (leftFree)
        {
            targetLane = leftLane;
        }
        else if (rightFree)
        {
            targetLane = rightLane;
        }
        else
        {
            return false;
        }

        StartCoroutine(SlideToLane(targetLane));
        return true;
    }

    private bool IsLaneFree(int lane)
    {
        if (lane < 0 || lane >= laneXPositions.Length) { return false; }

        Vector2 center = new Vector2(laneXPositions[lane], transform.position.y);
        Collider2D[] hits = Physics2D.OverlapBoxAll(center, safeBoxSize, 0f, trafficLayer);

        foreach (Collider2D hit in hits)
        {
            if (hit.gameObject != gameObject)
            {
                return false;
            }
        }

        return true;
    }

    private IEnumerator SlideToLane(int targetLane)
    {
        isChanging = true;
        float startX = transform.position.x;
        float targetX = laneXPositions[targetLane];
        float elapsed = 0;

        while (elapsed < movement.laneChangeTime)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / movement.laneChangeTime;
            float newX = Mathf.SmoothStep(startX, targetX, t);

            transform.position = new Vector3(newX, transform.position.y, transform.position.z);

            yield return null;
        }

        transform.position = new Vector3(targetX, transform.position.y, transform.position.z);
        movement.currentLane = targetLane;
        isChanging = false;
    }

    void OnDrawGizmosSelected()
    {
        if (movement == null || laneXPositions == null) { return; }

        Gizmos.color = Color.green;

        int[] lanes = { movement.currentLane - 1, movement.currentLane + 1 };
        foreach (int lane in lanes)
        {
            if (lane >= 0 && lane < laneXPositions.Length)
            {
                Vector3 center = new Vector3(laneXPositions[lane], transform.position.y, 0f);
                Gizmos.DrawWireCube(center, safeBoxSize);
            }
        }
    }
}