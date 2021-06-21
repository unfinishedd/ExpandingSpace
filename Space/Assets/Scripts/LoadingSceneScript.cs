using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LoadingSceneScript : MonoBehaviour
{
    public TextMeshProUGUI Loading_Text;
    public int Text_speed = 1;
    private void Start()
    {
        StartCoroutine(StartScene());
        StartCoroutine(ChangeText());
        
        
    }
   
    IEnumerator StartScene() 
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        StartCoroutine(FindObjectOfType<SoundManagerScript>().StartBGMMusic());
    }
    

    IEnumerator ChangeText()
    {
        while (true)
        {
            Loading_Text.text = "Loading.";
            yield return new WaitForSeconds(Text_speed);
            Loading_Text.text = "Loading..";
            yield return new WaitForSeconds(Text_speed);
            Loading_Text.text = "Loading...";
            yield return new WaitForSeconds(Text_speed);
        }
    }




}
  
        
