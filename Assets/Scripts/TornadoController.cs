using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoController : MonoBehaviour {

	public float rotateSpeed;
	public float rotateRadius;
	public GameObject rotateCenter;

	public GameObject Wind;
	Renderer render;
	Material origMaterial;

	// Use this for initialization
	void Start () {
		rotateSpeed = 20.0f;
		rotateRadius = 0;
		transform.position = rotateCenter.transform.position + new Vector3 (rotateRadius, 0, 0);

		render = Wind.GetComponent<Renderer> ();
		origMaterial = render.material;
	}
	
	// Update is called once per frame
	void Update () {
		transform.RotateAround (rotateCenter.transform.position, rotateCenter.transform.up, rotateSpeed * Time.deltaTime);
		if (Input.GetMouseButtonDown (0)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit) && hit.collider.gameObject.name == "Wind") {
				render.material.color = Color.green;
			}
		}
	}
}
