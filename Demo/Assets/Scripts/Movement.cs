using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading.Tasks;

public class Movement : MonoBehaviour
{
    public GameObject floor;
    public GameObject player;

    [SerializeField] private AudioClip deathSFX;

    private AudioSource audioSource;


    Vector3 startPosition = new Vector3(0, 0, 0);
    public int jumpCount;
    // Start is called before the first frame update
    void Start()
    {
        floor = GameObject.FindWithTag("Floor");
        player = GameObject.FindWithTag("Player");
        startPosition = player.transform.position;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") && jumpCount > 0)
        {
            Jump();
        }
        if (player.transform.position.y < floor.transform.position.y - 20)
        {
            Debug.Log("You fell off Loser... try again");
            Die();
        }
    }
    void OnCollisionEnter(Collision other)

    {
        // Check if the colliding object is the floor

        if (other.gameObject.tag == "Floor")
        {
            jumpCount = 2;

        }

        // if you get hit by the falling objects, you get reset >:3

        if (other.gameObject.tag == "Drop")
        {
            Debug.Log("LOLE YOU DIED");
            Die();
        }

    }
    void Jump()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 5, 0);
        jumpCount--;
    }

    void Die()
    {
        audioSource.clip = deathSFX;
        audioSource.Play();
        player.transform.position = startPosition;
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}
