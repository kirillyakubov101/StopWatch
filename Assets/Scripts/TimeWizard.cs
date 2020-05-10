using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeWizard : MonoBehaviour
{
	[SerializeField] float AllRobotSpeed = 8f;
	[SerializeField] float EnemyBulletSpeed = 10f;

	ObstaclesMovement[] Obstacles;

	private void Start()
	{
		Obstacles = FindObjectsOfType<ObstaclesMovement>();
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
		foreach (var child in Obstacles)
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
		foreach (var child in Obstacles)
		{
			child.ResetVelocity();
		}
	}
}
