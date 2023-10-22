using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float Movement_Speed;
    [SerializeField]
    private float Jump_Height;

    [SerializeField]
    private bool Can_Jump;


    private Animator anim;
    private Rigidbody2D rb;
    private Camera mainCamera;

    private bool isGrounded = true;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        mainCamera = Camera.main;
        if (PersistentData.Instance.positionDictionary.ContainsKey(SceneManager.GetActiveScene().name))
            transform.position = PersistentData.Instance.positionDictionary[SceneManager.GetActiveScene().name];
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
        if (velocity.x == 0) anim.SetBool("Walking", false);
        else
        {
            anim.SetBool("Walking", true);
            Vector3 localScale = transform.localScale;
            localScale.x = (velocity.x > 0) ? 0.4f : -0.4f;
            Lore.Instance.transform.localScale = (velocity.x > 0) ? new Vector3(1, 1, 1) : new Vector3(-1, 1, 1);
            transform.localScale = localScale;
        }
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
        cameraPos.x = Mathf.Clamp(transform.position.x, -5, 35);
        mainCamera.transform.position = cameraPos;
    }
}
