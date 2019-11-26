using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
