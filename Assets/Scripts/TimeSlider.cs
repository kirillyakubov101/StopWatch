using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeSlider : MonoBehaviour
{
	Slider slider;
	[SerializeField] float chargeRateUp = 0.02f;
	[SerializeField] float chargeRateDown = 0.008f;
	bool isPaused = false;

	// Start is called before the first frame update
	void Start()
	{
		slider = GetComponent<Slider>();

	}

	// Update is called once per frame
	void Update()
	{

		RechargeTime();
	}

	void RechargeTime()
	{
		if (!isPaused)
		{
			slider.value += chargeRateUp;
		}
		else
		{
			if (OutOfEnergy())
			{
				FindObjectOfType<Player>().HandleOutOfTimeEnergy();
				FindObjectOfType<TimeWizard>().ContinueTime();
			}
			slider.value -= chargeRateDown;
		}

	}

	public bool IsPaused(bool n)
	{
		isPaused = n;
		return isPaused;
	}

	public bool OutOfEnergy()
	{
		if(slider.value <= 0)
		{
			return true;
			
		}
		else
		{
			return false;
		}
	}

}
