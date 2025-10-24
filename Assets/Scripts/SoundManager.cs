using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
   private void PlaySound(AudioSource audio)
   {
        bool canPlaySound = audio != null && audio.clip != null;
        if (canPlaySound) 
        AudioSource.PlayClipAtPoint(audio.clip,transform.position);
   }

    private void OnEnable()
    {
        Garbage.OnPlaySound += PlaySound;
        Coin.OnPlaySound += PlaySound;
    }

    private void OnDisable()
    {
        Garbage.OnPlaySound -= PlaySound;
        Coin.OnPlaySound -= PlaySound;
    }
}
