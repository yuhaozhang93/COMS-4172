using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoController : MonoBehaviour {

	public float rotateSpeed;
	public float rotateRadius;
	public GameObject rotateCenter;


	// Use this for initialization
	void Start () {
		rotateSpeed = 20.0f;
		rotateRadius = 0;
		transform.position = rotateCenter.transform.position + new Vector3 (rotateRadius, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		transform.RotateAround (rotateCenter.transform.position, rotateCenter.transform.up, rotateSpeed * Time.deltaTime);
	}
}
