
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

	public int cameraSpeed = 4;

	public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
	
	void Update () {
    Control();
	}
  
  void Control () {
    		if (Input.GetKey (KeyCode.W)) {
			transform.Translate (Vector3.up * Time.deltaTime * cameraSpeed);
		}

		if (Input.GetKey (KeyCode.S)) {
			transform.Translate (Vector3.down * Time.deltaTime * cameraSpeed);
		}

		if (Input.GetKey (KeyCode.A)) {
			transform.Translate (Vector3.left * Time.deltaTime * cameraSpeed);
		}

		if (Input.GetKey (KeyCode.D)) {
			transform.Translate (Vector3.right * Time.deltaTime * cameraSpeed);
		}

		transform.Translate(Vector3.forward * Input.GetAxis("Mouse ScrollWheel") * cameraSpeed * 2);

  }
}
