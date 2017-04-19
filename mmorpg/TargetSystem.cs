using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TargetSystem : MonoBehaviour {

	public List <Transform> targets;
	public Transform selectedTarget;

	private Transform myPlayerTransform;

	public Shader selectShader;
	public Shader diffuse;

	public Camera camera;
	RaycastHit los; 

	public bool canSeeTarget = true;

	// Use this for initialization
	void Start () {
		targets = new List<Transform> ();
		selectedTarget = null;
		myPlayerTransform = transform;
		AddTargets ();
	}

	void Update () {
		MouseTarget ();
		TabTarget ();

		if (selectedTarget != null) {

			float distance = Vector3.Distance (myPlayerTransform.position, selectedTarget.transform.position);

			if (Physics.Raycast (myPlayerTransform.position, selectedTarget.transform.position, out los, distance)) {
				if (los.collider.gameObject.tag == "Wall") {
					Debug.Log ("You are LOS");
					canSeeTarget = false;
				}
			} else {
				canSeeTarget = true;
			}
		}
	}

	// Find all players in the game and put them into a selectable array.

	public void AddTargets() {
		GameObject[] players = GameObject.FindGameObjectsWithTag ("Player");

		foreach (GameObject player in players)
			AddTarget (player.transform);

	}

	public void AddTarget(Transform player){
		targets.Add (player);
		player.GetComponent<Renderer> ().material.shader = diffuse;
	}

	private void SortTargets () {
		targets.Sort(delegate (Transform t1, Transform t2) {	
			return (Vector3.Distance(t1.position,myPlayerTransform.position).CompareTo(Vector3.Distance(t2.position, myPlayerTransform.position)));
				});
			
	}

	void MouseTarget () {
		// We draw a ray from the camera to the mouse position on click
		// We use that information to pull the gameobject we've clicked into our target array and select it
		if (Input.GetKeyDown (KeyCode.Mouse0)) {

	
			Ray ray = camera.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;


			if (Physics.Raycast (ray, out hit)) {

				if (selectedTarget != null) {
					DeselectTarget ();

				}

				if (hit.collider.gameObject.tag == "Player" || hit.collider.gameObject.tag == "Target") {
					selectedTarget = null;
					selectedTarget = hit.collider.gameObject.transform;
					IndicateTarget ();
				}
			}
		}
	
	}
			
	// Manually Change Current Target
	public void TabTarget () {
		if (Input.GetKeyDown (KeyCode.Tab)) {
			TargetPlayer ();
		}
	}

	public void TargetPlayer() {
		if (selectedTarget == null) {
			SortTargets ();
			selectedTarget = targets [0];
		} else {
			int index = targets.IndexOf (selectedTarget);

			if (index < targets.Count - 1){
				index++;
			}
			else {
				index = 0;
			}
			DeselectTarget ();
			selectedTarget = targets[index];
		}

		IndicateTarget ();
		Debug.Log ("You are targetting" + selectedTarget);
		
	}

	private void IndicateTarget(){
		float lerp = Mathf.PingPong (Time.time, 1) / 1;
		selectedTarget.gameObject.tag = "Target";
		selectedTarget.GetComponent<Renderer> ().material.shader = selectShader;
	}

	private void DeselectTarget(){
		selectedTarget.GetComponent<Renderer> ().material.shader = diffuse;
		selectedTarget.gameObject.tag = "Player";
		selectedTarget = null;
	}
}
