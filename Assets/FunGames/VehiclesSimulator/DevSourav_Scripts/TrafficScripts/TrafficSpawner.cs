using UnityEngine;

public class TrafficSpawner : MonoBehaviour
{
    public GameObject[] trafficPrefabs;
    public float[] laneXPositions;
    public float spawnYTop;
    public float minSpawnTime;
    public float maxSpawnTime;
    public Vector2 checkSize;
    public LayerMask trafficLayer;
    public float playerSpeed;

    private float spawnTimer;

    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer < 0)
        {
            SpawnTraffic();
            ResetTimer();
        }
        
    }

    public void SpawnTraffic()
    {
        int randomLaneNumber = Random.Range(0, laneXPositions.Length);
        int randomPrefab = Random.Range(0 ,trafficPrefabs.Length);
        GameObject trafficToSpawn = trafficPrefabs[randomPrefab];

        Vector3 spawnPosition = new Vector3(laneXPositions[randomLaneNumber], spawnYTop, 0f);

        Collider2D hitCollider = Physics2D.OverlapBox(spawnPosition, checkSize, 0f, trafficLayer);
        if (hitCollider != null)
        {
            return;
        }

        GameObject newTraffic = Instantiate(trafficToSpawn, spawnPosition, Quaternion.identity);

        TrafficMovement trafficMovement = newTraffic.GetComponent<TrafficMovement>();

        if (trafficMovement != null)
        {
            trafficMovement.currentLane = randomLaneNumber;
            trafficMovement.playerSpeed = playerSpeed;
            TrafficLaneChange trafficLaneChange = newTraffic.GetComponent<TrafficLaneChange>();

            if (trafficLaneChange != null)
            {
                trafficLaneChange.laneXPositions = laneXPositions;
            }
        }
    }

    public void ResetTimer()
    {
        spawnTimer = Random.Range(minSpawnTime, maxSpawnTime);
    }
    void OnDrawGizmosSelected()
    {
        if (laneXPositions == null) return;

        Gizmos.color = Color.yellow;

        for (int i = 0; i < laneXPositions.Length; i++)
        {
            Vector3 spawnPosition = new Vector3(laneXPositions[i], spawnYTop, 0f);
            Gizmos.DrawWireCube(spawnPosition, checkSize);
        }
    }
}
