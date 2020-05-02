using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	//Configs
	[SerializeField] float moveSpeed = 10f;
	[SerializeField] float jumpSpeed = 5f;
	[SerializeField] GameObject Gun;
	[SerializeField] GameObject Laser;



	//State



	//Cached Components References
	Rigidbody2D rigidbody2d;
	Animator animator;
	CapsuleCollider2D Feet;


	// Start is called before the first frame update
	void Start()
    {
		rigidbody2d = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		Feet = GetComponent<CapsuleCollider2D>();



	}

    // Update is called once per frame
    void Update()
    {
		Run();
		FlipSprite();
		Jump();
		Shoot();
	}

	private void FixedUpdate()
	{
		

	}

	private void Run()
	{
		float ControlThrow = Input.GetAxis("Horizontal") * moveSpeed;
		Vector2 PlayerVelocity = new Vector2(ControlThrow, rigidbody2d.velocity.y);
		rigidbody2d.velocity = PlayerVelocity;
		bool PlayerHasHorizontalSpeed = Mathf.Abs(rigidbody2d.velocity.x)> Mathf.Epsilon;

		animator.SetBool("Running", PlayerHasHorizontalSpeed);
	}

	private void FlipSprite()
	{
		bool PlayerHasHorizontalSpeed = Mathf.Abs(rigidbody2d.velocity.x) > Mathf.Epsilon;
		if (PlayerHasHorizontalSpeed)
		{
			transform.localScale = new Vector2(Mathf.Sign(rigidbody2d.velocity.x), 1f);
		}
	}

	private void Jump()
	{
	if (!Feet.IsTouchingLayers(LayerMask.GetMask("Ground"))) { return; }

		if (Input.GetButtonDown("Jump"))
		{
			Vector2 JumpVelocity = new Vector2(0f, jumpSpeed);
			rigidbody2d.velocity += JumpVelocity;

			animator.SetTrigger("Jumping");
		}
	}

	private void Shoot()
	{
		if(Input.GetKeyDown(KeyCode.F))
		{
			animator.SetBool("Shooting", true);
		}
		if (Input.GetKeyUp(KeyCode.F))
		{
			animator.SetBool("Shooting", false);
		}
	}
	
	private void ShootLaser()
	{
		float DirectionOfThePlayer = Mathf.Sign(transform.localScale.x);
		var LaserGameOject = Instantiate(Laser, Gun.transform.position, Quaternion.identity);
		LaserGameOject.transform.Rotate(0f, 0f, 90f);
		LaserGameOject.GetComponent<Rigidbody2D>().velocity = new Vector2(10f* DirectionOfThePlayer, 0f);
		Destroy(LaserGameOject, 2f);
	}
}
