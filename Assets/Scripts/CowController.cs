using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowController : MonoBehaviour {

	public float speed;
	public float range;
	public float direction;

	public bool isSelected;

	// Use this for initialization
	void Start () {
		transform.localPosition = new Vector3 (0, 4, 4);
		//transform.localPosition = Vector3.zero;
		transform.localEulerAngles = new Vector3 (0, 270, 0);
		speed = 10.0f;
		range = 6.0f;
		direction = 1.0F;

		isSelected = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance(transform.localPosition, new Vector3 (0, 4, 4)) > range) {
			direction = -direction;
			while(Vector3.Distance(transform.localPosition, new Vector3 (0, 4, 4)) > range)
				transform.localPosition = transform.localPosition + Time.deltaTime * speed * direction * Vector3.forward;
		}
		transform.localPosition = transform.localPosition + Time.deltaTime * speed * direction * Vector3.forward;
	}
}
