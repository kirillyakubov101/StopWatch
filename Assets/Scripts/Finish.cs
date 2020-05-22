using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
   

	private void OnTriggerEnter2D(Collider2D collision)
	{
		GetComponentInParent<Rigidbody2D>().velocity = new Vector2(0, 6f);
		StartCoroutine(FinishGame());
	}

	IEnumerator FinishGame()
	{
		yield return new WaitForSeconds(3);
		FindObjectOfType<LevelController>().LoadMainMenu(); //TODO CHANGE TO END LEVEL
	}
}
