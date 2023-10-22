using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float Movement_Speed;
    [SerializeField]
    private float Jump_Height;

    [SerializeField]
    private bool Can_Jump;

    private Rigidbody2D rb;
    private Camera mainCamera;

    private bool isGrounded = true;
    

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

        if (Can_Jump && Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector2(0, Jump_Height));
            isGrounded = false;
	    }

        Vector2 velocity = rb.velocity;
        velocity.x = xMovement * Movement_Speed;
        rb.velocity = velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isGrounded = true;
	    }
    }

    private void Update()
    {
        Vector3 cameraPos = mainCamera.transform.position;
        cameraPos.x = transform.position.x;
        mainCamera.transform.position = cameraPos;
    }
}
