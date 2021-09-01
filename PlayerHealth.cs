using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {
	public float maxHealth, currentHealth;
	
	void Start() {
		resetHealth();
	}

	public void takeDamage(int amount) {
		currentHealth -= amount;
		if(currentHealth < 0) {
			currentHealth = 0;
		}
		Debug.Log("Ouch");
	}

	public void resetHealth() {
		currentHealth = maxHealth;
	}
}
