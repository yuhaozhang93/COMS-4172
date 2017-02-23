using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	const int DEFAULTMODE = 0;
	const int CARMODE = 1;
	const int FLYINGMODE = 2;

	public int mode;
	public Vector3 offset;
	public Vector3 angle;

	public float pitch;
	public float yaw;

	public GameObject tornado;
	public GameObject car;

	private GameObject flyingObj;

	Rect windowRect;

	// Use this for initialization
	void Start () {
		offset = new Vector3 (-10, 90, -100);
		angle = new Vector3(45, 0, 0);
		mode = DEFAULTMODE;
		flyingObj = GameObject.Find ("Shark");
		windowRect = new Rect(0, 400, 600, 200);
	}
	
	// Update is called once per frame
	void LateUpdate () {
		switch(mode){
		case DEFAULTMODE:
			transform.position = (tornado.transform.position + offset);
			transform.eulerAngles = angle;
			break;
		case CARMODE:
			transform.position = car.transform.position + new Vector3(0,5,0);
			transform.eulerAngles = car.transform.eulerAngles + new Vector3(0, pitch, yaw);
			break;
		case FLYINGMODE:
			transform.position = flyingObj.transform.position - new Vector3 (0, 2, 0);
			transform.LookAt (car.transform);
			break;
		default:
			break;
		}
	}

	//void OnGUI(){
		//windowRect = GUI.Window(0, windowRect, CameraWindow, "Camera Control Plane");
	//}

	void CameraWindow(int windowID) {
		if (GUI.Button (new Rect (40, 450, 70, 30), "Default Mode"))
			mode = DEFAULTMODE;
		if (GUI.Button (new Rect (140, 450, 70, 30), "Car Mode"))
			mode = CARMODE;
		if (GUI.Button (new Rect (240, 450, 70, 30), "Flying Mode"))
			mode = FLYINGMODE;
		if (mode == CARMODE) {
			GUI.Label (new Rect (0, 500, 100, 30), "pitch");
			pitch = GUI.HorizontalSlider(new Rect(150, 500, 100, 50), pitch, -80.0F, 80.0F);
			GUI.Box (new Rect (300, 500, 70, 30), pitch.ToString ());
			if (GUI.Button (new Rect (400, 500, 70, 30), "Reset"))
				pitch = 0;

			GUI.Label (new Rect (0, 600, 100, 30), "Spin Speed");
			yaw = GUI.HorizontalSlider(new Rect(150, 600, 100, 50), yaw, -180.0F, 180.0F);
			GUI.Box (new Rect (300, 600, 70, 30), yaw.ToString ());
			if (GUI.Button (new Rect (400, 600, 70, 30), "Reset"))
				yaw = 0;
		}
	}
}
