using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    AudioSource audioSource;

    [SerializeField] float mainThrust = 0;
    [SerializeField] float rotationThrust = 0;
    [SerializeField] AudioClip mainEngine;
    
    [SerializeField] ParticleSystem booster1Particles;
    [SerializeField] ParticleSystem booster2Particles;
    [SerializeField] ParticleSystem booster3Particles;
    [SerializeField] ParticleSystem mainBoosterParticles;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessDirection();
    }

    void ProcessThrust()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            StartThrusting();
        }
        else
        {
            audioSource.Stop();
            mainBoosterParticles.Stop();
        }
    }

    void StartThrusting()
    {
        rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainEngine);
        }
        if (!mainBoosterParticles.isPlaying)
        {
            mainBoosterParticles.Play();
        }
    }

    void ProcessDirection()
    {
        if(Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationThrust);

            if (!booster1Particles.isPlaying)
            {
                booster1Particles.Play();
                booster2Particles.Play();
            }
        }
        else if(Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotationThrust);
            
            if (!booster3Particles.isPlaying)
            {
                booster3Particles.Play();
                booster2Particles.Play();
            }
        }
        else
        {
            booster1Particles.Stop();
            booster2Particles.Stop();
            booster3Particles.Stop();
        }
    }

    void ApplyRotation(float rotationThisFrame)
    {
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
    }
}
