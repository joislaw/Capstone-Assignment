using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading.Tasks;

public class Movement : MonoBehaviour
{
    public GameObject floor;
    public GameObject player;


    Vector3 startPosition = new Vector3(0, 0, 0);
    public int jumpCount;
    // Start is called before the first frame update
    void Start()
    {
        floor = GameObject.FindWithTag("Floor");
        player = GameObject.FindWithTag("Player");
        startPosition = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") && jumpCount > 0)
        {
            Jump();
        }
        if (player.transform.position.y < floor.transform.position.y - 50)
        {
            Debug.Log("You fell off Loser... try again");
            player.transform.position = startPosition;
            player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
    void OnCollisionEnter(Collision other)

    {
        // Check if the colliding object is the floor

        if (other.gameObject.name == "Floor" || other.gameObject.name == "Platform")
        {
            jumpCount = 5;

        }

    }
    void Jump()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 5, 0);
        jumpCount--;
    }

}
