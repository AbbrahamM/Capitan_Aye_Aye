using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class UISelectRandomSong : MonoBehaviour
{
    [SerializeField]
    AudioSource m_AudioSource;
    [SerializeField]
    List<AudioClip> clips;

    private void Awake()
    {
        if(m_AudioSource == null)
            m_AudioSource = GetComponent<AudioSource>();
    }

    public void PlayRandomSong()
    {
        m_AudioSource.clip = clips[Random.Range(0, clips.Count)];
        m_AudioSource.Play();
    }

    public void Pause()
    {
        if(m_AudioSource != null) 
            m_AudioSource.Pause();
    }
}
