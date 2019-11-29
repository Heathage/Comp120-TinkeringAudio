using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    /// Runs a choosen method from AudioTinker.cs dependant on the action.
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

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            playersounds.WallCollision();
        }
    }


}
