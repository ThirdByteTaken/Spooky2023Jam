using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candle : MonoBehaviour
{
    private Animator anim;

    private bool In_Range = false;

    private AudioSource audioSource;

    private void Start()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        if (!PersistentData.Instance.candleDictionary.ContainsKey(gameObject.name))
        {
            PersistentData.Instance.candleDictionary.Add(gameObject.name, anim.GetBool("Light"));
        }
        anim.SetBool("Light", PersistentData.Instance.candleDictionary[gameObject.name]);
    }

    void Update()
    {
        if (In_Range && Input.GetKeyDown(KeyCode.E))
        {
            audioSource.Play();
            anim.SetBool("Light", true);
            PersistentData.Instance.candleDictionary[gameObject.name] = true;
            E.Instance.Hide();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !anim.GetBool("Light"))
        {
            In_Range = true;
            E.Instance.Show();
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
