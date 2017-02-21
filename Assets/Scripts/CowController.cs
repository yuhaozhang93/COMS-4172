using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowController : MonoBehaviour {

	public float speed;
	public int interv;

	// Use this for initialization
	void Start () {
		transform.localPosition = new Vector3 (0, 4 ,-1);
		transform.localEulerAngles = new Vector3 (0, -90, 0);
		speed = 10.0f;
		interv = 60;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.frameCount / interv % 2 == 0) {
			transform.localPosition = transform.localPosition + speed * Time.deltaTime * Vector3.forward;
			transform.localEulerAngles = new Vector3 (0, -90, 0);
		} else {
			transform.localPosition = transform.localPosition - speed * Time.deltaTime * Vector3.forward;
			transform.localEulerAngles = new Vector3 (0, 90, 0);
		}
	}
}
