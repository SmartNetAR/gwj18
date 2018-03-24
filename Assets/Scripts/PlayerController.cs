using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public float Speed;

	private Rigidbody2D rb2D;
	private bool grounded = false;

	void Start() {
		rb2D = GetComponent<Rigidbody2D> ();
	}

	void Update () {
		if (Input.GetKey(KeyCode.RightArrow) )			{
			if (GetComponent<SpriteRenderer>().flipX) {
				GetComponent<SpriteRenderer> ().flipX = false;
			}
			transform.Translate ( 0.1f * Speed, 0, 0) ;
		}
		if (Input.GetKey(KeyCode.LeftArrow) ) {
			if (!GetComponent<SpriteRenderer>().flipX) {
				GetComponent<SpriteRenderer> ().flipX = true;
			}
			transform.Translate ( -0.1f * Speed, 0, 0) ;
		}
		if ( Input.GetAxis("Jump") > 0f ) {
			rb2D.velocity = new Vector2 (rb2D.velocity.x, 10f);
		}
	}
	
}
