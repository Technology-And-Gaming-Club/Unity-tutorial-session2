using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShootingScript : MonoBehaviour {
	public float clipSize, remainingClip;
	public Transform playerPos;
	public ParticleSystem shotSparks;
	public GameObject hitObject;

	bool waiting;

	void Start() {
		remainingClip = clipSize;
		shotSparks.Stop();
	}

	void Update() {
		if(transform.parent.name == "Player") {
			if(Input.GetButtonDown("Fire1")) {
				shootGun();
			}
			if(Input.GetButtonDown("Reload")) {
				reloadGun();
			}
		}
	}
	
	public void shootGun() {
		if(remainingClip > 0) {
			int layerMask = 1 << 6;
			RaycastHit hit;
			if(Physics.Raycast(playerPos.position, playerPos.forward, out hit, Mathf.Infinity, layerMask)) {
				Debug.DrawRay(playerPos.position, playerPos.forward * hit.distance, Color.green, 2);
				hitObject = hit.collider.gameObject;
				Debug.Log(hitObject.name);
				hitObject.GetComponent<PlayerHealth>().takeDamage(30);
				
			}
			shotSparks.Play();
			waiting = false;
			StartCoroutine(pauseShooting());
		
			remainingClip -= 1;
		} else {
			reloadGun();
		}
	}

	void reloadGun() {
		remainingClip = clipSize;

	}

	IEnumerator pauseShooting() {
		yield return new WaitForSeconds(0.15f);
		shotSparks.Stop();
	}
}
