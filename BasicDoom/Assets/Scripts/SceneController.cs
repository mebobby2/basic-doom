using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour {

	// SerializeField forces Unity to serialize a private field.
	// You will almost never need this. When Unity serializes your scripts, it will 
	// only serialize public fields. If in addition to that you also want Unity to 
	// serialize one of your private fields you can add the SerializeField 
	// attribute to the field.
	// If you want to only expose a variable via the Unity inspector but don't want
	// other script componenents to access the variable, you should use SerializeField
	[SerializeField] // This is an Attribute in C Sharp - which is equilvalent to Java Annotations
	private GameObject enemyPrefab;
	private GameObject _enemy;

	// Update is called once per frame
	void Update () {
		if (_enemy == null) {
			_enemy = Instantiate (enemyPrefab) as GameObject;
			_enemy.transform.position = new Vector3 (0, 1.1f, 0);
			float angle = Random.Range (0, 360);
			_enemy.transform.Rotate (0, angle, 0);
		}
	}
}
