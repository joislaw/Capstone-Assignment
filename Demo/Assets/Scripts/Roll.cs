using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roll : MonoBehaviour
{

    public float speed;
    private float horizontal;
    private float vertical;

    // Update is called once per frame
    void Update()
    {
        this.horizontal = Input.GetAxis("Horizontal");
        this.vertical = Input.GetAxis("Vertical");

        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;

        Vector3 forwardRelative = vertical * forward;
        Vector3 rightRelative = horizontal * right;

        Vector3 movement = forwardRelative + rightRelative;
        // Vector3 movement = new Vector3(horizontal, 0, vertical);


        gameObject.transform.GetComponent<Rigidbody>().AddForce(movement * speed);
    }
}