using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLineTrigger : MonoBehaviour
{
    public int LapAmount = 0;
    public int MaxLap = 2;
    public GameObject enableTargetObject;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            LapAmount++;
            FindObjectOfType<LapScript>().TriggerAmount++;
        }
    }
    private void Update()
    {
        if (LapAmount == MaxLap)
        {
            enableTargetObject.gameObject.SetActive(true);
        }
    }
}