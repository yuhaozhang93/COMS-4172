using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCenterController : MonoBehaviour {

	TornadoController tc;
	EmptyCarController ecc;
	EmptySharkController esc;
	SharkController sc;
	CowController cc;
	EmptyBarnController ebc;
	SpinBarnController sbc;

	GameObject tornado;
	GameObject car;
	GameObject emptyCar;
	GameObject shark;
	GameObject emptyShark;
	GameObject emptySpin;
	GameObject emptyBarn;

	float tornadoOldSpeed;
	float carOldSpeed;
	float sharkOldSpeed;
	float sharkOldOsciSpeed;
	float barnOldSpeed;
	float barnOldSpinSpeed;
	float cowOldSpeed;

	bool allPaused;
	bool barnPaused;
	bool sharkPaused;
	bool carPaused;

	Rect windowRect;
	float tornadoScale;
	float barnRotateSpeed;
	float barnSpinSpeed;
	float sharkRotateSpeed;
	float sharkOsciSpeed;
	float sharkOsciRange;
	float carRotateSpeed;
	float carDirection;

	// Use this for initialization
	void Start () {
		transform.position = Vector3.zero;

		tc = GetComponentInChildren<TornadoController> ();
		ecc = GetComponentInChildren<EmptyCarController> ();
		esc = GetComponentInChildren<EmptySharkController> ();
		sc = GetComponentInChildren<SharkController> ();
		cc = GetComponentInChildren<CowController> ();
		ebc = GetComponentInChildren<EmptyBarnController> ();
		sbc = GetComponentInChildren<SpinBarnController> ();

		tornado = GameObject.Find ("Tornado");
		car = GameObject.Find ("Car");
		emptyCar = GameObject.Find ("EmptyCar");
		shark = GameObject.Find ("Shark");
		emptyShark = GameObject.Find ("EmptyShark");
		emptySpin = GameObject.Find("EmptySpin");
		emptyBarn = GameObject.Find("EmptyBarn");


		tornadoOldSpeed = 0;
		carOldSpeed = 0;
		sharkOldSpeed = 0;
		sharkOldOsciSpeed = 0;
		barnOldSpeed = 0;
		barnOldSpinSpeed = 0;
		cowOldSpeed = 0;

		allPaused = false;
		barnPaused = false;
		sharkPaused = false;
		carPaused = false;

		windowRect = new Rect(0, 0, 600, 200);
		tornadoScale = 1.0F;
		barnRotateSpeed = 40.0f;
		barnSpinSpeed = 100.0F;
		sharkRotateSpeed = 60.0f;
		sharkOsciSpeed = 30.0f;
		sharkOsciRange = 8.0F;
		carRotateSpeed = 30.0F;
		carDirection = 180.0F;

	}
	
	// Update is called once per frame
	void Update () {
		if (tc.isSelected) {
			if (carPaused) {
				ResumeCar ();
				carPaused = false;
			}
			if (sharkPaused) {
				ResumeShark ();
				sharkPaused = false;
			}
			if (barnPaused) {
				ResumeBarn ();
				barnPaused = false;
			}
			if (!allPaused) {
				PauseAll ();
				allPaused = true;
			}
		}
		if (ebc.isSelected || cc.isSelected) {
			if (!allPaused && !barnPaused) {
				PauseBarn ();
				barnPaused = true;
			}
		}
		if (esc.isSelected) {
			if (!allPaused && !sharkPaused) {
				PauseShark ();
				sharkPaused = true;
			}
		}
		if (ecc.isSelected) {
			if (!allPaused && !carPaused) {
				PauseCar ();
				carPaused = true;
			}
		}
		if (!ecc.isSelected) {
			if (carPaused) {
				ResumeCar ();
				carPaused = false;
			}
		}
		if (!esc.isSelected) {
			if (sharkPaused) {
				ResumeShark ();
				sharkPaused = false;
			}
		}
		if(!ebc.isSelected && !cc.isSelected){
			if (barnPaused) {
				ResumeBarn ();
				barnPaused = false;
			}
		}
		if (!tc.isSelected) {
			if (allPaused) {
				ResumeAll ();
				allPaused = false;
			}
		}
	}

	void PauseAll(){
		tornadoOldSpeed = tc.rotateSpeed;
		tc.rotateSpeed = 0;
		carOldSpeed = ecc.rotateSpeed;
		ecc.rotateSpeed = 0;
		sharkOldSpeed = esc.rotateSpeed;
		esc.rotateSpeed = 0;
		sharkOldOsciSpeed = sc.speed;
		sc.speed = 0;
		barnOldSpeed = ebc.rotateSpeed;
		ebc.rotateSpeed = 0;
		barnOldSpinSpeed = sbc.spinSpeed;
		sbc.spinSpeed = 0;
		cowOldSpeed = cc.speed;
		cc.speed = 0;
	}

	void ResumeAll(){
		tc.rotateSpeed = tornadoOldSpeed;
		ecc.rotateSpeed = carOldSpeed;
		esc.rotateSpeed = sharkOldSpeed;
		sc.speed = sharkOldOsciSpeed;
		ebc.rotateSpeed = barnOldSpeed;
		sbc.spinSpeed = barnOldSpinSpeed;
		cc.speed = cowOldSpeed;
	}

	void PauseBarn(){
		barnOldSpinSpeed = sbc.spinSpeed;
		sbc.spinSpeed = 0;
		cowOldSpeed = cc.speed;
		cc.speed = 0;
	}

	void ResumeBarn(){
		ebc.rotateSpeed = barnOldSpeed;
		sbc.spinSpeed = barnOldSpinSpeed;
		cc.speed = cowOldSpeed;
	}

	void PauseShark(){
		sharkOldOsciSpeed = sc.speed;
		sc.speed = 0;
	}

	void ResumeShark(){
		esc.rotateSpeed = sharkOldSpeed;
		sc.speed = sharkOldOsciSpeed;
	}

	void PauseCar(){
		carOldSpeed = ecc.rotateSpeed;
		ecc.rotateSpeed = 0;
	}

	void ResumeCar(){
		ecc.rotateSpeed = carOldSpeed;
	}

	void OnGUI(){
		if (tc.isSelected) {
			windowRect = GUI.Window(0, windowRect, TornadoWindow, "Tornado Window");
		}
		if (ebc.isSelected || cc.isSelected) {
			windowRect = GUI.Window(0, windowRect, BarnWindow, "Barn Window");
		}
		if (esc.isSelected) {
			windowRect = GUI.Window(0, windowRect, SharkWindow, "Shark Window");
		}
		if (ecc.isSelected) {
			windowRect = GUI.Window(0, windowRect, CarWindow, "Car Window");
		}
	}

	void TornadoWindow(int windowID) {
		GUI.Label (new Rect (40, 40, 100, 30), "Scale");
		tornadoScale = GUI.HorizontalSlider(new Rect(150, 40, 100, 50), tornadoScale, 0.0F, 3.0F);
		GUI.Box (new Rect (300, 40, 70, 30), tornadoScale.ToString ());
		if (GUI.Button (new Rect (400, 40, 70, 30), "Reset"))
			tornadoScale = 1.0F;
		tornado.transform.localScale = new Vector3(tornadoScale,tornadoScale,tornadoScale);
		car.transform.position = transform.position + ecc.transform.localPosition * tornadoScale;
		shark.transform.position = transform.position + emptyShark.transform.localPosition * tornadoScale;
		emptySpin.transform.position = transform.position + emptyBarn.transform.localPosition * tornadoScale;
	}

	void BarnWindow(int windowID){
		GUI.Label (new Rect (40, 40, 100, 30), "Rotate Speed");
		barnRotateSpeed = GUI.HorizontalSlider(new Rect(150, 40, 100, 50), barnRotateSpeed, 5.0F, 100.0F);
		GUI.Box (new Rect (300, 40, 70, 30), barnRotateSpeed.ToString ());
		if (GUI.Button (new Rect (400, 40, 70, 30), "Reset"))
			barnRotateSpeed = 40.0f;
		barnOldSpeed = barnRotateSpeed;

		GUI.Label (new Rect (40, 100, 100, 30), "Spin Speed");
		barnSpinSpeed = GUI.HorizontalSlider(new Rect(150, 100, 100, 50), barnSpinSpeed, 20.0F, 300.0F);
		GUI.Box (new Rect (300, 100, 70, 30), barnSpinSpeed.ToString ());
		if (GUI.Button (new Rect (400, 100, 70, 30), "Reset"))
			barnSpinSpeed = 100.0f;
		barnOldSpinSpeed = barnSpinSpeed;
	}

	void SharkWindow(int windowID){
		GUI.Label (new Rect (40, 40, 140, 30), "Rotate Speed");
		sharkRotateSpeed = GUI.HorizontalSlider(new Rect(150, 40, 100, 50), sharkRotateSpeed, 10.0F, 200.0F);
		GUI.Box (new Rect (300, 40, 70, 30), sharkRotateSpeed.ToString ());
		if (GUI.Button (new Rect (400, 40, 70, 30), "Reset"))
			sharkRotateSpeed = 60.0f;
		sharkOldSpeed = sharkRotateSpeed;

		GUI.Label (new Rect (40, 100, 140, 30), "Oscillation Speed");
		sharkOsciSpeed = GUI.HorizontalSlider(new Rect(150, 100, 100, 50), sharkOsciSpeed, 5.0F, 60.0F);
		GUI.Box (new Rect (300, 100, 70, 30), sharkOsciSpeed.ToString ());
		if (GUI.Button (new Rect (400, 100, 70, 30), "Reset"))
			sharkOsciSpeed = 30.0f;
		sharkOldOsciSpeed = sharkOsciSpeed;

		GUI.Label (new Rect (40, 160, 140, 30), "Oscillation Range");
		sharkOsciRange = GUI.HorizontalSlider(new Rect(150, 160, 100, 50), sharkOsciRange, 2.0F, 16.0F);
		GUI.Box (new Rect (300, 160, 70, 30), sharkOsciRange.ToString ());
		if (GUI.Button (new Rect (400, 160, 70, 30), "Reset"))
			sharkOsciRange = 8.0f;
		sc.range = sharkOsciRange;
	}

	void CarWindow(int windowID){
		GUI.Label (new Rect (40, 40, 100, 30), "Speed");
		carRotateSpeed = GUI.HorizontalSlider(new Rect(150, 40, 100, 50), carRotateSpeed, 5.0F, 100.0F);
		GUI.Box (new Rect (300, 40, 70, 30), carRotateSpeed.ToString ());
		if (GUI.Button (new Rect (400, 40, 70, 30), "Reset"))
			carRotateSpeed = 30.0f;
		carOldSpeed = carRotateSpeed;

		GUI.Label (new Rect (40, 100, 100, 30), "Direction");
		carDirection = GUI.HorizontalSlider(new Rect(150, 100, 100, 50), carDirection, 0.0F, 360.0F);
		GUI.Box (new Rect (300, 100, 70, 30), carDirection.ToString ());
		if (GUI.Button (new Rect (400, 100, 70, 30), "Reset"))
			carDirection = 180.0f;
		car.transform.localEulerAngles = new Vector3 (0, carDirection, 0);
	}
}
