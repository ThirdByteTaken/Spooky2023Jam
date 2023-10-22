using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [SerializeField]
    private string Target_Scene;

    private bool In_Range = true;

    private GameObject player;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            In_Range = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
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

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player = collision.gameObject;
            In_Range = true;
        }
    }
}
