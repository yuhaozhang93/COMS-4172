using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionController : MonoBehaviour {
	
	GameObject lastSelectedObject;
	Material origMaterial;
	Vector3 hitPoint;
	GameObject rotateCenter;

	Rect windowRect;
	// Use this for initialization
	void Start () {
		rotateCenter = GameObject.Find ("RotateCenter");

		windowRect = new Rect(0, 0, 120, 50);
	}
	
	// Update is called once per frame
	void Update () {
		if (hitPoint != null && !hitPoint.Equals (rotateCenter.transform.position)) {
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
					if (lastSelectedObject == null) {
						lastSelectedObject = newlySelectedObject;
						Renderer renderer = newlySelectedObject.GetComponent<Renderer> ();
						origMaterial = new Material (renderer.material);
						renderer.material.color = Color.green;
					} else {
						if (lastSelectedObject.name == newlySelectedObject.name) {
							lastSelectedObject.GetComponent<Renderer> ().material = new Material (origMaterial);
							lastSelectedObject = null;
							origMaterial = null;
						} else {
							lastSelectedObject.GetComponent<Renderer> ().material = new Material (origMaterial);
							lastSelectedObject = newlySelectedObject;
							Renderer renderer = newlySelectedObject.GetComponent<Renderer> ();
							origMaterial = new Material (renderer.material);
							renderer.material.color = Color.green;
						}
					}
					break;
				case "Ground":
					hitPoint = hit.point;
					break;
				default:
					break;
				}
			} else {
				if (lastSelectedObject != null) {
					lastSelectedObject.GetComponent<Renderer> ().material = new Material (origMaterial);
					lastSelectedObject = null;
					origMaterial = null;
				}
			}
		}
	}

	void OnGUI(){
		//if (lastSelectedObject != null) {
			windowRect = GUI.Window(0, windowRect, DoMyWindow, "My Window");
		//}
	}

	void DoMyWindow(int windowID) {
		GUI.Button (new Rect (0, 0, 100, 20), "Hello World");
	}

}
