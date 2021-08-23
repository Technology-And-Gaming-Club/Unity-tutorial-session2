using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
	public CharacterController playerControl;
	public Transform gunScale;
	Vector3 playerVel;
	public float playerSpeed, playerJumpHeight;
	bool groundContact, jump;
	bool crouch;
	float gravity = 9.81f;
	
	void Update() {
		groundClip();
		movementControl();
	}

	void groundClip() {
		if(playerControl.isGrounded) {
			if(playerVel.y < 0) {
				playerVel.y = 0f;
			}
		}
		playerControl.Move(playerVel * Time.deltaTime);
	}
	void movementControl() {
		Vector3 moveDir = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0) * new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		playerControl.Move(moveDir * Time.deltaTime * playerSpeed);

		groundContact = gameObject.transform.position.y > 1.56f && gameObject.transform.position.y < 1.6f;
		jump = Input.GetAxis("Jump") > 0.5f;

		if(groundContact && jump) {
			playerVel.y = Mathf.Sqrt(playerJumpHeight * 3.0f * gravity);
		}

		crouch = Input.GetAxis("Crouch") > 0.5f;
		Vector3 targetScale = new Vector3(1, 1, 1);
		if(crouch) {
			targetScale.y = 0.5f;
		}
		transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime * 5.0f);
		gunScale.localScale = new Vector3(1, 1 / transform.localScale.y, 1);
		playerVel.y -= gravity * Time.deltaTime;
		playerControl.Move(playerVel * Time.deltaTime);
	}
}
