using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelection : MonoBehaviour {

	public GameObject sc;
	public GameObject obj;
	public bool isSelected;

	void Start () {
		sc = GameObject.FindGameObjectWithTag ("StrategyCam");
		sc.GetComponent<StrategyCamera>();
	}
	void Update () {
		IsWithinSelectionBounds(obj);

		if (isSelected) {
			Selected();
		}
	}

	public bool IsWithinSelectionBounds( GameObject gameObject ){
        if(!sc.GetComponent<StrategyCamera>().dragging )
            return false;
 
        var camera = Camera.main;
        var viewportBounds =
            SelectionUtilities.GetViewportBounds( camera, sc.GetComponent<StrategyCamera>().mousePosition1, Input.mousePosition );
            
        if (viewportBounds.Contains( camera.WorldToViewportPoint( gameObject.transform.position ))) {
				isSelected = true;
				return true;
			}

		if (!viewportBounds.Contains( camera.WorldToViewportPoint( gameObject.transform.position ))) {
			isSelected = false;
			return false;
		}

		return false;
    }

	void Selected () {
		obj.transform.tag = "Selected";
		obj.transform.gameObject.GetComponentInChildren<Projector>().enabled = true;
	}
}
