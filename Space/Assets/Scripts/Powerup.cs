using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public bool isTouch = false;
    public bool isRepeat = false;
    public float Timu = 3.0f;
    


    private void Start()
    {
        
    }
    public void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Item")
        {
            isTouch = true;
        }
    }
    void Update()
    {
        if (isTouch == true)
        {
            //boost
            Timu -= Time.deltaTime;
            

            if (Timu <= 0)
            {
                
                //normal speed
                Timu = 3.0f;
                const float timeoutRefresh = 3.0f;

                Timu = timeoutRefresh;
                isTouch = false;
            }
        }
    }
}

