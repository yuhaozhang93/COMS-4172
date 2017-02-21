using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkController : MonoBehaviour {

	public float speed;
	public int interv;

	// Use this for initialization
	void Start () {
		transform.localPosition = Vector3.zero;
		transform.localEulerAngles = new Vector3 (0, -180, 0);
		speed = 30.0f;
		interv = 20;
	}

	// Update is called once per frame
	void Update () {
		if (Time.frameCount / interv % 2 == 0) {
			transform.localPosition = transform.localPosition + speed * Time.deltaTime * Vector3.up;
		} else {
			transform.localPosition = transform.localPosition - speed * Time.deltaTime * Vector3.up;
		}
	}
}
