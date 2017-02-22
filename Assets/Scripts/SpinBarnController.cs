using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinBarnController : MonoBehaviour {

	public float spinSpeed;
	// Use this for initialization
	void Start () {
		transform.localPosition = Vector3.zero;
		spinSpeed = 100.0f;
	}
	
	// Update is called once per frame
	void Update () {
		transform.RotateAround (transform.position, transform.up, spinSpeed * Time.deltaTime);
	}
}
