using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTransform;
    public Vector3 offset = new Vector3(0f, 0f, -10f); // The offset of the camera from the player

    void LateUpdate()
    {
        if (playerTransform != null)
        {
            // Calculate the desired position of the camera
            Vector3 desiredPosition = playerTransform.position + offset;

            // Use smooth movement to follow the player
            transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * 5f);

        }
    }
}