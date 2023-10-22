using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float startXPos;
    private float length = 4;
    [SerializeField] private float speed;
    Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        startXPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = mainCamera.transform.position;
        float temp = pos.x - (1 - speed);
        float distance = pos.x * speed;

        pos = new Vector3(startXPos + distance, transform.position.y, transform.position.z);

        transform.position = pos;
    }
}
