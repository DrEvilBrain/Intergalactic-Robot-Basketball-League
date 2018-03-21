using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicHandler : MonoBehaviour
{

    public AudioClip intro;
    public AudioClip loop;
    public AudioClip win;

    // Use this for initialization
    void Start()
    {
        this.GetComponent<AudioSource>().loop = true;
        StartCoroutine(PlayLoop());
    }

    IEnumerator PlayLoop()
    {
        this.GetComponent<AudioSource>().clip = intro;
        this.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(this.GetComponent<AudioSource>().clip.length);
        this.GetComponent<AudioSource>().clip = loop;
        this.GetComponent<AudioSource>().Play();
    }

}