// Credit also given to Ryan Davis, and Justin Maynard as part of the Game Jam 2017 team.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalBehaviour : MonoBehaviour {

	public GameObject signalSys;

	public float maxRadius;
	public float increaseSpeed;
	public float wait;

	// Victory Conditions
	public GameObject successImage;

	void Start () {
		signalSys = GameObject.FindGameObjectWithTag("System");
		successImage.SetActive(false);
		StartCoroutine(Increase());
	}

	IEnumerator Increase () {
		float timer = 0;

		while (true) {
			while (maxRadius > transform.localScale.x) {

				timer += Time.deltaTime;
				transform.localScale += new Vector3 (1, 0, 1) * Time.deltaTime * increaseSpeed;

				if (transform.localScale.x >= maxRadius) {
					Destroy (gameObject);
				}
				
				yield return null;
			}
		}
	}

	void OnCollisionEnter (Collision col) {
		if (col.gameObject.tag == "Tower") {
			gameObject.transform.position = col.transform.position;

			col.gameObject.tag = "Origin";
			transform.localScale = new Vector3 (8, 0, 8);
		}

		if (col.gameObject.tag == "EndTower") {
			signalSys.GetComponent<SignalSystem>().Success();
			gameObject.SetActive(false);
		}
	}


}
