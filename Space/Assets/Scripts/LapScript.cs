using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LapScript : MonoBehaviour
{
    public int TriggerAmount;
    public int LapUIAmount = 0;
    public TextMeshProUGUI LapText;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        LapText.text = LapUIAmount + "/" + 2;


    }
    private void OnTriggerEnter(Collider other)
    {
       
            if (TriggerAmount > LapUIAmount)
            {
            AddNumber();
            }
        
    }
    private void AddNumber()
    {
        LapUIAmount++;
    }
}
