using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour {

	public Debris debris;
	public int totalDebris = 10;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag == "deadly") {
			OnExplode();
		}
	}

	void OnExplode () {
		var trans = transform;
		for (int i = 0; i < totalDebris; i++) {
			trans.TransformPoint(0, -100, 0);
			var clone = Instantiate(debris, trans.position, Quaternion.identity) as Debris;
			var body2D = clone.GetComponent<Rigidbody2D>();
			body2D.AddForce (Vector3.right * Random.Range (-700, 700));
			body2D.AddForce (Vector3.up * Random.Range(200, 1200));

		}
		Destroy (gameObject);
	}
}
