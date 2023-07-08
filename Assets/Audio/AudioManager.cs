using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;
using Random = UnityEngine.Random;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;
    public AudioClip[] mainMusicClips;
    public AudioClip resroucesDropOff;

        void Awake()
    {
        foreach(Sound s in sounds)
        {
           s.source = gameObject.AddComponent<AudioSource>();
           s.source.clip =s.clip;
           s.source.volume =s.volume;
           s.source.pitch =s.pitch;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
         // gameObject.GetComponent<AudioSource>().volume = 0.05f;
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameObject.GetComponent<AudioSource>().isPlaying)
        {
            gameObject.GetComponent<AudioSource>().clip = GetRandomClip();
            gameObject.GetComponent<AudioSource>().Play();
            
        }
    }
    public AudioClip GetRandomClip()
    {
            return mainMusicClips[Random.Range(0,mainMusicClips.Length)];
    }
    public void Play(string sndName)
    {
      Sound s = Array.Find(sounds, sound => sound.name == sndName);
      s.source.Play();
    }
}
