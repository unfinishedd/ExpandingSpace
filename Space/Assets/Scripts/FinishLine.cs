using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public GameObject UICanvas;
    public GameObject YouWinCanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<SoundManagerScript>().PlayWinSound();
        Time.timeScale = 0;
        UICanvas.SetActive(false);
        YouWinCanvas.SetActive(true);
       
    }
}
