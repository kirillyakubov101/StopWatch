using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeWatch : MonoBehaviour
{

	GameSession gameSession;
	
	private void Awake()
	{
		gameSession = FindObjectOfType<GameSession>();
	}


	private void OnTriggerEnter2D(Collider2D collision)
	{
		gameSession.SetWatch(true);
		Destroy(gameObject);
	}
}
