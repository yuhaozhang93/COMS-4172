using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		transform.localPosition = Vector3.zero;
		transform.eulerAngles = new Vector3 (0, 180, 0);
	}
	
	// Update is called once per frame
	void Update () {
	}
}
