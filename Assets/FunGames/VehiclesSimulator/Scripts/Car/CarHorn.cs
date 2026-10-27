
using UnityEngine;
using System.Collections.Generic;

public class CarHorn : MonoBehaviour
{
    public float laneDistance = 2f;
    public int numberOfLanes = 3;
    public float laneClearance = 3f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            PressHorn();
    }

    public void PressHorn()
    {
        TrafficCar[] vehicles =
            FindObjectsByType<TrafficCar>(FindObjectsSortMode.None);

        foreach (TrafficCar vehicle in vehicles)
        {
            if (!vehicle.IsPlayerAhead())
                continue;

            int currentLane = Mathf.RoundToInt(
                vehicle.transform.position.x / laneDistance
                + (numberOfLanes - 1) / 2f
            );

            List<int> availableLanes = new List<int>();

            CheckLane(currentLane - 1, vehicle, vehicles, availableLanes);
            CheckLane(currentLane + 1, vehicle, vehicles, availableLanes);

            if (availableLanes.Count == 0)
                continue;

            int lane = availableLanes[
                Random.Range(0, availableLanes.Count)
            ];

            float targetX =
                (lane - (numberOfLanes - 1) / 2f) * laneDistance;

            vehicle.ChangeLane(targetX);
        }
    }

    void CheckLane(
        int lane,
        TrafficCar target,
        TrafficCar[] vehicles,
        List<int> availableLanes)
    {
        if (lane < 0 || lane >= numberOfLanes)
            return;

        float laneX =
            (lane - (numberOfLanes - 1) / 2f) * laneDistance;

        foreach (TrafficCar vehicle in vehicles)
        {
            if (vehicle == target)
                continue;

            bool sameLane =
                Mathf.Abs(vehicle.transform.position.x - laneX) < 0.5f;

            bool nearby =
                Mathf.Abs(
                    vehicle.transform.position.y -
                    target.transform.position.y
                ) < laneClearance;

            if (sameLane && nearby)
                return;
        }

        availableLanes.Add(lane);
    }
}
