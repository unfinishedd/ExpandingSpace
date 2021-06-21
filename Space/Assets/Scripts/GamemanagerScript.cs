using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamemanagerScript : MonoBehaviour
{
   
    public bool isPaused = false;
    public Canvas pauseScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }
    public void Pause()
    {
        if (isPaused)
        {
            isPaused = false;
            pauseScreen.gameObject.SetActive(false);
            Time.timeScale = 1f;
        }
        else
        {
            isPaused = true;
            pauseScreen.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
