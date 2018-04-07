using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour {

	private PlayerController playerController;
	private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
		playerController = GetComponentInParent<PlayerController> ();
		rb2d = GetComponentInParent<Rigidbody2D> ();
	}


	void OnCollisionEnter2D(Collision2D collision)
	{
		/*if (collision.gameObject.CompareTag ( "Platform" )) {
			rb2d.velocity = new Vector3 (0f, 0f, 0f);
			playerController.transform.parent = collision.transform;
			playerController.ItsOnTheGround (true);
		}*/
	}

	void OnCollisionStay2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag ( "Ground" )) {
			playerController.ItsOnTheGround (true);
		}
		/*if (collision.gameObject.CompareTag ( "Platform" )) {
			//playerController.transform.parent = collision.transform;
			playerController.ItsOnTheGround (true);
		}*/
	}

	void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag ( "Ground" )) {
			playerController.ItsOnTheGround (false);
		}
		/*if (collision.gameObject.CompareTag ( "Platform" )) {
			playerController.transform.parent = null;
			playerController.ItsOnTheGround (false);
		}*/
	}
}
