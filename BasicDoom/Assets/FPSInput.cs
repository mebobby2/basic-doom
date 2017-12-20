using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class FPSInput : MonoBehaviour {
	public float speed = 10.0f;
	public float gravity = -9.8f;

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
		movement = Vector3.ClampMagnitude (movement, speed); // limit diagonal movement to the same speed as movement along an axis

		// To simulate a constant downwards force on the player to keep him on the ground.
		// However, it’s not always pointed straight down, because the player object can tilt up and down with the mouse.
		// This means if the player is not looking directly straight on in front of him, the gravity force
		// will slowly pull him forwards little big. To fix this, we only allow player to be rotated horizontally
		// so that he is always looking straight on and therefore the gravity is always pointed straight downwards.
		// Then to enable the player to look up and down, we allow the camera object to be rotated vertically.
		movement.y = gravity; 

		movement *= Time.deltaTime;

		//transform vector from local to global coordinates
		// We’ll create the vector with a value to move, say, to the left. 
		// That’s the player’s left, though, which may be a completely different 
		// direction from the world’s left. Hence the need to convert from local
		// to global coordinate system
		movement = transform.TransformDirection (movement); 

		_characterController.Move (movement);
	}
}
