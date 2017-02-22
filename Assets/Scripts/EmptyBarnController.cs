using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyBarnController : MonoBehaviour {

	public float rotateSpeed;
	public float rotateRadius;
	public float rotateHeight;
	public GameObject rotationCenter;
//	public float spinSpeed;

	public bool isSelected;

	// Use this for initialization
	void Start () {
		rotateSpeed = 40.0f;
		rotateRadius = 20.0f;
		rotateHeight = 8.0f;
		transform.position = rotationCenter.transform.position + new Vector3 (rotateRadius, rotateHeight, 0);
//		spinSpeed = 100.0f;

		isSelected = false;
	}
	
	// Update is called once per frame
	void Update () {
//		transform.RotateAround (transform.position, transform.up, spinSpeed * Time.deltaTime);
		transform.RotateAround (rotationCenter.transform.position, rotationCenter.transform.up, rotateSpeed * Time.deltaTime);
	}
}
