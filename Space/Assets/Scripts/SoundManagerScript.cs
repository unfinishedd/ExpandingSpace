using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManagerScript : MonoBehaviour
{
    public AudioClip[] Test;
    public AudioClip[] BGM;
    public AudioClip[] MainMenuBGM;

    public float BGMVolume;
    public float SFXVolume;

    public AudioSource sfxSource;
    public AudioSource bgmSource;


    private static SoundManagerScript SoundManager;
    void Start()
    {
        StartCoroutine(StartBGMMusic());
        StartBGMMusic();
    }


    void Update()
    {

    }
    public void StopMusic()
    {
        bgmSource.Stop();
    }

    public void ChangeSFXVolume(float value)
    {
        float newVolume = value * 0.01f;
        sfxSource.volume = newVolume;
        SFXVolume = value * 0.01f;
    }
    public void ChangeBGMVolume(float value)
    {
        float newVolume = value * 0.01f;
        bgmSource.volume = newVolume;
        BGMVolume = newVolume;
    }
    public IEnumerator StartBGMMusic()
    {
        while (true)
        {
            AudioClip audioClip = MainMenuBGM[Random.Range(0, MainMenuBGM.Length)];
            bgmSource.clip = audioClip;
            bgmSource.volume = BGMVolume;
            bgmSource.PlayOneShot(bgmSource.clip);
            yield return new WaitForSeconds(audioClip.length);
        }
    }
    private void Awake()
    {
        if (!SoundManager)
        {
            DontDestroyOnLoad(gameObject);
            SoundManager = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
