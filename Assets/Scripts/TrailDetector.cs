using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailDetector : MonoBehaviour
{
    [SerializeField] ParticleSystem trailEffect;
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Ground") {
            trailEffect.Play();
        }
    }
    private void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.tag == "Ground") {
            trailEffect.Stop();
        }
    }
}
