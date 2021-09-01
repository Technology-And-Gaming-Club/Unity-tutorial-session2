using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDScripts : MonoBehaviour {
	public PlayerHealth pHealth;
	public GunShootingScript pAmmo;

	public Text pHealthUI;
	public Text pAmmoUI;
	string UItext;

	void Update() {
		UpdateHealth();
		UpdateAmmo();
	}

	void UpdateHealth() {
		UItext = "Health: " + pHealth.currentHealth.ToString() + " / " + pHealth.maxHealth.ToString();
		pHealthUI.text = UItext;
	}
	void UpdateAmmo() {
		UItext = "Ammo: " + pAmmo.remainingClip.ToString() + " / " + pAmmo.clipSize.ToString();
		pAmmoUI.text = UItext;
	}
}
