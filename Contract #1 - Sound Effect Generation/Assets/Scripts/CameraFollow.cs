using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    float min = 0;
    float max = 0;
    public Transform target;
    private Vector3 offset;

    void Start()
    {
        offset = this.transform.position - target.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = offset + target.position;

        //this.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }
}
