using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundofTrap : MonoBehaviour
{
    public AudioTinker playersounds;

    //Runs a method from AudioTinker.cs to play a sound when the obstacles hit the ground. 
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            playersounds.ObstacleHitGroundSound();
        }
    }
}
