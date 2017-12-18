using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour {
	public enum RotationAxes {
		MouseXAndY = 0,
		MouseX = 1,
		MouseY = 2
	}

	public RotationAxes axes = RotationAxes.MouseXAndY;

	public float sensitivityHor = 9.0f;
	public float sensitivityVert = 9.0f;

	public float minimumVert = -45.0f;
	public float maximumVert = 45.0f;

	private float _rotationX = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (axes == RotationAxes.MouseX) {
//			Debug.Log("Mouse X is "+ Input.GetAxis ("Mouse X"));
//			Debug.Log("Rotate by "+ Input.GetAxis("Mouse X") * sensitivityHor);
//
			// Input.GetAxis("Mouse X") - Moving left is negative and right is positive
			transform.Rotate (0, Input.GetAxis("Mouse X") * sensitivityHor, 0);
		} else if (axes == RotationAxes.MouseY) {
			// Vertical rotation goes around the X axis that's why the variable is called _rotationX
			// Input.GetAxis("Mouse Y") - Moving up is positive and down is negative
			// Hence a smaller _rotationX is looking up, and a bigger one is looking down
			_rotationX -= Input.GetAxis ("Mouse Y") * sensitivityVert;

//			Debug.Log("Mouse Y is "+ Input.GetAxis ("Mouse Y"));
//			Debug.Log("Rotate by "+ _rotationX);

			_rotationX = Mathf.Clamp (_rotationX, minimumVert, maximumVert);

			float rotationY = transform.localEulerAngles.y;

//			Debug.Log("RotationY is "+ rotationY);

			transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
		} else {
			
		}
	}
}
