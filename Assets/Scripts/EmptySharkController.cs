using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptySharkController : MonoBehaviour {

	public float rotateSpeed;
	public float rotateRadius;
	public float rotateHeight;
	public GameObject rotationCenter;

	public bool isSelected;

	// Use this for initialization
	void Start () {
		rotateSpeed = 60.0f;
		rotateRadius = 25.0f;
		rotateHeight = 20.0f;
		transform.position = rotationCenter.transform.position + new Vector3 (rotateRadius, rotateHeight, 0);

		isSelected = false;
	}

	// Update is called once per frame
	void Update () {
		transform.RotateAround (rotationCenter.transform.position, rotationCenter.transform.up, rotateSpeed * Time.deltaTime);
	}
}
