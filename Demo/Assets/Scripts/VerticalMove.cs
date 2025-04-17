using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;

public class VerticalMove : MonoBehaviour
{

	public float verticalSpeed; // Vertical movement speed
	public float movementDuration; // Duration of movement
	private float startSpeed;
	private float pauseDuration;
	public bool willPause = false;
	void Start()
	{
    
		pauseDuration = 0;
		startSpeed = -verticalSpeed;
		//use invoke repeating
		if (willPause)
		{
			pauseDuration = (0.5f * verticalSpeed) + (0.25f * movementDuration);
			InvokeRepeating("Pause", 0, movementDuration + pauseDuration);
		}
		InvokeRepeating("Flip", pauseDuration, movementDuration + pauseDuration);

	}

	// Update is called once per frame
	void Update()
	{
		moveVertically();

	}
	private void Flip()
	{
		verticalSpeed = startSpeed * -1;
		startSpeed *= -1;
	}
	private void moveVertically()
	{
		transform.Translate(0, Time.deltaTime * -verticalSpeed, 0);
	}
	public void Pause()
	{
		verticalSpeed = 0;
	}
	
}
