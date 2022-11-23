using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// all camera code was borrowed from https://www.youtube.com/watch?v=FXqwunFQuao&ab_channel=AnupPrasad  "How to Make Camera Follow In UNITY 2D"


public class CameraFollow : MonoBehaviour
{
    public float FollowSpeed = 8f;
    public float yOffset = 0.03f;
    public Transform target;

    void Update()
    {

        Vector3 newPos = new Vector3(target.position.x, target.position.y + yOffset, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
    }
}
