using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [SerializeField]
    private string Target_Scene;

    private bool In_Range = false;

    private GameObject player;

    [SerializeField]
    private bool isLocked;

    [SerializeField]
    private bool isCodeDoor;

    [SerializeField]
    private string keyName;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            In_Range = false;
            E.Instance.Hide();
        }
    }

    private int codeDoorID = 0;

    private void Update()
    {
        if (In_Range && isCodeDoor && (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.T) || Input.GetKeyDown(KeyCode.R)))
        {
            switch (codeDoorID)
            {
                case 0:
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        Lore.Instance.ShowText("Enter First Letter");
                        codeDoorID++;
                    }
                    else
                    {
                        codeDoorID = 0;
                    }
                    return;
                case 1:
                    if (Input.GetKeyDown(KeyCode.T))
                    {
                        Lore.Instance.ShowText("Enter Second Letter");
                        codeDoorID++;
                    }
                    else
                    {
                        Lore.Instance.ShowText("Incorrect Code, Try Again");
                        codeDoorID = 0;
                    }
                    return;
                case 2:
                    if (Input.GetKeyDown(KeyCode.R))
                    {
                        Lore.Instance.ShowText("Enter Third Letter");
                        codeDoorID++;
                    }
                    else
                    {
                        Lore.Instance.ShowText("Incorrect Code, Try Again");
                        codeDoorID = 0;
                    }
                    return;
                case 3:
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        Lore.Instance.ShowText("Enter Fourth Letter");
                        codeDoorID++;
                    }
                    else
                    {
                        Lore.Instance.ShowText("Incorrect Code, Try Again");
                        codeDoorID = 0;
                    }
                    return;
                case 4:
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        SceneManager.LoadSceneAsync(Target_Scene, LoadSceneMode.Single);
                    }
                    else
                    {
                        Lore.Instance.ShowText("Incorrect Code, Try Again");
                        codeDoorID = 0;
                    }
                    return;
            }

        }
        else if (In_Range && Input.GetKeyDown(KeyCode.E))
        {
            E.Instance.Hide();
            if (isLocked && !PersistentData.Instance.inventory.Contains(keyName)) Lore.Instance.ShowText("Door is locked");
            else
            {
                if (PersistentData.Instance.positionDictionary.ContainsKey(SceneManager.GetActiveScene().name))
                {
                    PersistentData.Instance.positionDictionary[SceneManager.GetActiveScene().name] = player.transform.position;
                }
                else
                {
                    PersistentData.Instance.positionDictionary.Add(SceneManager.GetActiveScene().name, player.transform.position);
                }

                SceneManager.LoadSceneAsync(Target_Scene, LoadSceneMode.Single);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player = collision.gameObject;
            In_Range = true;
            E.Instance.Show();
        }
    }
}
