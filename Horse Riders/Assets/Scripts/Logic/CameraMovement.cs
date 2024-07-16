using UnityEngine;
using Zenject;

public class CameraMovement : MonoBehaviour
{
    private Vector3 cameraOffset = new Vector3(0f, 4.48f, -4.91f);
    private Transform playerTransform;

    [Inject]
    private void Construct(Player player)
    {
        playerTransform = player.transform;
    }

    private void Update()
    {
        transform.position = new Vector3(0f, 0f, playerTransform.position.z) + cameraOffset;
    }
}
