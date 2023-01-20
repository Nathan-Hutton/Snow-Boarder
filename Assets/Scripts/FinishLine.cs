using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] ParticleSystem finishEffect;
    [SerializeField] float sceneReloadDelay = 1f;
    bool finished = false;

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player") && !finished)
        {
            finished = true;
            GetComponent<AudioSource>().Play();
            finishEffect.Play();
            Invoke("ReloadScene", sceneReloadDelay);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
