using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class WorldManager : MonoBehaviour {

	public MapGenerator mapGen;
	public WildlifeGenerator wildGen;
	public ResourceGenerator resGen;

	// Hiding Highscore 
	public GameObject highscore;

	public int initFood;
	public int initLife;
	public int initSize;

	public GameObject small;
	public GameObject medium;
	public GameObject large;

	public GameObject low;
	public GameObject med;
	public GameObject high;

	public GameObject lowpop;
	public GameObject medpop;
	public GameObject highpop;

	public GameObject menu;

	// Sounds
	public AudioSource source;
	public AudioClip[] clips;

	void Start () {
		highscore.SetActive(true);
	}

	// Set Initial Map Size 
	public void SmallMap () {
		initSize = 6;
		small.gameObject.SetActive(true);
		medium.gameObject.SetActive(false);
		large.gameObject.SetActive(false);
		source.clip = clips[0];
		source.Play();
	}

	public void MediumMap () {
		initSize = 12;
		small.gameObject.SetActive(false);
		medium.gameObject.SetActive(true);
		large.gameObject.SetActive(false);
		source.clip = clips[0];
		source.Play();
	}

	public void LargeMap () {
		initSize = 24;
		small.gameObject.SetActive(false);
		medium.gameObject.SetActive(false);
		large.gameObject.SetActive(true);
		source.clip = clips[0];
		source.Play();
	}

	// Set Initial Food
	public void LowFood () {
		initFood = 8;
		low.gameObject.SetActive(true);
		med.gameObject.SetActive(false);
		high.gameObject.SetActive(false);
		source.clip = clips[0];
		source.Play();
	}

	public void MediumFood () {
		initFood = 16;
		low.gameObject.SetActive(false);
		med.gameObject.SetActive(true);
		high.gameObject.SetActive(false);
		source.clip = clips[0];
		source.Play();
	}

	public void HighFood () {
		initFood = 44;
		low.gameObject.SetActive(false);
		med.gameObject.SetActive(false);
		high.gameObject.SetActive(true);
		source.clip = clips[0];
		source.Play();
	}

	// Set Initial Life
	public void LowLife () {
		initLife = 8;
		lowpop.gameObject.SetActive(true);
		medpop.gameObject.SetActive(false);
		highpop.gameObject.SetActive(false);
		source.clip = clips[0];
		source.Play();
	}

	public void MediumLife () {
		initLife = 17;
		lowpop.gameObject.SetActive(false);
		medpop.gameObject.SetActive(true);
		highpop.gameObject.SetActive(false);
		source.clip = clips[0];
		source.Play();
	}

	public void HighLife () {
		initLife = 32;
		lowpop.gameObject.SetActive(false);
		medpop.gameObject.SetActive(false);
		highpop.gameObject.SetActive(true);
		source.clip = clips[0];
		source.Play();
	}

	public void Restart () {
		SceneManager.LoadScene("World");
		source.clip = clips[1];
		source.Play();
	}

	public void GenerateWorld () {
		menu.gameObject.SetActive(false);
		mapGen.GetComponent<MapGenerator>().GenerateMap(initSize);
		resGen.GetComponent<ResourceGenerator>().GenerateFood(initFood);
		wildGen.GetComponent<WildlifeGenerator>().GenerateWildlife(initLife);
		highscore.SetActive(false);
		source.clip = clips[1];
		source.Play();
	}
}
