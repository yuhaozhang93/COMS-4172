using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkController : MonoBehaviour {

	public float speed;
	public float range;
	public float direction;

	// Use this for initialization
	void Start () {
		transform.localPosition = Vector3.zero;
		transform.localEulerAngles = new Vector3 (0, -180, 0);
		speed = 30.0f;
		range = 8.0F;
		direction = 1.0F;
	}

	// Update is called once per frame
	void Update () {
		if (Vector3.Distance(transform.localPosition, Vector3.zero) > range) {
			direction = -direction;
			while(Vector3.Distance(transform.localPosition, Vector3.zero) > range)
				transform.localPosition = transform.localPosition + Time.deltaTime * speed * direction * Vector3.up;
		}
		transform.localPosition = transform.localPosition + Time.deltaTime * speed * direction * Vector3.up;
	}
}
