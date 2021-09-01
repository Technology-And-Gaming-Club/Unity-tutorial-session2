using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIEnemyControl : MonoBehaviour {
	public GameObject player;
	public GunShootingScript AIgun;
	public CharacterController AIcontrol;
	public float losLength;

	void Start() {
		
	}

	
	void Update() {
		int layerMask = 1 << 6;
		RaycastHit hit;
		if(Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, layerMask)) {
			if(hit.collider.gameObject == player) {
				transform.LookAt(player.transform);
				if(hit.distance < losLength / 100 * 15) {
					//Move Away
					//AIcontrol.Move(-transform.forward * Time.deltaTime);
				} else if(hit.distance < losLength / 2) {
					AIgun.shootGun();
				} else if(hit.distance < losLength) {
					//AIcontrol.Move(transform.forward * Time.deltaTime);
				};

			}
		}
	}
}
