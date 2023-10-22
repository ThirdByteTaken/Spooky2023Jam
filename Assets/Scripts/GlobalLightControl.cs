using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;


public class GlobalLightControl : MonoBehaviour
{
    public static Light2D globalLight;
    private Animator anim;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        globalLight = GetComponent<Light2D>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        ShowLightning();
    }

    void ShowLightning()
    {
        Invoke("ShowLightning", Random.Range(5, 15));
        anim.SetTrigger("Lightning");
        Invoke("Thunder", 0.4f);
    }

    void Thunder()
    {
        audioSource.Play();
    }
}
