using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust = 1000f;
    [SerializeField] float mainRotate = 100f;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] ParticleSystem mainEngineParticle;
    [SerializeField] ParticleSystem sideThrusterLeft;
    [SerializeField] ParticleSystem sideThrusterRight;
    
    Rigidbody rb;
    AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            startThrusting();
        }
        else
        {
            stopThrusting();
        }
    }    
    
    void ProcessRotation()
    {
         if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            RotateLeft();
        }
        else if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            rotateRight();
        }
        else
        {
            stopRotating();
        }
    }

    private void startThrusting()
    {
        rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainEngine);
        }
        if (!mainEngineParticle.isPlaying)
        {
            mainEngineParticle.Play();
        }
    }
    
    private void stopThrusting()
    {
        audioSource.Stop();
        mainEngineParticle.Stop();
    }

    private void RotateLeft()
    {
        ApplyRotation(mainRotate);
        if (!sideThrusterRight.isPlaying)
        {
            sideThrusterRight.Play();
        }
    }

    private void rotateRight()
    {
        ApplyRotation(-mainRotate);
        if (!sideThrusterLeft.isPlaying)
        {
            sideThrusterLeft.Play();
        }
    }

    private void stopRotating()
    {
        sideThrusterLeft.Stop();
        sideThrusterRight.Stop();
    }

    private void ApplyRotation(float RotationThrust)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * RotationThrust * Time.deltaTime);
        rb.freezeRotation = false;
    }
}
