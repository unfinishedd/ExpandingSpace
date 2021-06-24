using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleScript : MonoBehaviour
{
    [SerializeField] Vector3 movementVector = new Vector3(0f, 0f, 0f);
    public float movementFactor;

    [SerializeField] float period = 4;

    Vector3 currentposition;
    Vector3 startingpos;

    public GameObject Player;
    public Rigidbody m_Rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        currentposition = transform.position;
        startingpos = Player.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (period <= 0f) { return; }

        float cycles = Time.time / period;
        const float tau = Mathf.PI * 2;
        float RawSineWave = Mathf.Sin(cycles * tau);

        movementFactor = RawSineWave / 2f + 0.5f;

        Vector3 offset = movementVector * movementFactor;
        transform.position = currentposition + offset;
    }
    private void OnTriggerEnter(Collider other)
    {
        //Player.transform.position = startingpos;
        //m_Rigidbody.velocity = Vector3.zero;
        FindObjectOfType<SoundManagerScript>().PlayDeathSounds();
        SceneManager.LoadScene("MainScene");

    }
}
