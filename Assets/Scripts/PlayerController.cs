using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public int m_Id;
	public float m_Speed;

	private Rigidbody2D rb2D;
	private bool grounded = false;

	private string m_MovementAxisName;
	private string m_JumpName;

	void Start() {
		m_MovementAxisName = "Horizontal" + m_Id;
		m_JumpName = "Jump" + m_Id;
		rb2D = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate () {
		RunAxis ();
		Jump ();

	}

	void RunAxis() {
		float horizontalMovment = Input.GetAxis (m_MovementAxisName);
			if (GetComponent<SpriteRenderer>().flipX) {
				GetComponent<SpriteRenderer> ().flipX = false;
			}
			transform.Translate ( horizontalMovment * m_Speed * Time.deltaTime, 0, 0) ;

		/* 
		if ( Input.GetAxis("Horizontal") < -0.1f ) {
			if (!GetComponent<SpriteRenderer>().flipX) {
				GetComponent<SpriteRenderer> ().flipX = true;
			}
			transform.Translate ( -0.1f * m_Speed, 0, 0) ;
		}
		*/
	}

	void RunGetKey() {
		if (Input.GetKey(KeyCode.RightArrow) )			{
			if (GetComponent<SpriteRenderer>().flipX) {
				GetComponent<SpriteRenderer> ().flipX = false;
			}
			transform.Translate ( 0.1f * m_Speed, 0, 0) ;
		}
		if (Input.GetKey(KeyCode.LeftArrow) ) {
			if (!GetComponent<SpriteRenderer>().flipX) {
				GetComponent<SpriteRenderer> ().flipX = true;
			}
			transform.Translate ( -0.1f * m_Speed, 0, 0) ;
		}
	}

	void Jump() {
		if ( Input.GetAxis(m_JumpName) > 0f ) {
			rb2D.velocity = new Vector2 (rb2D.velocity.x, 10f);
		}
	}

	
}
