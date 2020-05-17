using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretLaser : MonoBehaviour
{
	[SerializeField] float attackDamage = 20f;

	//cached
	Vector2 bulletSpeed;
	TimeWizard timeWizard;

	private void Start()
	{
		timeWizard = FindObjectOfType<TimeWizard>();
		bulletSpeed = new Vector2(0f, timeWizard.GetEnemyBulletSpeed());
	}

	private void FixedUpdate()
	{
		bulletSpeed = new Vector2(0f, timeWizard.GetEnemyBulletSpeed());
		GetComponent<Rigidbody2D>().velocity = bulletSpeed;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		var HitInfo = collision.gameObject; //Player
		if (HitInfo)
		{
			if (HitInfo.GetComponent<Player>())
			{
				HitInfo.GetComponentInChildren<SpriteRenderer>().color = Color.red;
				HitInfo.GetComponent<Health>().DamageHealth(attackDamage);
				GetComponent<SpriteRenderer>().color = Color.clear;
				Destroy(gameObject,0.5f);
			}
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		var HitInfo = collision.gameObject; //Player
		if (HitInfo)
		{
			if (HitInfo.GetComponent<Player>())
			{
				HitInfo.GetComponentInChildren<SpriteRenderer>().color = Color.white;
			}
		}
	}
}
