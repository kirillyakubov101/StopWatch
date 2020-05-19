using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrazyRock : MonoBehaviour
{
	public void StartMovingTheRock()
	{
		GetComponent<Rigidbody2D>().simulated = true;
	}

}
