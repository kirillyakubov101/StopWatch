using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameSession : MonoBehaviour
{
	[SerializeField] TMPro.TMP_Text Ammo;
	[SerializeField] int AmmoCount = 20; 

	private bool hasWatch = false;

	private void Awake()
	{
		int amountOfGameSessions = FindObjectsOfType<GameSession>().Length;

		if(amountOfGameSessions > 1)
		{
			Destroy(gameObject);
		}
		else
		{
			DontDestroyOnLoad(gameObject);
		}
	}

	// Start is called before the first frame update
	void Start()
    {
		Ammo.text = AmmoCount.ToString();
	}

    // Update is called once per frame
    void Update()
    {
        
    }

	public void ReduceAmmo()
	{
		AmmoCount--;
		Ammo.text = AmmoCount.ToString();
	}

	public int GetAmmoCount()
	{
		return AmmoCount;
	}

	public void IncreaceAmmo(int amount)
	{
		AmmoCount += amount;
		Ammo.text = AmmoCount.ToString();
	}

	public void SetWatch(bool status)
	{
		hasWatch = status;
	}

	public bool GetWatchStatus()
	{
		return hasWatch;
	}
}
