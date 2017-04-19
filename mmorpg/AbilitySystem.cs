using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine.UI;

public class abilityCastSystem : NetworkBehaviour {

	public List<Ability> abilities;
	public GameObject player;
	public GameObject networkPlayer;
	public TargetSystem targetSystem;
	public Text uiMessage;
	public Text castTimer;
	public Image castGraphic;
	public GameObject uiCastBar;

	// Available abilities
	public GameObject abilityDB;

	public Transform castPoint;
	public bool casting = false;
	public bool isCasting = false;


	void Start () {
		foreach (var ability in abilities) {
			ability.currentCD = ability.cooldown;
			ability.canCast = true;
			ability.spellID = 0;
		}

		uiCastBar.gameObject.SetActive (false);

	}

	public void FixedUpdate() {

		// Ability / Skill Input Method - Cooldown Checker
		// Ability #1
		if (Input.GetKeyDown(KeyCode.Q) && abilities [0].canCast == true && abilities[0].isCasting == false && isCasting == false && networkPlayer.GetComponent<TargetSystem>().canSeeTarget == true) {
			if (abilities [0].currentCD >= abilities[0].cooldown) {
				
				abilities [0].currentCD = 0;
				abilities [0].spellName = abilityDB.GetComponent<AbilityDatabase> ().a1_name;
				abilities [0].totalCast = abilityDB.GetComponent<AbilityDatabase> ().a1_casttime;
				abilities [0].abilityIcon = GetComponent<AbilityIconManager>()._slots [0];
				abilities [0].abilityEffect = abilityDB.GetComponent<AbilityDatabase> ().a1_effect;
				abilities [0].castBar = castGraphic;
				isCasting = true;
				abilities [0].canCast = false;
				abilities [0].isCasting = true;
				abilities [0].castSuccess = false;

				uiMessage.text = "";

				Debug.Log (abilities [1].spellID);
			}
		}

		else if (Input.GetKeyDown(KeyCode.E) && abilities [1].canCast == true && abilities[1].isCasting == false && isCasting == false) {
			if (abilities [1].currentCD >= abilities[1].cooldown && networkPlayer.GetComponent<PlayerMovement> ().isMoving == false) {
				if (networkPlayer.GetComponent<TargetSystem>().selectedTarget != null) {

					abilities [1].currentCD = 0;
					abilities [1].spellName = abilityDB.GetComponent<AbilityDatabase> ().a2_name;
					abilities [1].totalCast = abilityDB.GetComponent<AbilityDatabase> ().a2_casttime;
					abilities [1].abilityIcon = GetComponent<AbilityIconManager>()._slots [1];
					abilities [1].abilityEffect = abilityDB.GetComponent<AbilityDatabase> ().a2_effect;
					abilities [1].castBar = castGraphic;
					isCasting = true;
					abilities [1].canCast = false;
					abilities [1].isCasting = true;
					abilities [1].castSuccess = false;

					uiMessage.text = "";

				}

				if (networkPlayer.GetComponent<TargetSystem>().selectedTarget == null) {
					uiMessage.text = "You need a target.";
				}
			}
		}

		else if (Input.GetKeyDown(KeyCode.R) && abilities [2].canCast == true && abilities[2].isCasting == false && isCasting == false) {
			if (abilities [2].currentCD >= abilities[2].cooldown) {

				abilities [2].currentCD = 0;
				abilities [2].spellName = abilityDB.GetComponent<AbilityDatabase> ().a2_name;
				abilities [2].totalCast = abilityDB.GetComponent<AbilityDatabase> ().a2_casttime;
				abilities [2].abilityIcon = GetComponent<AbilityIconManager>()._slots [2];
				abilities [2].abilityEffect = abilityDB.GetComponent<AbilityDatabase> ().a2_effect;
				abilities [2].castBar = castGraphic;
				isCasting = true;
				abilities [2].canCast = false;
				abilities [2].isCasting = true;
				abilities [2].castSuccess = false;

				uiMessage.text = "";
			}
		}

		else if (Input.GetKeyDown(KeyCode.F) && abilities [3].canCast == true && abilities[3].isCasting == false && isCasting == false) {
			if (abilities [3].currentCD >= abilities[3].cooldown) {
	
				abilities [3].currentCD = 0;
				abilities [3].spellName = abilityDB.GetComponent<AbilityDatabase> ().a2_name;
				abilities [3].totalCast = abilityDB.GetComponent<AbilityDatabase> ().a2_casttime;
				abilities [3].abilityIcon = GetComponent<AbilityIconManager>()._slots [3];
				abilities [1].abilityEffect = abilityDB.GetComponent<AbilityDatabase> ().a2_effect;
				abilities [3].castBar = castGraphic;
				isCasting = true;
				abilities [3].canCast = false;
				abilities [3].isCasting = true;
				abilities [3].castSuccess = false;

				uiMessage.text = "";
			}
		}

		else if (Input.GetKeyDown(KeyCode.G) && abilities [4].canCast == true && abilities[4].isCasting == false && isCasting == false) {
			if (abilities [4].currentCD >= abilities[4].cooldown) {

				abilities [4].currentCD = 0;
				abilities [4].spellName = abilityDB.GetComponent<AbilityDatabase> ().a2_name;
				abilities [4].totalCast = abilityDB.GetComponent<AbilityDatabase> ().a2_casttime;
				abilities [4].abilityIcon = GetComponent<AbilityIconManager>()._slots [4];
				abilities [4].abilityEffect = abilityDB.GetComponent<AbilityDatabase> ().a2_effect;
				abilities [4].castBar = castGraphic;
				isCasting = true;
				abilities [4].canCast = false;
				abilities [4].isCasting = true;
				abilities [4].castSuccess = false;

				uiMessage.text = "";

			}
		}

		else if (Input.GetKeyDown(KeyCode.Alpha1) && abilities [5].canCast == true && abilities[5].isCasting == false && isCasting == false) {
			if (abilities [5].currentCD >= abilities[5].cooldown) {
				
				abilities [5].currentCD = 0;
				abilities [5].spellName = abilityDB.GetComponent<AbilityDatabase> ().a2_name;
				abilities [5].totalCast = abilityDB.GetComponent<AbilityDatabase> ().a2_casttime;
				abilities [5].abilityIcon = GetComponent<AbilityIconManager>()._slots [5];
				abilities [5].abilityEffect = abilityDB.GetComponent<AbilityDatabase> ().a2_effect;
				abilities [5].castBar = castGraphic;
				isCasting = true;
				abilities [5].canCast = false;
				abilities [5].isCasting = true;
				abilities [5].castSuccess = false;

				uiMessage.text = "";
			}
		}

		else if (Input.GetKeyDown(KeyCode.Alpha2) && abilities [6].canCast == true && abilities[6].isCasting == false && isCasting == false) {
			if (abilities [6].currentCD >= abilities[6].cooldown) {
				
				abilities [6].currentCD = 0;
				abilities [6].spellName = abilityDB.GetComponent<AbilityDatabase> ().a2_name;
				abilities [6].totalCast = abilityDB.GetComponent<AbilityDatabase> ().a2_casttime;
				abilities [6].abilityIcon = GetComponent<AbilityIconManager>()._slots [6];
				abilities [6].abilityEffect = abilityDB.GetComponent<AbilityDatabase> ().a2_effect;
				abilities [6].castBar = castGraphic;
				isCasting = true;
				abilities [6].canCast = false;
				abilities [6].isCasting = true;
				abilities [6].castSuccess = false;

				uiMessage.text = "";
			}
		}

		else if (Input.GetKeyDown(KeyCode.Alpha3) && abilities [7].canCast == true && abilities[7].isCasting == false && isCasting == false) {
			if (abilities [7].currentCD >= abilities[7].cooldown) {
				
				abilities [7].currentCD = 0;
				abilities [7].spellName = abilityDB.GetComponent<AbilityDatabase> ().a2_name;
				abilities [7].totalCast = abilityDB.GetComponent<AbilityDatabase> ().a2_casttime;
				abilities [7].abilityIcon = GetComponent<AbilityIconManager>()._slots [7];
				abilities [7].abilityEffect = abilityDB.GetComponent<AbilityDatabase> ().a2_effect;
				abilities [7].castBar = castGraphic;
				isCasting = true;
				abilities [7].canCast = false;
				abilities [7].isCasting = true;
				abilities [7].castSuccess = false;

				uiMessage.text = "";
			}
		}

		else if (Input.GetKeyDown(KeyCode.Alpha4)&& abilities [8].canCast == true && abilities[8].isCasting == false && isCasting == false) {
			if (abilities [8].currentCD >= abilities[8].cooldown) {
				
				abilities [8].currentCD = 0;
				abilities [8].spellName = abilityDB.GetComponent<AbilityDatabase> ().a2_name;
				abilities [8].totalCast = abilityDB.GetComponent<AbilityDatabase> ().a2_casttime;
				abilities [8].abilityIcon = GetComponent<AbilityIconManager>()._slots [8];
				abilities [8].abilityEffect = abilityDB.GetComponent<AbilityDatabase> ().a2_effect;
				abilities [8].castBar = castGraphic;
				isCasting = true;
				abilities [8].canCast = false;
				abilities [8].isCasting = true;
				abilities [8].castSuccess = false;

				uiMessage.text = "";
			}
		}

		else if (Input.GetKeyDown(KeyCode.Alpha5 ) && abilities [9].canCast == true && abilities[9].isCasting == false && isCasting == false) {
			if (abilities [9].currentCD >= abilities[9].cooldown) {
				
				abilities [9].currentCD = 0;
				abilities [9].spellName = abilityDB.GetComponent<AbilityDatabase> ().a2_name;
				abilities [9].totalCast = abilityDB.GetComponent<AbilityDatabase> ().a2_casttime;
				abilities [9].abilityIcon = GetComponent<AbilityIconManager>()._slots [9];
				abilities [9].abilityEffect = abilityDB.GetComponent<AbilityDatabase> ().a2_effect;
				abilities [9].castBar = castGraphic;
				isCasting = true;
				abilities [9].canCast = false;
				abilities [9].isCasting = true;
				abilities [9].castSuccess = false;

				uiMessage.text = "";
			}
		}
			
	}

	void Update () {
		foreach (Ability a in abilities) {
			if (a.currentCD < a.cooldown && a.abilityIcon != null) {
				if (a.currentCD != null) {
					a.currentCD += Time.deltaTime;
					a.abilityIcon.fillAmount = a.currentCD / a.cooldown;
					a.canCast = true;
				}
			}
		}
			
		if (networkPlayer.GetComponent<PlayerMovement> ().isMoving == false) {			
			foreach (Ability a in abilities) {

				if (a.canCast) {
					if (a.isCasting == true) {
						if (a.currentCast < a.totalCast) {
							a.currentCast += Time.deltaTime;
							a.castBar.fillAmount = a.currentCast / a.totalCast;
							castTimer.text = "Casting " + a.spellName + "  " + (Mathf.Round(a.currentCast)) + " / " + a.totalCast;
							uiCastBar.gameObject.SetActive (true);
							Debug.Log ("The cast is " + a.currentCast + "Out of" + a.totalCast);

							if (networkPlayer.GetComponent<PlayerMovement> ().isMoving == true) {
								a.currentCast = a.currentCast - a.currentCast;
								a.canCast = true;
								a.castSuccess = false;
								isCasting = false;
							}

						} 

						if (a.currentCast > a.totalCast && networkPlayer.GetComponent<TargetSystem> ().selectedTarget != null) {
							a.isCasting = false;
							a.currentCast = 0;
							a.castBar.fillAmount = 0;
							castTimer.text = a.currentCast + "";
							CmdCast (a.abilityEffect);
						}

						if (a.currentCast > a.totalCast && networkPlayer.GetComponent<TargetSystem> ().selectedTarget == null) {
							a.isCasting = false;
							a.currentCast = 0;
							isCasting = false;
							a.castBar.fillAmount = 0;
							castTimer.text = a.currentCast + "";
							uiMessage.text = "You need a target.";
						}
								
					} 
				}
			}
				
		}
	}

	[Command]
	void CmdCast (GameObject newEffect) {
		isCasting = false;
		uiCastBar.gameObject.SetActive (false);
		castTimer.text = "";

		GameObject effect = (GameObject) Instantiate (newEffect, castPoint.transform.position, castPoint.transform.rotation);
		NetworkServer.Spawn (effect);

	}
		
}
	


[System.Serializable]
public class Ability
{
	public float cooldown;
	public Image abilityIcon;
	public float currentCD;

	public float currentCast;
	public float totalCast = 10;
	public Image castBar;

	public GameObject abilityEffect;

	public bool castSuccess = false;
	public bool isCasting = false;

	public bool canCast = false;

	public int spellID = 0;
	public string spellName = "";

}

