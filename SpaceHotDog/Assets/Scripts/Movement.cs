using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float thrust;
    [SerializeField] float rotate;
    [SerializeField] AudioClip thrustClip;
    [SerializeField] ParticleSystem thrustParticals;
    [SerializeField] ParticleSystem leftThrust;
    [SerializeField] ParticleSystem rightThrust;

    Rigidbody erectBody;
    AudioSource audioSource;
    void Start()
    {
        erectBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        ProcesseThrust();
        ProcessRotation();
    }

    void ProcesseThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            ApplyThrust();
        }
        else 
        {
            thrustParticals.Stop();
            audioSource.Stop();
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotationLeft();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotationRight();
        }

    }

    void ApplyRotationLeft()
    {
        leftThrust.Play();
        erectBody.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotate * Time.deltaTime);
        erectBody.freezeRotation = false;
    }
    void ApplyRotationRight()
    {
        rightThrust.Play();
        erectBody.freezeRotation = true;
        transform.Rotate(Vector3.forward * -rotate * Time.deltaTime);
        erectBody.freezeRotation = false;
    }

    void ApplyThrust()
    {
        thrustParticals.Play();
        if(!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(thrustClip);
        }
        erectBody.AddRelativeForce(Vector3.up * thrust * Time.deltaTime);
          
    }
    
}
