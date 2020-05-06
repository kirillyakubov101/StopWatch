using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeWatch : MonoBehaviour
{

	Player player;
	
	private void Awake()
	{
		player = FindObjectOfType<Player>();
	}


	private void OnTriggerEnter2D(Collider2D collision)
	{
		player.SetHasWatch(true);
		Destroy(gameObject);
	}
}
