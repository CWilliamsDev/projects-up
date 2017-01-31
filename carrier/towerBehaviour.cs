// Credit also given to Ryan Davis, and Justin Maynard as part of the Game Jam 2017 team.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBehaviour : MonoBehaviour {

	public GameObject emitSignal;
	public bool notEnd;

	void Start () {
		notEnd = false;
	}

	void OnCollisionEnter (Collision col) {
		if (col.gameObject.tag == "Wave") {
			emitSignal.SetActive (true);
		}
	}

	void OnCollisionExit (Collision col) {
		if (col.gameObject.tag == "Wave" && notEnd) {
			emitSignal.SetActive (false);
		}
	}
}
