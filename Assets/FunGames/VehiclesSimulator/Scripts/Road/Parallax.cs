
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Transform road1;
    public Transform road2;

    public float roadSpeed = 10f;
    public float roadLength = 20f;

    void Update()
    {
        float movement = roadSpeed * Time.deltaTime;

        road1.position += Vector3.down * movement;
        road2.position += Vector3.down * movement;

        if (road1.position.y <= -roadLength)
        {
            road1.position = new Vector3(road1.position.x, road2.position.y + roadLength, road1.position.z );
        }

        if (road2.position.y <= -roadLength)
        {
            road2.position = new Vector3( road2.position.x,road1.position.y + roadLength, road2.position.z );
        }
    }
}
