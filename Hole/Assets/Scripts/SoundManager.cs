using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager ınstance;

    [SerializeField] AudioSource sounds;
    private void Awake()
    {
        if (ınstance == null)
        {
            ınstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void PlaySound(AudioClip clip)
    {
        sounds.PlayOneShot(clip);
    }
}
