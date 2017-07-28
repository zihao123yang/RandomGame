using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debris : MonoBehaviour {

	private SpriteRenderer renderer2D;
	private Color startColor;
	private Color endColor;
	private float time = 0f;


	// Use this for initialization
	void Start () {
		// SpriteRenderer is an actual component you can see of each GameObject in the inspector of Unity
		renderer2D = GetComponent<SpriteRenderer> ();
		startColor = renderer2D.color;
		// alpha is set to 0
		endColor = new Color (startColor.r, startColor.g, startColor.b, 0f);
	}

	// Update is called once per frame
	void Update () {

		//deltaTime = time it takes to render one frame to the next. used to change alpha over time
		time = time + Time.deltaTime;
		renderer2D.material.color = Color.Lerp (startColor, endColor, time/2);

		if (renderer2D.material.color.a == 0f) {
			Destroy (gameObject);
		}
	}
}
