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
		bulletSpeed = new Vector2(timeWizard.GetEnemyBulletSpeed(), 0f);
	}

	private void FixedUpdate()
	{
		bulletSpeed = new Vector2(timeWizard.GetEnemyBulletSpeed(), 0f);
		GetComponent<Rigidbody2D>().velocity = bulletSpeed;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		var HitInfo = collision.gameObject; //Player
		if (HitInfo)
		{
			if (HitInfo.GetComponent<Player>() && HitInfo.GetComponent<Health>().GetHealth()>0)
			{
				HitInfo.GetComponentInChildren<SpriteRenderer>().color = Color.red;
				HitInfo.GetComponent<Health>().DamageHealth(attackDamage);
				gameObject.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, 0f); //Transperent bullets
				Destroy(gameObject,0.1f);
			}
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		var HitInfo = collision.gameObject; //Player
		if (HitInfo.GetComponent<Player>())
		{
			HitInfo.GetComponentInChildren<SpriteRenderer>().color = Color.white;
		}
	}
}
