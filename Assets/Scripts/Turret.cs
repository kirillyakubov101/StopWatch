using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
	[SerializeField] GameObject LaserPrefab;
	[SerializeField] GameObject Gun;
	[SerializeField] float startTimeBtwSpawns;
	[Header("Directions Of Shoot")]
	[SerializeField] bool isShootingLeft = true;
	[SerializeField] bool isShootingRight = false;
	[SerializeField] bool isShootingDown = false;
	[SerializeField] bool isShootingUp = false;
	float timeBetweenSpawns;


    // Update is called once per frame
    void Update()
    {
		//Shoot();
		DetermineDirectionOfShoot();

	}


	private void Shoot()
	{
		if (timeBetweenSpawns <= 0)
		{
			var gameobj = Instantiate(LaserPrefab, Gun.transform.position, Quaternion.identity);
			gameobj.transform.transform.Rotate(0f, 0f, 90f);
			timeBetweenSpawns = startTimeBtwSpawns;
			Destroy(gameobj, 5f);
		}
		else
		{
			timeBetweenSpawns -= Time.fixedDeltaTime;
		}
	}

	private void DetermineDirectionOfShoot()
	{
		if (isShootingLeft)
		{
			Debug.Log("we shoot left then");
		}

		else if (isShootingUp)
		{
			Debug.Log("we shoot up then");
		}

		else if (isShootingRight)
		{
			Debug.Log("we shoot right then");
		}
		else if(isShootingDown)
		{
			
		}
	}
}
