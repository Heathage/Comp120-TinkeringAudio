using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ---------------------------------------------------------------
// <copyright file="Move.cs">
// MIT Licence Copyright (c) 2019.
// </copyright>
// <author>James Mead Heath</author>
// <summary>
// Allows the player to move.
// Keeps track of what the player may collide with while moving.
// Executing code dependant on what they have collided with.
// </summary>
// ---------------------------------------------------------------

public class Move : MonoBehaviour
{
    public float speed;
    public int pickUpsNeeded = 0;
    private Rigidbody rb;
    public GameObject Platform;
    public AudioTinker playersounds;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// Allows the player to move.
    /// </summary>
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(move * speed);
    }

    /// <summary>
    /// Checks to see what player action has been done dependant on what the player collided with. E.g, Picking up an item.
    /// Runs a chosen method from AudioTinker.cs dependant on the action.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            pickUpsNeeded += 1;
            Debug.Log(pickUpsNeeded);
            other.gameObject.SetActive(false);
            playersounds.PickUpSound();
        }

        if (other.gameObject.CompareTag("Trap"))
        {
            other.gameObject.SetActive(false);
            Destroy(Platform);
            playersounds.TrapSound();
        }

        if ((other.gameObject.CompareTag("Goal")) && (pickUpsNeeded == 14))
        {
            other.gameObject.SetActive(false);
            playersounds.Goal();
        }

        if ((other.gameObject.CompareTag("Goal")) && (pickUpsNeeded != 14))
        {
            playersounds.GoalNotComplete();
        }
    }

    /// <summary>
    /// Checks to see if the player has collided with any of the walls.
    /// Runs the chosen method from AudioTinker.cs to signify this. 
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            playersounds.WallCollision();
        }
    }


}
