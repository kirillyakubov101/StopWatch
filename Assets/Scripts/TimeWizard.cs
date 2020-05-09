using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeWizard : MonoBehaviour
{
	[SerializeField] float AllRobotSpeed = 8f;
	[SerializeField] float EnemyBulletSpeed = 10f;

	Oscillator[] Obstacles;
	private void Start()
	{
		Obstacles = FindObjectsOfType<Oscillator>();
	}


	public float GetRobotSpeed()
	{
		return AllRobotSpeed;
	}

	public float GetEnemyBulletSpeed()
	{
		return EnemyBulletSpeed;
	}

	public void StopTime()
	{
		//Stop Time
		AllRobotSpeed = 0.5f; 
		EnemyBulletSpeed = 0.1f;

		var allRobots = FindObjectsOfType<Robot>();
		foreach(var child in allRobots)
		{
			child.GetComponent<Animator>().speed = 0.2f;
		}

		foreach(var obstacle in Obstacles)
		{
			obstacle.IsTimeStopped(true);
		}
	}

	public void ContinueTime()
	{
		//Back to normal
		AllRobotSpeed = 8f;
		EnemyBulletSpeed = 10f;

		var allRobots = FindObjectsOfType<Robot>();
		foreach (var child in allRobots)
		{
			child.GetComponent<Animator>().speed = 1f;
		}

		foreach (var obstacle in Obstacles)
		{
			obstacle.IsTimeStopped(false);
		}
	}
}
