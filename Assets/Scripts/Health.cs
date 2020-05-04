using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
	[SerializeField] float maxHealth = 100f;
	[SerializeField] float currentHealth;

    // Start is called before the first frame update
    void Start()
    {
		currentHealth = maxHealth;

	}

	public float GetHealth()
	{
		return currentHealth;
	}

	public void DamageHealth(float amountOfDamage)
	{
		currentHealth -= amountOfDamage;
	}

}
