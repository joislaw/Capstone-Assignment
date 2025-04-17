using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;

public class Score : MonoBehaviour
{
	public float scoreTracker;
    // Start is called before the first frame update
    void Start()
    {
        scoreTracker = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	void OnCollisionEnter(Collision other)

    {
        // Check if the colliding object is the floor

        if (other.gameObject.tag == "Wall") 
        {
			scoreTracker++;
			Debug.Log("You've been hit!");
			
        }else if(other.gameObject.tag == "Drop"){
			scoreTracker++;
			Debug.Log("You've been hit!");
		}

}

}
