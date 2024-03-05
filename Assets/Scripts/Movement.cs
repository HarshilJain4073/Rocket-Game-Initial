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

    void ProcessThrust()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
            if(!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(mainEngine);
            }
            if (!mainEngineParticle.isPlaying)
            {
                mainEngineParticle.Play();
            }
        }else {
            audioSource.Stop();
            mainEngineParticle.Stop();
        }
    }

    void ProcessRotation()
    {
         if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            ApplyRotation(mainRotate);
            if (!sideThrusterRight.isPlaying)
            {
                sideThrusterRight.Play();
            }
        }
        else if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            ApplyRotation(-mainRotate);
            if (!sideThrusterLeft.isPlaying)
            {
                sideThrusterLeft.Play();
            }
        }else{
            sideThrusterLeft.Stop();
            sideThrusterRight.Stop();
        }
    }

    private void ApplyRotation(float RotationThrust)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * RotationThrust * Time.deltaTime);
        rb.freezeRotation = false;
    }
}
