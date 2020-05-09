using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
	[SerializeField] Vector2 movementVector = new Vector2(10f, 10f);
	[SerializeField] float periodAfterStopTime = 2f;
	[SerializeField] float period = 2f;

	bool timeStopped = false;

	TimeWizard timeWizard;

	float movementFactor;
	Vector2 startingPos;
	const float tau = Mathf.PI * 2f;  //6.283185

	// Start is called before the first frame update
	void Start()
	{
		startingPos = transform.position;
		timeWizard = FindObjectOfType<TimeWizard>();

	}

	// Update is called once per frame
	void Update()
	{
		if (period <= Mathf.Epsilon) { return; }

		float cycles;
		if (timeStopped)
		{
			cycles = Time.time / periodAfterStopTime;
		}
		else
		{
			cycles = Time.time / period;
		}

		
		float rawSinWave = Mathf.Sin(cycles * tau);

		movementFactor = rawSinWave / 2f + 0.5f;

		Vector2 Offset = movementVector * movementFactor;

		transform.position = startingPos + Offset;

	}

	public void IsTimeStopped(bool status) //for the player script when he presses "C"
	{
		timeStopped = status;
	}

	
}
