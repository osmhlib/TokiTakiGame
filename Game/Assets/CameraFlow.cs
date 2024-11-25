using UnityEngine;

public class CameraFollowCenter : MonoBehaviour
{
    public Transform player; // Посилання на гравця
    public Vector3 offset = new Vector3(0, 0, -10); // Зміщення камери

    public BoxCollider2D backgroundBounds; // Колайдер для обмеження руху камери

    private float cameraHalfHeight; // Половина висоти камери
    private float cameraHalfWidth; // Половина ширини камери

    void Start()
    {
        // Розрахунок розмірів камери
        Camera cam = Camera.main;
        cameraHalfHeight = cam.orthographicSize;
        cameraHalfWidth = cameraHalfHeight * cam.aspect;
    }

    void LateUpdate()
    {
        if (player == null || backgroundBounds == null) return;

        // Розрахунок бажаної позиції камери
        Vector3 targetPosition = player.position + offset;

        // Обмеження руху камери в межах фону
        float clampedX = Mathf.Clamp(targetPosition.x,
            backgroundBounds.bounds.min.x + cameraHalfWidth,
            backgroundBounds.bounds.max.x - cameraHalfWidth);

        float clampedY = Mathf.Clamp(targetPosition.y,
            backgroundBounds.bounds.min.y + cameraHalfHeight,
            backgroundBounds.bounds.max.y - cameraHalfHeight);

        // Встановлення нової позиції камери
        transform.position = new Vector3(clampedX, clampedY, targetPosition.z);
    }
}
