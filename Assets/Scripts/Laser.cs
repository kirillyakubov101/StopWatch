using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		Shoot();
    }

	private void Shoot()
	{
		GetComponent<Rigidbody2D>().velocity = new Vector2(10f, 0f);
	}
}
