using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentData : MonoBehaviour
{
    public Dictionary<string, Vector2> positionDictionary = new Dictionary<string, Vector2>();
    public Dictionary<string, bool> candleDictionary = new Dictionary<string, bool>();
    public List<string> inventory = new List<string>();

    public static PersistentData Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
