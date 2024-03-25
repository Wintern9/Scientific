using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundInAnimation : MonoBehaviour
{
    public GameObject gameObj;
    private AudioSource Sound;
    public AudioClip AudioClip;

    void Start()
    {
        Sound = gameObj.GetComponent<AudioSource>();
    }

    public void OnSound()
    {
        Sound.resource = AudioClip;
    }
}
