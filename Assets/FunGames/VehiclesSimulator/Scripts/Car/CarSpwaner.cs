
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public GameObject[] vehiclePrefabs;
    public Transform player;

    [Header("Lanes")]
    public float laneDistance = 2f;
    public int numberOfLanes = 3;

    [Header("Spawning")]
    public float spawnInterval = 1.5f;
    public float spawnY = 10f;
    public int maxVehicles = 2;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval && CountVehicles() < maxVehicles)
        {
            SpawnVehicle();
            timer = 0f;
        }
    }

    int CountVehicles()
    {
        return GameObject.FindGameObjectsWithTag("Vehicle").Length;
    }

    void SpawnVehicle()
    {
        if (vehiclePrefabs.Length == 0 || player == null)
            return;

        int lane = Random.Range(0, numberOfLanes);
        float laneX = (lane - (numberOfLanes - 1) / 2f) * laneDistance;

        Vector3 spawnPosition = new Vector3(
            laneX,
            spawnY,
            player.position.z
        );

        GameObject prefab = vehiclePrefabs[
            Random.Range(0, vehiclePrefabs.Length)
        ];

        Instantiate(prefab, spawnPosition, Quaternion.identity);
    }
}
