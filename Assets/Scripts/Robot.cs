using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
	[SerializeField] GameObject LaserPrefab;
	[SerializeField] GameObject Gun;
	
	//Cached
	Rigidbody2D myRigidBody2D;
	TimeWizard timeWizard;
	float movementSpeed;
	float moveDirection = 1f;
	Animator animator;

	// Start is called before the first frame update
	void Start()
    {
		myRigidBody2D = GetComponent<Rigidbody2D>();
		timeWizard = FindObjectOfType<TimeWizard>();
		movementSpeed = timeWizard.GetRobotSpeed();
		animator = GetComponent<Animator>();
	}

	private void Update()
	{
		Move();
	}

	private void Shoot()
	{
		var Laser = Instantiate(LaserPrefab, Gun.transform.position, Quaternion.identity);
	}

	private void Move()
	{
		movementSpeed = timeWizard.GetRobotSpeed();
		myRigidBody2D.velocity = new Vector2(movementSpeed* moveDirection, 0f);
	}

	private void OnTriggerExit2D(Collider2D other) 
	{
		//My Method
		moveDirection = -moveDirection;
		transform.localScale = new Vector2(-transform.localScale.x, 1f);
	}
}
