using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    public AudioSource audiosource;
    public AudioClip cannon, hit1, hit2, powerup, push, death;

    public void Button()
    {
        audiosource.clip = push;
        audiosource.Play();
    }
}
