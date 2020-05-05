using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
	[SerializeField] GameObject LaserPrefab;
	[SerializeField] GameObject Gun;
	[SerializeField] float startTimeBtwSpawns;
	float timeBetweenSpawns;


    // Update is called once per frame
    void Update()
    {
		Shoot();

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


}
