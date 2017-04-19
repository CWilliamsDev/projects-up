using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Actions : MonoBehaviour {

	public GameObject[] _unitPortrait;
	public Text selectedText;
	public enum selectedType {
		castle,
		knight,
		nullSelect,
		multiple
	}
	public selectedType type;

	public Image[] actionSlot;


	public Sprite[] actionGraphic;
	void Start () {
		type = selectedType.nullSelect;
	}
	void Update () {
		CheckSelected();
	}
	
	void CheckSelected() {

		switch (type) {
			// Basic Castle
			case selectedType.castle:
				actionSlot[0].sprite = actionGraphic[1];
				actionSlot[1].sprite = actionGraphic[1];
				actionSlot[2].sprite = actionGraphic[1];
				actionSlot[3].sprite = actionGraphic[1];
				actionSlot[4].sprite = actionGraphic[1];
				actionSlot[5].sprite = actionGraphic[1];
				actionSlot[6].sprite = actionGraphic[1];
				actionSlot[7].sprite = actionGraphic[1];

				foreach (GameObject portrait in _unitPortrait) {
					portrait.SetActive(false);
				}

				_unitPortrait[1].SetActive(true);
				selectedText.text = "Castle";

				break;
				case selectedType.knight:
				actionSlot[0].sprite = actionGraphic[1];
				actionSlot[1].sprite = actionGraphic[1];
				actionSlot[2].sprite = actionGraphic[1];
				actionSlot[3].sprite = actionGraphic[1];
				actionSlot[4].sprite = actionGraphic[1];
				actionSlot[5].sprite = actionGraphic[1];
				actionSlot[6].sprite = actionGraphic[1];
				actionSlot[7].sprite = actionGraphic[1];

				foreach (GameObject portrait in _unitPortrait) {
					portrait.SetActive(false);
				}

				_unitPortrait[1].SetActive(true);
				selectedText.text = "Knight";

				break;
			case selectedType.nullSelect:
				actionSlot[0].sprite = actionGraphic[0];
				actionSlot[1].sprite = actionGraphic[0];
				actionSlot[2].sprite = actionGraphic[0];
				actionSlot[3].sprite = actionGraphic[0];
				actionSlot[4].sprite = actionGraphic[0];
				actionSlot[5].sprite = actionGraphic[0];
				actionSlot[6].sprite = actionGraphic[0];
				actionSlot[7].sprite = actionGraphic[0];

				selectedText.text = "";

				foreach (GameObject portrait in _unitPortrait) {
					portrait.SetActive(false);
				}

				_unitPortrait[0].SetActive(true);
				break;
			case selectedType.multiple:

				selectedText.text = "Multiple Units";

				foreach (GameObject portrait in _unitPortrait) {
					portrait.SetActive(false);
				}

				_unitPortrait[3].SetActive(true);

			break;
			

		}
	}
}
