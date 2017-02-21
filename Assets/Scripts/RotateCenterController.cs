using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCenterController : MonoBehaviour {

	public float speed;
	public Vector3 direction;
	// Use this for initialization
	void Start () {
		transform.position = Vector3.zero;
		speed = 1.0f;
		direction = new Vector3 (1, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
	}
}
