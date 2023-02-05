using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    private AudioSource m_AudioSource;
    public static AudioSource AudioInstance;

    public void Awake()
    {
        m_AudioSource = GetComponent<AudioSource>();
        AudioInstance = m_AudioSource;
    }
}
