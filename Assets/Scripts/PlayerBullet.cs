using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
	Rigidbody2D Myrigidbody2D;
	Animator animator;

    // Start is called before the first frame update
    void Start()
    {
		Myrigidbody2D = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		Myrigidbody2D.velocity = new Vector2(0f, 0f);
		animator.SetTrigger("Hit");
		Destroy(gameObject, 0.28f);

	}

}
