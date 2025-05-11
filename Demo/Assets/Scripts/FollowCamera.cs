using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowSphereCamera : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float speed = 2;

    void Update()
    {
        transform.position = target.position + offset;
        
    }

    void LateUpdate()
    {
        if (Input.GetMouseButton(1)){
            offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * speed, Vector3.up) * offset;
        }
        transform.LookAt(target.position);
    }
}
