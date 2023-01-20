using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetection : MonoBehaviour
{
    CircleCollider2D head;
    [SerializeField] ParticleSystem bloodParticles;
    [SerializeField] ParticleSystem snowParticles;
    [SerializeField] float reloadSceneDelay = 0.5f;
    [SerializeField] AudioClip crashSFX;
    bool crashed = false;

    void Start()
    {
        head = GetComponent<CircleCollider2D>();
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Ground") && other.collider.IsTouching(head) && !crashed)
        {
            FindObjectOfType<PlayerController>().DisableControls();
            crashed = true;
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            snowParticles.Play();
            bloodParticles.Play();
            Invoke("ReloadScene", reloadSceneDelay);
        }    
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
