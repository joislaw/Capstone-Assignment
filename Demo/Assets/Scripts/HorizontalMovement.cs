using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;

public class HorizontalMovement : MonoBehaviour
{

	public float horizontalSpeed; //  movement speed
	public float movementDuration; // Duration of movement
	private float startSpeed;
	private float pauseDuration;
	public bool willPause = false;
	void Start()
	{
		pauseDuration = 0;
		startSpeed = -horizontalSpeed;
		//use invoke repeating
		if (willPause)
		{
			pauseDuration = Random.Range(0.0f, 2.0f);
			InvokeRepeating("Pause", 0, movementDuration + pauseDuration);
		}
		InvokeRepeating("Flip", pauseDuration, movementDuration + pauseDuration);


	}
	void Update()
	{
		moveHorizontally();

	}
	private void Flip()
	{
		horizontalSpeed = startSpeed * -1;
		startSpeed *= -1;
	}
	private void moveHorizontally()
	{
		transform.Translate(Time.deltaTime * -horizontalSpeed, 0, 0);
	}
	public void Pause()
	{
		horizontalSpeed = 0;
	}

}