using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeWizard : MonoBehaviour
{
	[SerializeField] float AllRobotSpeed = 8f;
	[SerializeField] float EnemyBulletSpeed = 1f;

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
	}

	public void ContinueTime()
	{
		//Back to normal
		AllRobotSpeed = 5f;
		EnemyBulletSpeed = 30f;

		var allRobots = FindObjectsOfType<Robot>();
		foreach (var child in allRobots)
		{
			child.GetComponent<Animator>().speed = 1f;
		}
	}


}
