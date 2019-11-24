using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    public GameObject Platform;
    public AudioTinker pickup;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(move * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            pickup.pickUp();
        }

        if (other.gameObject.CompareTag("Trap"))
        {
            other.gameObject.SetActive(false);
            Destroy(Platform);
        }

        if (other.gameObject.CompareTag("Goal"))
        {
            other.gameObject.SetActive(false);
        }
    }
}
