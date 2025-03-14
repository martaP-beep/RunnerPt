using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    bool muted;
    AudioSource music;

    public AudioSource effect;
    public AudioClip coinMusic;

    public void PlayCoin()
    {
        if(muted == false)
        {
            effect.PlayOneShot(coinMusic,1);
        }
    }


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        music = GetComponent<AudioSource>();
    }

    public bool GetMuted()
    {
        return muted;
    }

    public void ToggleMuted()
    {
        muted = !muted;
        music.mute = muted;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
