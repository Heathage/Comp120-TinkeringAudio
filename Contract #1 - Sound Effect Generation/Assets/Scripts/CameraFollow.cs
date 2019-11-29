using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ---------------------------------------------------------------
// <copyright file="CameraFollow.cs">
// MIT Licence Copyright (c) 2019.
// </copyright>
// <author>James Mead Heath</author>
// <summary>
// Allows the camera to follow the player when the player moves.
// Keeps the camera at the same distance from the player at all times.
// The camera position is decided within the Unity Editor.
// </summary>
// ---------------------------------------------------------------

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
