using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceGenerator : MonoBehaviour {

	public int InitialFood = 12;

	public Transform foodHolder;

	public Transform resource;

	public GameObject[] _food;

	void Start () {
		int initFood;
		initFood = InitialFood;
		InvokeRepeating("GenerateNextFood", 12.0f, 12.0f);
	}

  // Generates the first wave of food onto random tiles.
  
	public void GenerateFood (int initFood) {
		for (int i = 1; i < initFood; i++) {

			GameObject food = _food[Random.Range(0, _food.Length)];
			GameObject newFood = (GameObject) Instantiate (food, transform.position, transform.rotation);
			Transform newResource = (Transform) Instantiate (resource, transform.position, transform.rotation);

			newFood.transform.SetParent (newResource, false);

			GameObject[] tiles = GameObject.FindGameObjectsWithTag("Tile");
			Transform[] tilePos = new Transform[tiles.Length];

			for (int t = 0; t < tiles.Length; t++) {
				tilePos[t] = tiles[t].transform;
				newResource.transform.SetParent (tilePos[Random.Range(0, tiles.Length)], false);
			}

			newResource.transform.SetParent (foodHolder, true);
		}
	}

  // Generates subsequent tiles, this can be modified based on the health of the planet.
  // This feature was never implement but was planned for future releases.
  
	public void GenerateNextFood () {
		for (int i = 1; i < InitialFood; i++) {

			GameObject food = _food[Random.Range(0, _food.Length)];
			GameObject newFood = (GameObject) Instantiate (food, transform.position, transform.rotation);
			Transform newResource = (Transform) Instantiate (resource, transform.position, transform.rotation);

			newFood.transform.SetParent (newResource, false);

			GameObject[] tiles = GameObject.FindGameObjectsWithTag("Tile");
			Transform[] tilePos = new Transform[tiles.Length];

			for (int t = 0; t < tiles.Length; t++) {
				tilePos[t] = tiles[t].transform;
				newResource.transform.SetParent (tilePos[Random.Range(0, tiles.Length)], false);
			}

			newResource.transform.SetParent (foodHolder, true);
		}
	}
}
