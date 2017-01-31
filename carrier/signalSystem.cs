// Credit also given to Ryan Davis, and Justin Maynard as part of the Game Jam 2017 team.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SignalSystem : MonoBehaviour {

	// Array of Possible Towers
	public GameObject[] signalTowers;

    public GameObject signal;
	public GameObject newSignal;

	// Success 
	public GameObject successImage;
	public GameObject complete;
	//public GameObject transmission;

	void Start () {
		signalTowers[0].gameObject.tag = "Origin";
		InitializeSignal();
    }

    void Update(){
        if (Input.GetKeyDown("left") || Input.GetKeyDown("a")) {
            RotateLeft45();
        }

        if (Input.GetKeyDown("right") || Input.GetKeyDown("d"))
        {
            RotateRight45();
        }
    }

	void InitializeSignal() {
		newSignal = (GameObject) Instantiate (signal, signalTowers[0].transform.position, signalTowers[0].transform.rotation);
	}

	public void RotateLeft45 () {
		newSignal.transform.Rotate(new Vector3(0, -45, 0));
	}

	public void RotateLeft90 () {
		newSignal.transform.Rotate(new Vector3(0, -90, 0));
	}

	public void RotateRight45 () {
		newSignal.transform.Rotate(new Vector3(0, 45, 0));
	}

	public void RotateRight90 () {
		newSignal.transform.Rotate(new Vector3(0, 90, 0));
	}

	public void Success () {
		successImage.SetActive(true);
        //transmission.SetActive(false);
        Debug.Log("LOAD SCENE");
        StartCoroutine("Wait");
    }

    IEnumerator Wait(){
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
