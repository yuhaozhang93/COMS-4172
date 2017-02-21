using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyCarController : MonoBehaviour {
	public float rotateSpeed;
	public float rotateRadius;
	public float rotateHeight;
	public GameObject rotationCenter;

	// Use this for initialization
	void Start () {
		rotateSpeed = 30.0f;
		rotateRadius = 15.0f;
		rotateHeight = 0;
		transform.position = rotationCenter.transform.position + new Vector3 (rotateRadius, rotateHeight, 0);
	}

	// Update is called once per frame
	void Update () {
		transform.RotateAround (rotationCenter.transform.position, rotationCenter.transform.up, rotateSpeed * Time.deltaTime);
	}
}
