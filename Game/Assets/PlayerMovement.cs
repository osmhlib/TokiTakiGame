using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementTopDown : MonoBehaviour
{
    public float speed = 5f; // Швидкість руху
    public FixedJoystick joystick; // Посилання на джойстик

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Отримання напрямку руху від джойстика
        Vector2 direction = new Vector2(joystick.Horizontal, joystick.Vertical);

        // Переміщення гравця
        rb.velocity = direction * speed;
    }
}
