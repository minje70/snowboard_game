using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float reloadDelayTime = 1f;
    [SerializeField] ParticleSystem finishEffect;
    [SerializeField] AudioClip finishSFX;
    bool isFinished = false;
    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            if (!isFinished) {
                Debug.Log("finish Trigger Enter!!");
                finishEffect.Play();
                Invoke("ReloadScene", reloadDelayTime);
                GetComponent<AudioSource>().PlayOneShot(finishSFX);
                isFinished = true;
            }
        }
    }

    void ReloadScene() {
        SceneManager.LoadScene(0);
    }
}
