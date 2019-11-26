﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    public GameObject Platform;
    public AudioTinker playersounds;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    //Gets input from the player and moves character.
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(move * speed);
    }

    //Runs a method playing a tone from AudioTinker.cs dependant on a player action.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            playersounds.PickUpSound();
        }

        if (other.gameObject.CompareTag("Trap"))
        {
            other.gameObject.SetActive(false);
            Destroy(Platform);
            playersounds.TrapSound();
        }

        if (other.gameObject.CompareTag("Goal"))
        {
            other.gameObject.SetActive(false);
            playersounds.Goal();
        }
    }
}
