using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 30.0f;
    private float turnSpeed = 50.0f;
    public float horizontalInput;
    public float forwardInput;
    private AudioSource playerAudio;
    public AudioClip engineNoise;

    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        playerAudio.volume = 0.1f;

    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        // Handle the Engine Noise if Driving Forward
        if (forwardInput > 0)
        {
            playerAudio.PlayOneShot(engineNoise);
        }
        if (forwardInput == 0)
        {
            playerAudio.Stop();
        }

        // Move Forward based on vertical input
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);

        // Steer left/right based on horizontal input.
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
    }


}
