using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundofTrap : MonoBehaviour
{
    public AudioTinker playersounds;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            playersounds.ObstacleHitGroundSound();
        }
    }
}
