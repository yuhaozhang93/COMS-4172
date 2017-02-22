using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionHandler : MonoBehaviour {
	
	GameObject lastSelectedObject;
	Material origMaterial;
	Vector3 hitPoint;
	GameObject rotateCenter;

	// Use this for initialization
	void Start () {
		rotateCenter = GameObject.Find ("RotateCenter");
	}
	
	// Update is called once per frame
	void Update () {
		if (hitPoint != null && hitPoint != rotateCenter.transform.position) {
			float speed = 10.0f;
			rotateCenter.transform.Translate ((hitPoint-rotateCenter.transform.position).normalized * speed * Time.deltaTime);
		}
		if (Input.GetMouseButtonDown (0)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit)) {
				GameObject newlySelectedObject = hit.collider.gameObject;
				switch (newlySelectedObject.name) {
				case "TornadoShell":
				case "CarShell": 
				case "SharkShell":
				case "CowShell":
				case "Barn":
					ChangeSelectState (newlySelectedObject);
					ChangeColor(newlySelectedObject);
					break;
				case "Ground":
					hitPoint = hit.point;
					break;
				default:
					break;
				}
			} 
			/*
			else {
				if (lastSelectedObject != null) {
					lastSelectedObject.GetComponent<Renderer> ().material = new Material (origMaterial);
					DeSelect (lastSelectedObject);
					lastSelectedObject = null;
					origMaterial = null;
				}
			}
			*/
		}
	}

	void ChangeSelectState(GameObject newlySelectedObject){
		if (lastSelectedObject == null) {
			Select (newlySelectedObject);
		} else {
			if (lastSelectedObject.name == newlySelectedObject.name) {
				DeSelect (newlySelectedObject);
			} else {
				Select (newlySelectedObject);
				DeSelect (lastSelectedObject);
			}
		}
	}

	void Select(GameObject go){
		switch (go.name) {
		case "TornadoShell":
			TornadoController tc = go.GetComponentInParent<TornadoController> ();
			tc.isSelected = true;
			break;
		case "CarShell":
			EmptyCarController ecc = go.GetComponentInParent<EmptyCarController> ();
			ecc.isSelected = true;
			break;
		case "SharkShell":
			EmptySharkController esc = go.GetComponentInParent<EmptySharkController> ();
			esc.isSelected = true;
			break;
		case "CowShell":
			CowController cc = go.GetComponentInParent<CowController> ();
			cc.isSelected = true;
			break;
		case "Barn":
			EmptyBarnController ebc = go.GetComponentInParent<EmptyBarnController> ();
			ebc.isSelected = true;
			break;
		}
	}
	void DeSelect(GameObject go){
		switch (go.name) {
		case "TornadoShell":
			TornadoController tc = go.GetComponentInParent<TornadoController> ();
			tc.isSelected = false;
			break;
		case "CarShell":
			EmptyCarController ecc = go.GetComponentInParent<EmptyCarController> ();
			ecc.isSelected = false;
			break;
		case "SharkShell":
			EmptySharkController esc = go.GetComponentInParent<EmptySharkController> ();
			esc.isSelected = false;
			break;
		case "CowShell":
			CowController cc = go.GetComponentInParent<CowController> ();
			cc.isSelected = false;
			break;
		case "Barn":
			EmptyBarnController ebc = go.GetComponentInParent<EmptyBarnController> ();
			ebc.isSelected = false;
			break;
		}
	}

	void ChangeColor(GameObject newlySelectedObject){
		Renderer renderer = newlySelectedObject.GetComponent<Renderer> ();
		if (renderer != null) {
			if (lastSelectedObject == null) {
				lastSelectedObject = newlySelectedObject;
				origMaterial = new Material (renderer.material);
				renderer.material.color = Color.green;
			} else {
				if (lastSelectedObject.name == newlySelectedObject.name) {
					renderer.material = new Material (origMaterial);
					lastSelectedObject = null;
					origMaterial = null;
				} else {
					lastSelectedObject.GetComponent<Renderer> ().material = new Material (origMaterial);
					lastSelectedObject = newlySelectedObject;
					origMaterial = new Material (renderer.material);
					renderer.material.color = Color.green;
				}
			}
		}
	}

}
