using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeWizard : MonoBehaviour
{
	[SerializeField] float AllRobotSpeed = 8f;
	[SerializeField] float EnemyBulletSpeed = 10f;

	Oscillator[] Obstacles;
	ObstaclesMovement[] obs;

	private void Start()
	{
		Obstacles = FindObjectsOfType<Oscillator>();
		obs = FindObjectsOfType<ObstaclesMovement>();
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
		StopTimeRobots(allRobots);

		foreach (var obstacle in Obstacles) // TODO removes
		{
			obstacle.IsTimeStopped(true);
		}

		StopTimeObstacles();
	}

	private static void StopTimeRobots(Robot[] allRobots)
	{
		foreach (var child in allRobots)
		{
			child.GetComponent<Animator>().speed = 0.2f;
		}
	}

	private void StopTimeObstacles()
	{
		foreach (var child in obs)
		{
			child.SetStopVelocity();
		}
	}

	public void ContinueTime()
	{
		//Back to normal
		AllRobotSpeed = 8f;
		EnemyBulletSpeed = 10f;

		var allRobots = FindObjectsOfType<Robot>();
		ReleaseRobots(allRobots);

		foreach (var obstacle in Obstacles) //TODO remove
		{
			obstacle.IsTimeStopped(false);
		}

		ReleaseObstacles();
	}

	private static void ReleaseRobots(Robot[] allRobots)
	{
		foreach (var child in allRobots)
		{
			child.GetComponent<Animator>().speed = 1f;
		}
	}

	private void ReleaseObstacles()
	{
		foreach (var child in obs)
		{
			child.ResetVelocity();
		}
	}
}
