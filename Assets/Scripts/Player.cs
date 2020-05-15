using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
	//Configs
	[Header("Movement")]
	[SerializeField] float moveSpeed = 10f;
	[SerializeField] float jumpSpeed = 5f;
	[Header("Gun")]
	[SerializeField] float LaserVelocity = 20f;
	[SerializeField] GameObject Gun;
	[SerializeField] GameObject Laser;
	[Header("Sounds")]
	[SerializeField] AudioClip ShootSound;


	//State
	bool isAlive = true;

	//Cached Components References
	GameSession gameSession;
	TimeSlider timeSliderSript;
	Health health;
	Rigidbody2D rigidbody2d;
	Animator animator;
	CapsuleCollider2D Feet;
	BoxCollider2D body;
	TimeWizard timeWizard;
	bool isEchoEnabled;



	

	// Start is called before the first frame update
	void Start()
    {
		gameSession = FindObjectOfType<GameSession>();
		timeSliderSript = FindObjectOfType<TimeSlider>();
		rigidbody2d = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		Feet = GetComponent<CapsuleCollider2D>();
		body = GetComponent<BoxCollider2D>();
		timeWizard = FindObjectOfType<TimeWizard>();
		health = GetComponent<Health>();
	}

	// Update is called once per frame
	void Update()
    {
		if (!isAlive) { return; }
			Run();
			FlipSprite();
			CharacterLandingAnimation();
			Shoot();
			Jump();
			PressTheStopWatch();
			Die();
	}

	private void Run()
	{
		float ControlThrow = Input.GetAxis("Horizontal") * moveSpeed;
		Vector2 PlayerVelocity = new Vector2(ControlThrow, rigidbody2d.velocity.y);
		rigidbody2d.velocity = PlayerVelocity;

		if (isEchoEnabled)
		{
			GetComponent<EchoEffect>().EchoMovement();
		}

		bool PlayerHasHorizontalSpeed = Mathf.Abs(rigidbody2d.velocity.x) > Mathf.Epsilon;

		if (!Feet.IsTouchingLayers(LayerMask.GetMask("Ground")))
		{
			animator.SetBool("Running", false); //avoid running in the air
			return;
		}
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
		if (!Feet.IsTouchingLayers(LayerMask.GetMask("Ground"))){return;} //if it's in the air, avoid jumping again
		
		if (Input.GetButtonDown("Jump"))
		{
			animator.SetBool("Landed", false);
			Vector2 JumpVelocity = new Vector2(0f, jumpSpeed);
			rigidbody2d.velocity += JumpVelocity;
			animator.SetTrigger("Jumping");
		}
	}

	private void Shoot()
	{
		if (Input.GetKeyDown(KeyCode.F) && gameSession.GetAmmoCount() > 0)
		{
			moveSpeed = 0f;
			
			AudioSource.PlayClipAtPoint(ShootSound,transform.position);
			animator.SetBool("Shooting", true);
		}
		if (Input.GetKeyUp(KeyCode.F))
		{
			moveSpeed = 10f;
			animator.SetBool("Shooting", false);
		}
	}
	
	private void ShootLaser()
	{
		if(gameSession.GetAmmoCount() > 0)
		{
			gameSession.ReduceAmmo();
			float DirectionOfThePlayer = Mathf.Sign(transform.localScale.x);
			var LaserGameOject = Instantiate(Laser, Gun.transform.position, Quaternion.identity);
			//LaserGameOject.transform.Rotate(0f, 0f, 90f);
			LaserGameOject.GetComponent<Rigidbody2D>().velocity = new Vector2(LaserVelocity * DirectionOfThePlayer, 0f);
		}
		else
		{
			animator.SetBool("Shooting", false);
		}
		
	}

	void PressTheStopWatch()
	{
		if (!gameSession.GetWatchStatus()) { return; }

		if (Input.GetKeyDown(KeyCode.LeftShift) && timeSliderSript.FullEnergy())
		{
			timeSliderSript.IsPaused(true);
			isEchoEnabled = true;
			timeWizard.StopTime();
			moveSpeed = 15f;
		}
		/*if (Input.GetKeyUp(KeyCode.C))
		{
			HandleOutOfTimeEnergy();
		}*/

		if (timeSliderSript.OutOfEnergy())
		{
			HandleOutOfTimeEnergy();
		}
	}

	void Die()
	{
		if (Feet.IsTouchingLayers(LayerMask.GetMask("Hazard")) || body.IsTouchingLayers(LayerMask.GetMask("Hazard")))
		{
			StartCoroutine(ProcessDeath());
		}

		if (health.GetHealth() <= 0)
		{
			StartCoroutine(ProcessDeath());
		}
		
	}

	void CharacterLandingAnimation()
	{
		if (Feet.IsTouchingLayers(LayerMask.GetMask("Ground")))
		{
			animator.SetBool("Landed", true);
		}
		else if (!Feet.IsTouchingLayers(LayerMask.GetMask("Ground")))
		{
			animator.SetBool("Landed", false);
		}
			
	}

	IEnumerator ProcessDeath()
	{
		timeWizard.ContinueTime();
		Destroy(rigidbody2d);
		isAlive = false;
		animator.SetBool("Shooting", false);
		animator.SetTrigger("IsDead");
		var AllColliders = GetComponents<Collider2D>();
		foreach (var collider in AllColliders)
		{
			collider.enabled = false;
		}

		yield return new WaitForSeconds(1.5f);
		gameSession.ShowLoseScreen();

	}

	public void HandleOutOfTimeEnergy()
	{
		
		timeSliderSript.IsPaused(false);
		isEchoEnabled = false;
		timeWizard.ContinueTime();
		moveSpeed = 10f;
	}
}

