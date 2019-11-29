using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //Player postion value
    public Transform target;
    //Distance between player and camera.
    private Vector3 offset;

    /// <summary>
    /// Creates a value for offset which defines where the camera is in relation to the player.
    /// </summary>
    void Start()
    {
        offset = this.transform.position - target.position;
    }

    /// <summary>
    /// Moves the camera to follow the player when they move.
    /// Keeps the camera at the same distance away. 
    /// </summary>
    void Update()
    {
        this.transform.position = offset + target.position;

    }
}
