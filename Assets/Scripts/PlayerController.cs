using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torque = 1f;
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] float baseSpeed = 20f;
    SurfaceEffector2D surfaceEffector2D;
    bool canMove = true;
    
    Rigidbody2D rb2d;
    

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }
    void Update()
    {
        if (canMove) {
            BoostPlayer();
        }
    }
    private void FixedUpdate() {
        if (canMove) {
            RotatePlayer();
        }
    }

    private void BoostPlayer()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            surfaceEffector2D.speed = boostSpeed;
        } else if (Input.GetKeyUp(KeyCode.UpArrow)) {
            surfaceEffector2D.speed = baseSpeed;
        }
    }

    public void DeactivateController() {
        canMove = false;
    }

    public void ActivateController() {
        canMove = true;
    }

  private void RotatePlayer() {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Debug.Log("Left");
            rb2d.AddTorque(torque);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Debug.Log("Right");
            rb2d.AddTorque(-torque);
        }
    }
}
