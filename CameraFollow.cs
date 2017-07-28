using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public GameObject target;
	public float scale = 4f;

	//this is the target's transform
	private Transform t;

	//similar to Start but is run before Start(). In this method, going to set camera size depending on aspect ratio
	void Awake() {
		var camera = GetComponent<Camera> ();
		//screen.height/2f because unity's coordinate system starts at the center of the screen
		camera.orthographicSize = (Screen.height / 2f) / scale;
	}

	// Use this for initialization
	void Start () {
		t = target.transform;
	}

	// Update is called once per frame
	void Update () {

		if (target != null) {
			//this is the Camera's transform
			transform.position = new Vector3 (t.position.x, t.position.y, transform.position.z);
		}
	}
}
