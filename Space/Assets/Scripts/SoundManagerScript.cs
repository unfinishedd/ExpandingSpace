using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SoundManagerScript : MonoBehaviour
{
    public AudioClip[] WinSounds;
    public AudioClip[] PowerupSounds;
    public AudioClip[] DeathSounds;
    public AudioClip[] BGM;
    public AudioClip[] MainMenuBGM;

    public float BGMVolume;
    public float SFXVolume;
    public bool GameStarted = false;

    public AudioSource sfxSource;
    public AudioSource bgmSource;

    public Button StartButton;


    private static SoundManagerScript SoundManager;
    void Start()
    {
        
        StartCoroutine(StartMainMenuMusic());
        StartMainMenuMusic();
        
    }


    void Update()
    {
        
    }
    public void StopMusic()
    {
        bgmSource.Stop();
        GameStarted = true;

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
            AudioClip audioClip = BGM[Random.Range(0, BGM.Length)];
            bgmSource.clip = audioClip;
            bgmSource.volume = BGMVolume;
            bgmSource.PlayOneShot(bgmSource.clip);
            yield return new WaitForSeconds(audioClip.length);
        }
    }

    public IEnumerator StartMainMenuMusic()
    {
        while ((true && GameStarted == false))
        {
            AudioClip audioClip = MainMenuBGM[Random.Range(0, MainMenuBGM.Length)];
            bgmSource.clip = audioClip;
            bgmSource.volume = BGMVolume;
            bgmSource.PlayOneShot(bgmSource.clip);
            yield return new WaitForSeconds(audioClip.length);
        }
    }
    public void PlayPowerupSound()
    {
        sfxSource.clip = PowerupSounds[Random.Range(0, PowerupSounds.Length)];
        sfxSource.volume = SFXVolume;
        sfxSource.PlayOneShot(sfxSource.clip);
    }
    public void PlayWinSound()
    {
        sfxSource.clip = WinSounds[Random.Range(0, WinSounds.Length)];
        sfxSource.volume = SFXVolume;
        sfxSource.PlayOneShot(sfxSource.clip);

    }
    public void PlayDeathSounds()
    {
        sfxSource.clip = DeathSounds[Random.Range(0, DeathSounds.Length)];
        sfxSource.volume = SFXVolume;
        sfxSource.PlayOneShot(sfxSource.clip);
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
