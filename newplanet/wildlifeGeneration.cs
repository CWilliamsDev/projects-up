using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WildlifeGenerator : MonoBehaviour {

	public int InitialWildlife = 12;
	public int tileCount;

	public float offsetValueX = 3.5f;

	public GameObject[] _legs;
	public GameObject[] _heads;
	public GameObject[] _arms;
	public GameObject[] _extra;
	public GameObject[] _body;
	
	public Transform creature;

	public Transform legPos;
	public Transform headPos;
	public Transform armPos;
	public Transform extraPos;
	public Transform bodyPos;

	public int current = 0;

	public void GenerateWildlife (int initLife) {
		for (int i = 1; i < initLife; i++) {

			Vector3 offsetX = new Vector3 (offsetValueX, 0, 0);

      // Pulls in a random prefab for each body part from an array of possible body parts
      
			GameObject head = _heads[Random.Range(0, _heads.Length)];
			GameObject legs = _legs[Random.Range(0, _legs.Length)];
			GameObject arms = _arms[Random.Range(0, _arms.Length)];
			GameObject extra = _extra[Random.Range(0, _extra.Length)];
			GameObject body = _body[Random.Range(0, _body.Length)];

			GameObject newBody = (GameObject) Instantiate (body, bodyPos.transform.position, transform.rotation);
			GameObject newHead = (GameObject) Instantiate (head, headPos.transform.position, headPos.transform.rotation);
			GameObject newLegs = (GameObject) Instantiate (legs, legPos.transform.position, legPos.transform.rotation);
			GameObject newArms = (GameObject) Instantiate (arms, armPos.transform.position, legPos.transform.rotation);
			GameObject newExtra = (GameObject) Instantiate (extra, extraPos.transform.position, extraPos.transform.rotation);
			Transform newCreature = (Transform) Instantiate (creature, transform.position, transform.rotation);

      // Colours the creature's body at random using HSV
      
			newBody.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
			newHead.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
			newArms.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
			newExtra.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
			newLegs.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);

			offsetValueX += 5;

      // Parents all the parts under one object that also includes it's behaviour, keeps the files neat and clean.
      
			newBody.transform.SetParent(newCreature);
			newHead.transform.SetParent(newCreature);
			newLegs.transform.SetParent(newCreature);
			newArms.transform.SetParent(newCreature);
			newExtra.transform.SetParent(newCreature);

      // Generates values for lifespan, and whether or not our creature is herbivore or carnivore. This data is utilized in the
      // CreatureBehaviour.cs script at a later date after runtime.
      
			int lifespan = Random.Range (16, 25);

			int diet = Random.Range (0, 2);

			if (diet == 0) {
				newCreature.GetComponent<CreatureBehaviour>().SetHerbivore(lifespan);
			} else 

			if (diet == 1) {
				newCreature.GetComponent<CreatureBehaviour>().SetCarnivore(lifespan);
			}

			GameObject[] tiles = GameObject.FindGameObjectsWithTag("Tile");
			Transform[] tilePos = new Transform[tiles.Length];
			for (int t = 0; t < tiles.Length; t++) {
				tilePos[t] = tiles[t].transform;
				newCreature.transform.SetParent (tilePos[Random.Range(0, tiles.Length)], false);
			}

			newCreature.transform.SetParent (null, true);

		}
	}
}
