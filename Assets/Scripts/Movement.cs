using System.Collections;
using System.Collections.Generic;
using UnityEngine; //Namespace. Where MonoBehaviour lives

// Public is accessable from other classes
// Private is only accessable from itself
public class Movement : MonoBehaviour //Inheritance, Inheriting content from MonoBehaviour
{
    // Get reference to component 
    // Type Variable;
    Rigidbody rb;
    AudioSource audioSource;
    [SerializeField] float mainThrust = 1000f;
    [SerializeField] float rotationThrust = 100f;
  
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
        ProcessRotation();
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationThrust);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotationThrust);
        }
    }

    void ApplyRotation(float rotationThisFrame)
    {   
        rb.freezeRotation = true; //Freezing rotation so that we can manually rotate.
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false; //unfreezing rotation so that we can manually rotate.
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {         
            
            if (!audioSource.isPlaying)
                { 
                 audioSource.Play();
                }

            //rb.AddRelativeForce(Vector3.up); This is another way to do below
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        } 
        else
        {
            audioSource.Stop();
        }

        
    }
}

// TODO: Add a variable so we can tune the main rocketthrust
// TODO: Make the force applied frame rate independent.


// Classes are used to organize our code
// Classes are containers
// A class is usually used for one main thing.
// Generally one class in one script
// Where possible we encapsulate our code
// Don't let everything have access to everything


// Unity has many Classes already created. 
// ClassName.MethodName()