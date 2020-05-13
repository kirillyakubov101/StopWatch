using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelController : MonoBehaviour
{
	public void LoadStartGame()
	{
		SceneManager.LoadScene(2);
	}

	public void Quit()
	{
		Application.Quit();
	}

	public void LoadMainMenu()
	{
		var gamesession = FindObjectOfType<GameSession>().gameObject;
		Destroy(gamesession);
		SceneManager.LoadScene(1);
	}

	public void ResetGame()
	{
		var gamesession = FindObjectOfType<GameSession>().gameObject;
		Destroy(gamesession);
		SceneManager.LoadScene(2);
		
	}
}

