using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGiver : MonoBehaviour
{
    [SerializeField]
    private Sprite newSprite;

    private AudioSource audioSource;

    [SerializeField]
    private string itemName;

    private bool In_Range = false;
    private bool Item_Obtained = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Item_Obtained && In_Range && Input.GetKeyDown(KeyCode.E))
        {
            audioSource.Play();
            Lore.Instance.ShowText("You found a " + itemName);
            PersistentData.Instance.inventory.Add(itemName);
            GetComponent<SpriteRenderer>().sprite = newSprite;
            Item_Obtained = true;
            E.Instance.Hide();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !Item_Obtained)
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
