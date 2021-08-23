using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShootingScript : MonoBehaviour {
	public float clipSize, remainingClip;
	public Mesh bulletMesh;
	public Material bulletMaterial;
	public Vector3 bulletScale;
	public Transform playerPos;

	public float bulletSpeed;

	void Start() {
		remainingClip = clipSize;
	}

	void Update() {
		if(Input.GetButtonDown("Fire1") && remainingClip > 0) {
			shootGun();
			remainingClip -= 1;
		}
		if(Input.GetButtonDown("Reload")) {
			remainingClip = clipSize;
		}
	}
	
	void shootGun() {
		int layerMask = 1 << 8;
		RaycastHit hit;
		if(Physics.Raycast(playerPos.position, playerPos.forward, out hit, Mathf.Infinity, layerMask)) {
			Debug.DrawRay(playerPos.position, playerPos.forward * hit.distance, Color.green, 2);
			
		}
	}
}
