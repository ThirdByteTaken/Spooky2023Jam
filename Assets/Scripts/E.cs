using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public static E Instance;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Instance = this;
    }

    public void Show()
    {
        spriteRenderer.enabled = true;
    }
    public void Hide()
    {
        spriteRenderer.enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            spriteRenderer.enabled = false;
        }
    }
}
