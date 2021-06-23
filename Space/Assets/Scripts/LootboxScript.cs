using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootboxScript : MonoBehaviour
{
    public float Timer = 5f;  // timer
    public MeshRenderer MR;
    public MeshRenderer MR2;
    public BoxCollider BC;
    public bool isTouch = false;
    public bool isRepeat = false;
    public bool ActivateItem = false;
    public bool HasItem = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        if (isTouch == true)
        {
            Timer -= Time.deltaTime;

            if (Timer <= 0)
            {
                if (isRepeat == true)
                {
                    MR.enabled = true;
                    MR2.enabled = true;
                    BC.enabled = true;
                    isTouch = false;
                    const int timeoutRefresh = 3;

                    Timer = timeoutRefresh;

                }


            }
        }
    }
    public void OnTriggerEnter(Collider collider)
    {


        if (collider.tag == "Player")
        {

            isTouch = true;
            isRepeat = true;
            MR.enabled = false;
            MR2.enabled = false;
            BC.enabled = true;
            HasItem = true;
        }

    }
}
