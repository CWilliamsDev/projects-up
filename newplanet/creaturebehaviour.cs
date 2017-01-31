using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreatureBehaviour : MonoBehaviour {

	public Transform target;
	public float speed;
	public Transform myTransform;

	public bool herbivore;
	public bool desperate;
	public GameObject herbGfx;
	public GameObject carnGfx;

	public int foodNum;
	public int herbNum;
	public int carnNum;

	public int food;

	public Text info;

	public int health;
	public float defaultLifespan;
	public float lifespan;

	// Audio
	public AudioClip[] clips;
	public AudioSource source;

	void Awake () {
		lifespan = defaultLifespan;
		food = 0;
	}

	void Update () {

		if (health <1) {
			Destroy (gameObject);
		}

		if (target == null) {
			FindTarget();
		}

		if (target != null) {
			ChaseTarget();
		}

		if (food > 0 ) {
			StartCoroutine(StartBreeding(3));
			food = 0;
		}
	}

	void FixedUpdate () {
		lifespan -= Time.deltaTime;

		if (lifespan <= 1) {
			Destroy (gameObject);
		}
	}

  // These functions pull data from the instantation function and declare whether our creature is herb or carn.
  
	public void SetHerbivore (int ls) {
		herbivore = true;
		health = 1;
		gameObject.tag = "Herbivore";
		herbGfx.gameObject.SetActive(true);
		defaultLifespan = ls;
		lifespan = defaultLifespan;
	}

	public void SetCarnivore (int ls) {
		herbivore = false;
		health = 3;
		gameObject.tag = "Carnivore";
		carnGfx.gameObject.SetActive(true);
		defaultLifespan = ls;
		lifespan = defaultLifespan;
	}

  // The creature receives a value on instantiation that decides if it is a herbivore or carnivore.
  // It then inherits behaviour based on that value, and finds a target of either food, or another creature it can eat.
  
	public void FindTarget () {
		if (herbivore) {
			GameObject[] targets = GameObject.FindGameObjectsWithTag("Resource");
			Transform[] targetPos = new Transform[targets.Length];

			for (int t = 0; t < targets.Length; t++) {
				targetPos[t] = targets[t].transform;
			}

			target = targetPos[Random.Range(0, targetPos.Length)];
		} else 

		if (!herbivore && !desperate) {

			GameObject[] targets = GameObject.FindGameObjectsWithTag("Herbivore");
			Transform[] targetPos = new Transform[targets.Length];
			
			if (targets.Length <= 0) {
				desperate = true;
			}

			if (targets.Length > 1 ) {
				for (int t = 0; t < targets.Length; t++) {
					targetPos[t] = targets[t].transform;
				}
			}

			target = targetPos[Random.Range(0, targetPos.Length)];

		} else if (desperate) {
			GameObject[] targets = GameObject.FindGameObjectsWithTag("Carnivore");
			Transform[] targetPos = new Transform[targets.Length];
			

			for (int t = 0; t < targets.Length; t++) {
				targetPos[t] = targets[t].transform;

				float curDistance;
				curDistance = Vector3.Distance(targetPos[t].position, myTransform.position);
			}

			target = targetPos[Random.Range(0, targetPos.Length)];
			//target = targetPos[1];
			float distance = Vector3.Distance(target.position, myTransform.position);

		}
	}

  // AI for how a creature interacts with other creatures and targets.
	public void ChaseTarget() {
		float moveSpeed = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed);
		Vector2 LookAtPoint = new Vector2(target.transform.position.z, target.transform.position.y);
	}

  // This Enumerator handles if the creature can breed, and sets a timer.
	private IEnumerator StartBreeding (int wait) {
		yield return new WaitForSeconds(wait);
		source.clip = clips[2];
				source.Play();
		GameObject offspring;
		offspring = (GameObject) Instantiate (gameObject, transform.position, transform.rotation);
		offspring = (GameObject) Instantiate (gameObject, transform.position, transform.rotation);
		print ("Done");
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Lightning") {
			source.clip = clips[3];
			source.Play();
			Destroy (gameObject);
		}

		if (herbivore){
			if (coll.gameObject.tag == "Resource") {
				Destroy (coll.gameObject, 0.1f);
				food++;
				Debug.Log ("YOU HIT THE FRUIT");
				source.clip = clips[0];
				source.Play();
			}
		} 
		
		if (!herbivore){
			if (coll.gameObject.tag == "Herbivore") {
					Destroy (coll.gameObject, 0.1f);
					food++;
					health--;
					source.clip = clips[1];
					source.Play();
			}
		}

		if (!herbivore && desperate) {
			if (coll.gameObject.tag == "Carnivore") {
					Destroy (coll.gameObject, 0.1f);
					food++;
					health--;
					source.clip = clips[1];
					source.Play();
			}
		}
	}

}
