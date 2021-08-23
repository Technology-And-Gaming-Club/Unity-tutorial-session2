using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouseControl : MonoBehaviour {
	public float mouseSensi = 75f;
	public float minX = -360f, maxX = 360f;
	public float minY = -70f, maxY = 70f;
	public float xRotation = 0f, yRotation = 0f;

	Quaternion originalRotation;

	void Start() {
		if(GetComponent<Rigidbody>()) {
			GetComponent<Rigidbody>().freezeRotation = true;
		}
		originalRotation = transform.localRotation;
	}

	void Update() {
		xRotation += Input.GetAxis("Mouse X") * mouseSensi * Time.deltaTime;
		yRotation += Input.GetAxis("Mouse Y") * mouseSensi * Time.deltaTime;
		xRotation = angleClamp(xRotation, minX, maxX);
		yRotation = angleClamp(yRotation, minY, maxY);

		Quaternion xRotate = Quaternion.AngleAxis(xRotation, Vector3.up);
		Quaternion yRotate = Quaternion.AngleAxis(yRotation, -Vector3.right);

		transform.localRotation = originalRotation * xRotate * yRotate;
	}

	float angleClamp(float ang, float min, float max) {
		if(ang <= -360) {
			ang += 360f;
		}
		if(ang >= 360) {
			ang -= 360f;
		}
		return Mathf.Clamp(ang, min, max);
	}
}