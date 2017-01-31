using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour {

	public GameObject[] _hex;
	public Transform TileHolder;

	public int totalMapSize = 8;

	public float offsetValueX = 3.5f;
	public float offsetValueY = 3f;
	public int mapSizeX = 8;
	public int mapSizeY = 8;

	public void GenerateMap (int initSize) {
		// Size Generation

    // Generates X and Y hex tiles with an offset.
    
		for (int s = 1; s < initSize; s++){
			for (int i = 1; i < mapSizeX + totalMapSize; i++) {
				Vector3 offsetX = new Vector3 (offsetValueX, 0, 0);
				GameObject newHexX = (GameObject) Instantiate (_hex[Random.Range (0, _hex.Length)], transform.position + offsetX, transform.rotation);
				offsetValueX += 3.5f;
				newHexX.transform.SetParent(TileHolder, false);

				// Generate the Y depth of the tiles.
				for (int o  = 1; o < 2; o++) {
					Vector3 offset2 = new Vector3 (offsetValueX - 3.5f, offsetValueY - 1.5f, 0);
					GameObject newHex2 = (GameObject) Instantiate (_hex[Random.Range (0, _hex.Length)], transform.position + offset2, transform.rotation);
					newHex2.transform.SetParent(TileHolder, false);
					
					// Middle Hexes
					Vector3 offset3 = new Vector3 (offsetValueX - 1.75f, offsetValueY - 2.5f, 0);
					GameObject newHex3 = (GameObject) Instantiate (_hex[Random.Range (0, _hex.Length)], transform.position + offset3, transform.rotation);
					newHex3.transform.SetParent(TileHolder, false);
				}
			}

			offsetValueY += 2.1f;
			offsetValueX = 3.5f;
		}
	}

}
