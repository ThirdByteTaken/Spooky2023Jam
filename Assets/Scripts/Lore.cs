using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Lore : MonoBehaviour
{
    public static Lore Instance;

    private Animator anim;
    private TMP_Text loreText;

    void Start()
    {
        Instance = this;
        anim = GetComponent<Animator>();
        loreText = GetComponent<TMP_Text>();
        anim.SetBool("Show", false);
    }

    public void ShowText(string text, int length = 2)
    {
        loreText.text = text;
        anim.SetBool("Show", true);
        Invoke("HideText", length);
    }

    public void HideText()
    {
        anim.SetBool("Show", false);
    }
}
