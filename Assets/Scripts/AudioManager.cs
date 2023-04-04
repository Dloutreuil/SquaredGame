using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource coinSource;
    public AudioClip coinSound;
    public AudioSource FireDeathSource;
    public AudioClip FireDeathSound;

    private void Awake()
    {
        instance = this;
        print("Play");
    }

    void Start()
    {
        coinSource = GetComponent<AudioSource>();
        FireDeathSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }
}
