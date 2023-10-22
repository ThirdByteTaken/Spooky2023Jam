using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoreGiver : MonoBehaviour
{
    [SerializeField]
    private GameObject loreObject;

    private bool In_Range = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (In_Range)
            {
                loreObject.SetActive(!loreObject.activeSelf);
                E.Instance.Hide();
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            loreObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            E.Instance.Show();
            In_Range = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            In_Range = false;
            E.Instance.Hide();
        }
    }
}
