using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float speed = 150f;
	public Vector2 maxVelocity = new Vector2(60, 150);
	public float flySpeed = 200f;
	public bool standing;
	public float standingThreshold = 4f;
	public float speedMultiplier = .3f;

	private Rigidbody2D body2D;
	private SpriteRenderer renderer2D;
	private PlayerController controller;
	private Animator animator;

	// Use this for initialization
	void Start () {
		//these components can be seen by pressing the Player under game staging in Unity
		body2D = GetComponent<Rigidbody2D> ();
		renderer2D = GetComponent<SpriteRenderer> ();
		controller = GetComponent<PlayerController> ();
		animator = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {

		var absVelocityX = Mathf.Abs (body2D.velocity.x);
		var absVelocityY = Mathf.Abs (body2D.velocity.y);

		if (absVelocityY <= standingThreshold) {
			standing = true;
		} else {
			standing = false;
		}


		var forceX = 0f;
		var forceY = 0f;

		// moving in the horizontal direction"
		if (controller.moving.x != 0) {
			if (absVelocityX <= maxVelocity.x) {

				var newSpeed = speed * controller.moving.x;

				// if standing is true then set speed to 'speed' else set it to a slower speed
				forceX = standing ? newSpeed : (newSpeed * speedMultiplier);

				renderer2D.flipX = forceX < 0;
			}
			animator.SetInteger ("AnimState", 1);
		} else {
			animator.SetInteger ("AnimState", 0);
		}

		// moving in the vertical direction
		if (controller.moving.y > 0) {
			if (absVelocityY <= maxVelocity.y) {
				forceY = flySpeed * controller.moving.y;
			}
			animator.SetInteger ("AnimState", 2);

		} else if (absVelocityY > 0 && !standing) {
			animator.SetInteger ("AnimState", 3);
		}

		body2D.AddForce(new Vector2(forceX,forceY));



	}
}
