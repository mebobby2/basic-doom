﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour {
	private Camera _camera;

	// Use this for initialization
	void Start () {
		_camera = GetComponent<Camera> ();

		// Hide mouse cursor at center of screen
		// Seems like when you start the game in Unity, it places the mouse cursor
		// at the center of the screen
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			// Although screen coordinates are 2D, with only hor- izontal and vertical components 
			// and no depth, a Vector3 was created because Screen- PointToRay() requires that data 
			// type (presumably because calculating the ray involves arithmetic on 3D vectors)
			Vector3 point = new Vector3 (_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
			Ray ray = _camera.ScreenPointToRay (point);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit)) {
				// Coroutines are a Unity-specific way of handling 
				// tasks that execute incrementally over many different frames,
				// as opposed to how most functions make the program wait 
				// until they finish.
				// Once a coroutine is started, it keeps running until the 
				// function is finished; it just pauses along the way
//				StartCoroutine (SphereIndicator (hit.point));

				GameObject hitObject = hit.transform.gameObject;
				ReactiveTarget target = hitObject.GetComponent<ReactiveTarget> ();
				if (target != null) {
					target.ReactToHit ();
				} else {
					StartCoroutine (SphereIndicator (hit.point));
				}
			}
		}
	}

	void OnGUI() {
		int size = 12;
		float posX = _camera.pixelWidth / 2 - size / 4;
		float posY = _camera.pixelHeight / 2 - size / 2;
		GUI.Label (new Rect (posX, posY, size, size), "*");
	}

	private IEnumerator SphereIndicator(Vector3 pos) {
		GameObject sphere = GameObject.CreatePrimitive (PrimitiveType.Sphere);
		sphere.transform.position = pos;

		// yield pauses the coroutine, and it will be executed where it left off
		// in the next frame. Here we intentionally make the coroutine get executed
		// again in 1 second isntead of the next frame.
		yield return new WaitForSeconds (1); 

		Destroy (sphere);
	}
}
