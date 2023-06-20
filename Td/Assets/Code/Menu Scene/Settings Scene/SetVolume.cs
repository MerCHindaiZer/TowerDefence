using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class SetVolume : MonoBehaviour
{
    public AudioMixer AudioMixer;
   public void Volume(float volume)
    {
        AudioMixer.SetFloat("volume", volume);
    }
}
