using System;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    public void PlaySound(AudioSource audio)
   {
        bool canPlaySound = audio != null && audio.clip != null;
        if (canPlaySound) 
        AudioSource.PlayClipAtPoint(audio.clip,transform.position);
   }

}
