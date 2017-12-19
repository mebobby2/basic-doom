using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSInput : MonoBehaviour {
	public float speed = 10.0f;

	private CharacterController _characterController;

	// Use this for initialization
	void Start () {
		_characterController = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {
		float deltaX = Input.GetAxis ("Horizontal") * speed;
		float deltaZ = Input.GetAxis ("Vertical") * speed;
		Vector3 movement = new Vector3 (deltaX, 0, deltaZ);
		movement = Vector3.ClampMagnitude (movement, speed);

		movement *= Time.deltaTime;
		movement = transform.TransformDirection (movement); //transform vector from local to global coordinates
		_characterController.Move (movement);
	}
}
