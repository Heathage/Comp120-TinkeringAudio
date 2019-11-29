using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ---------------------------------------------------------------------------------------------------
// <copyright file="SoundofTrap.cs">
// MIT Licence Copyright (c) 2019.
// </copyright>
// <author>James Mead Heath</author>
// <summary>
// Checks to see if the Obstacle Object has collided with the Game Object this script is attached to.
// When they collide, runs script that will run a method from the AudioTinker.cs script.
// Which will play a noise to signifying the Obstacles hitting the ground.
// Also destroys the Game Object this is attached to, to prevent the sound being made again. 
// </summary>
// ---------------------------------------------------------------------------------------------------

public class SoundofTrap : MonoBehaviour
{
    public AudioTinker playersounds;

    //Runs a method from AudioTinker.cs to play a sound when the obstacles hit the ground.
    //Prevents the sound happening a second time by destorying the gameObject this script is attached to.
    //Intended to be a one time sound signifying the obstacles hitting the ground.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            playersounds.ObstacleHitGroundSound();
            Destroy(this.gameObject);
        }
    }
}
