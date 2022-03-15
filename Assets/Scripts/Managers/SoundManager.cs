using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    AudioSource audiosource;
    public AudioClip _HoverAC, _SelectAC;
    public enum AudioClipType {hoverAC,selectedAC };

    public void PlaySound(AudioClipType clip)
    {
        AudioClip aclip=null;

        if (clip==AudioClipType.hoverAC)
        {
            aclip = _HoverAC;
        }
        else if(clip==AudioClipType.selectedAC)
        {
            aclip = _SelectAC;
        }

        if (!aclip)
            return;
        if(audiosource.isPlaying)
        {
            audiosource.Stop();
            audiosource.clip = aclip;
            audiosource.Play();
        }
        else
        {
            audiosource.clip = aclip;
            audiosource.Play();
        }
    }
}
