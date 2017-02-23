using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoController : MonoBehaviour {

	public float rotateSpeed; 
	public float rotateRadius;
	public GameObject rotateCenter;

	public bool isSelected;

	// Use this for initialization
	void Start () {
		transform.position = rotateCenter.transform.position + new Vector3 (rotateRadius, 0, 0);
		rotateSpeed = 40.0f;
		rotateRadius = 0;
		isSelected = false;
	}
	
	// Update is called once per frame
	void Update () {
		transform.RotateAround (rotateCenter.transform.position, rotateCenter.transform.up, rotateSpeed * Time.deltaTime);
	}

	void OnTriggerEnter(Collider other) {
		Destroy(other.gameObject);
	}
}
