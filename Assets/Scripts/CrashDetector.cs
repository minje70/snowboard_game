using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CrashDetector : MonoBehaviour
{
    [SerializeField] float reloadTime = 0.5f;
    [SerializeField] ParticleSystem bloodEffect;
    [SerializeField] AudioClip crashSFX;
    bool isCrashed = false;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Ground") {
            if (!isCrashed) {
                bloodEffect.Play();
                Invoke("RelaodScene", reloadTime);
                GetComponent<AudioSource>().PlayOneShot(crashSFX);
                FindObjectOfType<PlayerController>().DeactivateController();
            } else {
                isCrashed = true;
            }
        }
    }

    void RelaodScene() {
        SceneManager.LoadScene(0);
    }
}
