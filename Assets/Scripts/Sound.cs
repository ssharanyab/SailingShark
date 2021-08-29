using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;

    public float volume;
    public bool loop;
    public AudioSource source;
}
