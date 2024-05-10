using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    // Start is called before the first frame update
    void Awake()
    {
        foreach(Sound s in sounds)
        {
            s.source=gameObject.AddComponent<AudioSource>();
            s.source.clip=s.clip;
            
            s.source.volume=s.volume;
            s.source.loop=s.loop;
            // s.source.pitch=s.pitch;
        }
    }
    void Start()
    {
        Play("Sealing");Pause("Sealing");
    }
    public void Play(string name)
    {
        Sound s=Array.Find(sounds,sound=>sound.name==name);
        s.source.Play();
        // How to Use
        // FindObjectOfType<AudioManager>().Play("");
    }

    public void Pause(string name)
    {
        Sound s=Array.Find(sounds,sound=>sound.name==name);
        s.source.mute=!s.source.mute;
    }
}


