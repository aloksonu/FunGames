
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float steerSpeed = 8f;
    public float roadLimit = 3f;

    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        Vector3 movement = Vector3.right * horizontalInput * steerSpeed * Time.deltaTime;
        transform.position += movement;
        float xPosition = Mathf.Clamp(transform.position.x, -roadLimit, roadLimit);
        transform.position = new Vector3( xPosition,transform.position.y, transform.position.z );
    }
}
