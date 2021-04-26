using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody erectBody;
    [SerializeField] float thrust;
    [SerializeField] float rotate;
    // Start is called before the first frame update
    void Start()
    {
        erectBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcesseThrust();
        ProcessRotation();
    }

    void ProcesseThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            erectBody.AddRelativeForce(Vector3.up * thrust * Time.deltaTime);
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotate);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotate);
        }
    }

    void ApplyRotation(float frameRotation)
    {
        erectBody.freezeRotation = true;
        transform.Rotate(Vector3.forward * frameRotation * Time.deltaTime);
        erectBody.freezeRotation = false;
    }
}
