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
        ProcessRotationRight();
        ProcessRotationLeft();
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

    void ProcessRotationLeft()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotationLeft();
        }
        else 
        {
            leftThrust.Stop();
        }

    }

    private void ProcessRotationRight()
    {
        if (Input.GetKey(KeyCode.D))
        {
            ApplyRotationRight();
        }
        else
        {
            rightThrust.Stop();
        }
    }

    void ApplyRotationLeft()
    {
        if(!leftThrust.isPlaying)
        {
            leftThrust.Play();
        }
        erectBody.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotate * Time.deltaTime);
        erectBody.freezeRotation = false;
    }
    void ApplyRotationRight()
    {
        if(!rightThrust.isPlaying)
        {
            rightThrust.Play();
        }
        erectBody.freezeRotation = true;
        transform.Rotate(Vector3.forward * -rotate * Time.deltaTime);
        erectBody.freezeRotation = false;
    }

    void ApplyThrust()
    {
        if(!thrustParticals.isPlaying)
        {
            thrustParticals.Play();
        }
        if(!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(thrustClip);
        }
        erectBody.AddRelativeForce(Vector3.up * thrust * Time.deltaTime);
          
    }
    
}
