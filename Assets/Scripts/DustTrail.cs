using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustTrail : MonoBehaviour
{
    [SerializeField] ParticleSystem snowParticles;

    void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            snowParticles.Play();
        }
    }

    void OnCollisionExit2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            snowParticles.Stop();
        }
    }
}
