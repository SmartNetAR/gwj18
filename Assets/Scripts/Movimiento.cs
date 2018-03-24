using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour {
	//public Collider2D sceneTop;
	public float speed = 8f;
	public Camera camera;
	public float pubTargetCameraMovment = 300f;
	public bool subir = true;

	private Collider2D sceneTop;
	private float originalZoomSize;
	private float limitTop;
	private float limitBotton;
	private float targetCameraMovment;

	private bool sube;
	private bool baja;

	// Use this for initialization
	public float zoomOutSize = 5f;
	void Start () {
		targetCameraMovment = pubTargetCameraMovment;
		if (!subir) {
			targetCameraMovment = - targetCameraMovment;
		}
		limitTop = targetCameraMovment;
		limitBotton = targetCameraMovment;
		sceneTop = GetComponent<Collider2D> ();
		originalZoomSize = camera.orthographicSize;
		Debug.Log (originalZoomSize.ToString() );
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate() {
		
		if (sube) {
			//float actualPosition = camera.transform.position.y;
			if (limitTop > 0f) {
				limitTop -= speed;
			} else {
				sube = false;
			}
			camera.transform.Translate (0f, speed * Time.deltaTime, 0f);
//			camera.transform.position = new Vector3 (
//				camera.transform.position.x, 
//				actualPosition + 7.5f,
//				camera.transform.position.z);
		}

		if (baja) {
			//float actualPosition = camera.transform.position.y;
			if (limitBotton < 0f) {
				limitBotton += speed;
			} else {
				baja = false;
			}
			camera.transform.Translate (0f, -speed * Time.deltaTime, 0f);
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if ( other.CompareTag("Player") ) {
			sube = subir;
			baja = !subir;
			limitTop = targetCameraMovment;
			limitBotton = targetCameraMovment;
		}

//		camera.orthographicSize = zoomOutSize;
//		Debug.Log ("subir camara, llegó: " + other.tag);
//		//Debug.Log (camera.orthographicSize.ToString() );
//		float actualPosition = camera.transform.position.y;
//		camera.transform.position = new Vector3 (
//			camera.transform.position.x, 
//			actualPosition + 7.5f,
//			camera.transform.position.z);
		
		/*Vector2 targetPosition = new Vector2 (camera.transform.position.x, camera.transform.position.y + 7.5f);
		camera.transform.position = Vector2.MoveTowards (
			camera.transform.position, 
			targetPosition, 
			2f * Time.deltaTime); 
		*/
	}
				
}
