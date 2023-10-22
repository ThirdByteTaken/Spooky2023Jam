using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float Movement_Speed;
    private Rigidbody2D rb;
    private Camera mainCamera;
    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
    }

    // Better for physics
    private void FixedUpdate()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        float xMovement = horizontalInput * Time.deltaTime * Movement_Speed;

        Vector2 velocity = rb.velocity;
        velocity.x = xMovement * Movement_Speed;
        rb.velocity = velocity;
    }

    private void Update()
    {
        Vector3 cameraPos = mainCamera.transform.position;
        cameraPos.x = transform.position.x;
        mainCamera.transform.position = cameraPos;
    }
}
