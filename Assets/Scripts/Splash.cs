using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Splash : MonoBehaviour
{
	[SerializeField] float waitTime = 3f;

	// Start is called before the first frame update
	void Start()
    {
		StartCoroutine(StartGame());
	}

   IEnumerator StartGame()
	{
		yield return new WaitForSeconds(waitTime);
		SceneManager.LoadScene(1);
	}
}
