using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset = new Vector3(0, 3, -5);
    public float smoothSpeed = 5f;

    void LateUpdate()
    {
        if (player == null) return;

        // Rotate offset based on player rotation
        Vector3 rotatedOffset = player.rotation * offset;

        Vector3 targetPosition = player.position + rotatedOffset;

        transform.position = Vector3.Lerp(
            transform.position,
            targetPosition,
            smoothSpeed * Time.deltaTime
        );

        transform.LookAt(player.position + Vector3.up * 1.5f);
    }
}
