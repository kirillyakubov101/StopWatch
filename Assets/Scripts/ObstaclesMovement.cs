using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesMovement : MonoBehaviour
{
	[Header("Limits")]
	[Tooltip("Upper Limit")]
	[SerializeField] Vector2 GoalVectorUp = new Vector2(0f, 10f);
	[Tooltip("Lower Limit")]
	[SerializeField] Vector2 GoalVectorDown = new Vector2(0f, -10f);
	[SerializeField] Vector2 MovementVector = new Vector2(0f, 5f);
	Vector2 LastMovementVector;
	bool isGoingUp = true;
	Vector2 EndVectorUp;
	Vector2 EndVectorDown;
	float distance;
	Rigidbody2D rigidbody2;
	bool isTimeStopped = false;

    // Start is called before the first frame update
    void Start()
    {
		rigidbody2 = GetComponent<Rigidbody2D>();
		rigidbody2.velocity = MovementVector;
		EndVectorUp = new Vector2(transform.position.x + GoalVectorUp.x, transform.position.y+ GoalVectorUp.y);
		EndVectorDown = new Vector2(transform.position.x + GoalVectorDown.x, transform.position.y + GoalVectorDown.y);

	}


    // Update is called once per frame
    void FixedUpdate()
	{
		AlternateMovement();
	}

	private void AlternateMovement()
	{
		if (isGoingUp)
		{
			distance = Vector2.Distance(transform.position, EndVectorUp);

			if (distance <= 5)
			{
				rigidbody2.velocity = -rigidbody2.velocity;
				LastMovementVector = rigidbody2.velocity;
				isGoingUp = false;
				return;
			}
		}

		else
		{
			distance = Vector2.Distance(transform.position, EndVectorDown);
			if (distance <= 5)
			{
				rigidbody2.velocity = -rigidbody2.velocity;
				LastMovementVector = rigidbody2.velocity;
				isGoingUp = true;
				return;
			}
		}
	}

	public void SetStopVelocity()
	{
		if(rigidbody2.velocity != Vector2.zero)
		{
			rigidbody2.velocity = LastMovementVector.normalized;
		}
		
	}

	public void ResetVelocity()
	{
		rigidbody2.velocity = LastMovementVector;
	}
}
