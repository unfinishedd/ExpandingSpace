using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinScript : MonoBehaviour
{

    public void Restart()
    {
        SceneManager.LoadScene("MainScene");

        Time.timeScale = 1f;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("UI");
        FindObjectOfType<SoundManagerScript>().StopMusic();
        FindObjectOfType<SettingsMenuScript>().MainMenuCanvas.SetActive(true);
        FindObjectOfType<SoundManagerScript>().GameStarted = false;
        StartCoroutine(FindObjectOfType<SoundManagerScript>().StartMainMenuMusic());
        Time.timeScale = 1f;

    }
   
}
