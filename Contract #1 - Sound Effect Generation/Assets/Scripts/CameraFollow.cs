using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    private Vector3 offset;

    //Creates an offset position value for where the camera is in relation to the player.
    void Start()
    {
        offset = this.transform.position - target.position;
    }

    //Moves the camera when the player moves.
    void Update()
    {
        this.transform.position = offset + target.position;

        //this.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }
}
