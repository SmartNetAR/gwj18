using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


	public float maxSpeed = 5f;
	public float speed = 10f;
	public float jumpPower = 6.5f;

	private Rigidbody2D rb2d;
	//private Animator anim;
	private bool jump;
	private bool grounded;



	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		//anim = GetComponent<Animator> ();
	}

	void Update () {
		//anim.SetFloat ("Speed", Mathf.Abs (rb2d.velocity.x));

		//if ( Input.GetKeyDown (KeyCode.UpArrow) && grounded ) {
		if ( Input.GetAxis("Vertical1") > 0.2 && grounded ) {
			jump = true;
		}
	}

	public void ItsOnTheGround( bool boolValue ) {
		grounded = boolValue;
		//anim.SetBool ("Grounded", boolValue);
	}

	void FixedUpdate () {

		DisminuirVelocidad ();

		float h = Input.GetAxis ("Horizontal1");

		rb2d.AddForce (Vector2.right * speed * h);

		//limita la velocidad Clamp devuelve filtrada entre un minimo y un maximo
		float limitedSpeed = Mathf.Clamp( rb2d.velocity.x, -maxSpeed, maxSpeed);
		rb2d.velocity = new Vector2 (limitedSpeed, rb2d.velocity.y);

		//Dar vuelta el player
		if (h > 0.1f) {
			transform.localScale = new Vector3 (1f, 1f, 1f);
		}
		if (h < -0.1f) {
			transform.localScale = new Vector3 (-1f, 1f, 1f);
		}

		//saltar
		if (jump) {
			rb2d.velocity = new Vector2 (rb2d.velocity.x, 0f); // cancela el impulso antes decimal volver a saltar
			rb2d.AddForce (Vector2.up * jumpPower, ForceMode2D.Impulse);
			jump = false;
		}			
	}

	void OnBecameInvisible () {
		transform.position = new Vector3 (-1f, 0f, 0f);
	}

	void DisminuirVelocidad () {
		Vector3 fixedVelocity = rb2d.velocity;
		fixedVelocity.x *= 0.75f;
		if (grounded) {
			rb2d.velocity = fixedVelocity;
		}
	}
}
