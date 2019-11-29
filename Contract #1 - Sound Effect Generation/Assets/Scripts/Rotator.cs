using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ---------------------------------------------------------------
// <copyright file="Rotator.cs">
// MIT Licence Copyright (c) 2019.
// </copyright>
// <author>James Mead Heath</author>
// <summary>
// Rotates the Game Object which this script is attached to.
// In this case, rotates cubes on the X, Y, and Z axis.
// </summary>
// ---------------------------------------------------------------

public class Rotator : MonoBehaviour
{

    /// <summary>
    /// Rotates the cubes within the game world, makes them more exciting. 
    /// </summary>
    void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }
}
