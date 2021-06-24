using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathBarrier : MonoBehaviour
{
    public GameObject Player;
    public Rigidbody m_Rigidbody;
    Vector3 Startingpos;
    // Start is called before the first frame update
    void Start()
    {
        Startingpos = Player.transform.position;
    }
    private void OnTriggerEnter(Collider other)
    {
        //Player.transform.position = Startingpos;
        //m_Rigidbody.velocity = Vector3.zero;
        FindObjectOfType<SoundManagerScript>().PlayDeathSounds();
        SceneManager.LoadScene("MainScene");
    }
}
