using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretLaser : MonoBehaviour
{
	Vector2 bulletSpeed;
	TimeWizard t;

	private void Start()
	{
		t = FindObjectOfType<TimeWizard>();
		bulletSpeed = new Vector2(t.GetEnemyBulletSpeed(), 0f);
	}

	private void Update()
	{
		bulletSpeed = new Vector2(t.GetEnemyBulletSpeed(), 0f);
		GetComponent<Rigidbody2D>().velocity = bulletSpeed;
	}
}
