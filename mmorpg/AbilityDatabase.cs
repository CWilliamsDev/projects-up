using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine.UI;

[System.Serializable]
public class AbilityDatabase : NetworkBehaviour {

	public GameObject characterManager;

	public Sprite[] _abilityIcon;
	public GameObject[] _abilityEffects;

	// CLASS DETAILS
	public bool fireMage = false;
	public bool frostMage = false;

	// ABILITY 1 DETAILS
	public float a1_cooldown;
	public float a1_casttime;
	public float a1_damage;
	public int a1_manacost;

	public string a1_name = "";
	public GameObject a1_effect;
	public Sprite a1_image;

	// ABILITY 2 DETAILS
	public float a2_cooldown;
	public float a2_casttime;
	public float a2_damage;
	public int a2_manacost;
	public string a2_name = "";
	public GameObject a2_effect;
	public Sprite a2_image;

	// ABILITY 3 DETAILS
	public float a3_cooldown;
	public float a3_casttime;
	public float a3_damage;
	public int a3_manacost;
	public string a3_name = "";
	public GameObject a3_effect;
	public Sprite a3_image;

	// ABILITY 4 DETAILS
	public float a4_cooldown;
	public float a4_casttime;
	public float a4_damage;
	public int a4_manacost;
	public string a4_name = "";
	public GameObject a4_effect;
	public Sprite a4_image;

	// ABILITY 5 DETAILS
	public float a5_cooldown;
	public float a5_casttime;
	public float a5_damage;
	public int a5_manacost;
	public string a5_name = "";
	public GameObject a5_effect;
	public Sprite a5_image;

	// ABILITY 6 DETAILS
	public float a6_cooldown;
	public float a6_casttime;
	public float a6_damage;
	public int a6_manacost;
	public string a6_name = "";
	public GameObject a6_effect;
	public Sprite a6_image;

	// ABILITY 7 DETAILS
	public float a7_cooldown;
	public float a7_casttime;
	public float a7_damage;
	public int a7_manacost;
	public string a7_name = "";
	public GameObject a7_effect;
	public Sprite a7_image;

	// ABILITY 8 DETAILS
	public float a8_cooldown;
	public float a8_casttime;
	public float a8_damage;
	public int a8_manacost;
	public string a8_name = "";
	public GameObject a8_effect;
	public Sprite a8_image;

	// ABILITY 9 DETAILS
	public float a9_cooldown;
	public float a9_casttime;
	public float a9_damage;
	public int a9_manacost;
	public string a9_name = "";
	public GameObject a9_effect;
	public Sprite a9_image;

	// ABILITY 10 DETAILS
	public float a10_cooldown;
	public float a10_casttime;
	public float a10_damage;
	public int a10_manacost;
	public string a10_name = "";
	public GameObject a10_effect;
	public Sprite a10_image;

	public CastableAbility castableAbility;

	public string abilitySet;

	void Update () {
		if (characterManager.GetComponent<CharacterManager> ().character == "frost_mage") {
			frostMage = true;
		}

		if (characterManager.GetComponent<CharacterManager> ().character == "fire_mage") {
			fireMage = true;
		}

		abilitySlot1 ();
		abilitySlot2 ();

	}

	// COOLDOWN / CASTTIME / NAME / DAMAGE / MANACOST / EFFECT
	void abilitySlot1 () {
		if (frostMage) {
			CastableAbility a1 = new CastableAbility (1, 1, "Frost Ability 1", 1, 20, _abilityEffects [0]);
			a1_cooldown = a1.getCooldown ();
			a1_casttime = a1.getCastTime ();
			a1_damage = a1.getDamage ();
			a1_manacost = a1.getManaCost ();
			a1_name = a1.getAbilityName ();
			a1_effect = a1.getEffect ();
		} else if (fireMage){
			CastableAbility a1 = new CastableAbility (1, 2, "Fire Ability 1", 1, 20, _abilityEffects[2]);
			a1_cooldown = a1.getCooldown();
			a1_casttime = a1.getCastTime();
			a1_damage = a1.getDamage();
			a1_manacost = a1.getManaCost();
			a1_name = a1.getAbilityName ();
			a1_effect = a1.getEffect ();
		}

	}

	void abilitySlot2 () {
		if (frostMage) {
			CastableAbility a2 = new CastableAbility (1, 2, "Arctic Shard", 500, 20, _abilityEffects[1]);
			a2_cooldown = a2.getCooldown();
			a2_casttime = a2.getCastTime();
			a2_damage = a2.getDamage();
			a2_manacost = a2.getManaCost();
			a2_name = a2.getAbilityName ();
			a2_effect = a2.getEffect ();
		} else if (fireMage){
			CastableAbility a2 = new CastableAbility (1, 1, "Fire Ability 2", 1, 20, _abilityEffects[3]);
			a2_cooldown = a2.getCooldown();
			a2_casttime = a2.getCastTime();
			a2_damage = a2.getDamage();
			a2_manacost = a2.getManaCost();
			a2_name = a2.getAbilityName ();
			a2_effect = a2.getEffect ();
		}
	}

	void abilitySlot3 () {
		if (frostMage) {
			CastableAbility a3 = new CastableAbility (1, 6, "Arctic Shard", 500, 20, _abilityEffects[1]);
			a3_cooldown = a3.getCooldown();
			a3_casttime = a3.getCastTime();
			a3_damage = a3.getDamage();
			a3_manacost = a3.getManaCost();
			a3_name = a3.getAbilityName ();
			a3_effect = a3.getEffect ();
		} else if (fireMage){
			CastableAbility a3 = new CastableAbility (1, 1, "Fire Ability 2", 1, 20, _abilityEffects[3]);
			a3_cooldown = a3.getCooldown();
			a3_casttime = a3.getCastTime();
			a3_damage = a3.getDamage();
			a3_manacost = a3.getManaCost();
			a3_name = a3.getAbilityName ();
			a3_effect = a3.getEffect ();
		}
	}

	void abilitySlot4 () {
		if (frostMage) {
			CastableAbility a4 = new CastableAbility (1, 6, "Arctic Shard", 500, 20, _abilityEffects[1]);
			a4_cooldown = a4.getCooldown();
			a4_casttime = a4.getCastTime();
			a4_damage = a4.getDamage();
			a4_manacost = a4.getManaCost();
			a4_name = a4.getAbilityName ();
			a4_effect = a4.getEffect ();
		} else if (fireMage){
			CastableAbility a3 = new CastableAbility (1, 1, "Fire Ability 2", 1, 20, _abilityEffects[3]);
			a3_cooldown = a3.getCooldown();
			a3_casttime = a3.getCastTime();
			a3_damage = a3.getDamage();
			a3_manacost = a3.getManaCost();
			a3_name = a3.getAbilityName ();
			a3_effect = a3.getEffect ();
		}
	}

	void abilitySlot5 () {
		if (frostMage) {
			CastableAbility a5 = new CastableAbility (1, 6, "Arctic Shard", 500, 20, _abilityEffects[1]);
			a5_cooldown = a5.getCooldown();
			a5_casttime = a5.getCastTime();
			a5_damage = a5.getDamage();
			a5_manacost = a5.getManaCost();
			a5_name = a5.getAbilityName ();
			a5_effect = a5.getEffect ();
		} else if (fireMage){
			CastableAbility a5 = new CastableAbility (1, 1, "Fire Ability 2", 1, 20, _abilityEffects[3]);
			a5_cooldown = a5.getCooldown();
			a5_casttime = a5.getCastTime();
			a5_damage = a5.getDamage();
			a5_manacost = a5.getManaCost();
			a5_name = a5.getAbilityName ();
			a5_effect = a5.getEffect ();
		}
	}

	void abilitySlot6 () {
		if (frostMage) {
			CastableAbility a6 = new CastableAbility (1, 6, "Arctic Shard", 500, 20, _abilityEffects[1]);
			a6_cooldown = a6.getCooldown();
			a6_casttime = a6.getCastTime();
			a6_damage = a6.getDamage();
			a6_manacost = a6.getManaCost();
			a6_name = a6.getAbilityName ();
			a6_effect = a6.getEffect ();
		} else if (fireMage){
			CastableAbility a6 = new CastableAbility (1, 1, "Fire Ability 2", 1, 20, _abilityEffects[3]);
			a6_cooldown = a6.getCooldown();
			a6_casttime = a6.getCastTime();
			a6_damage = a6.getDamage();
			a6_manacost = a6.getManaCost();
			a6_name = a6.getAbilityName ();
			a6_effect = a6.getEffect ();
		}
	}

	void abilitySlot7 () {
		if (frostMage) {
			CastableAbility a7 = new CastableAbility (1, 6, "Arctic Shard", 500, 20, _abilityEffects[1]);
			a7_cooldown = a7.getCooldown();
			a7_casttime = a7.getCastTime();
			a7_damage = a7.getDamage();
			a7_manacost = a7.getManaCost();
			a7_name = a7.getAbilityName ();
			a7_effect = a7.getEffect ();
		} else if (fireMage){
			CastableAbility a7 = new CastableAbility (1, 1, "Fire Ability 2", 1, 20, _abilityEffects[3]);
			a7_cooldown = a7.getCooldown();
			a7_casttime = a7.getCastTime();
			a7_damage = a7.getDamage();
			a7_manacost = a7.getManaCost();
			a7_name = a7.getAbilityName ();
			a7_effect = a7.getEffect ();
		}
	}

	void abilitySlot8 () {
		if (frostMage) {
			CastableAbility a8 = new CastableAbility (1, 6, "Arctic Shard", 500, 20, _abilityEffects[1]);
			a8_cooldown = a8.getCooldown();
			a8_casttime = a8.getCastTime();
			a8_damage = a8.getDamage();
			a8_manacost = a8.getManaCost();
			a8_name = a8.getAbilityName ();
			a8_effect = a8.getEffect ();
		} else if (fireMage){
			CastableAbility a8 = new CastableAbility (1, 1, "Fire Ability 2", 1, 20, _abilityEffects[3]);
			a8_cooldown = a8.getCooldown();
			a8_casttime = a8.getCastTime();
			a8_damage = a8.getDamage();
			a8_manacost = a8.getManaCost();
			a8_name = a8.getAbilityName ();
			a8_effect = a8.getEffect ();
		}
	}

	void abilitySlot9 () {
		if (frostMage) {
			CastableAbility a9 = new CastableAbility (1, 6, "Arctic Shard", 500, 20, _abilityEffects[1]);
			a9_cooldown = a9.getCooldown();
			a9_casttime = a9.getCastTime();
			a9_damage = a9.getDamage();
			a9_manacost = a9.getManaCost();
			a9_name = a9.getAbilityName ();
			a9_effect = a9.getEffect ();
		} else if (fireMage){
			CastableAbility a9 = new CastableAbility (1, 1, "Fire Ability 2", 1, 20, _abilityEffects[3]);
			a9_cooldown = a9.getCooldown();
			a9_casttime = a9.getCastTime();
			a9_damage = a9.getDamage();
			a9_manacost = a9.getManaCost();
			a9_name = a9.getAbilityName ();
			a9_effect = a9.getEffect ();
		}
	}

	void abilitySlot10 () {
		if (frostMage) {
			CastableAbility a10 = new CastableAbility (1, 6, "Arctic Shard", 500, 20, _abilityEffects[1]);
			a10_cooldown = a10.getCooldown();
			a10_casttime = a10.getCastTime();
			a10_damage = a10.getDamage();
			a10_manacost = a10.getManaCost();
			a10_name = a10.getAbilityName ();
			a10_effect = a10.getEffect ();
		} else if (fireMage){
			CastableAbility a10 = new CastableAbility (1, 1, "Fire Ability 2", 1, 20, _abilityEffects[3]);
			a10_cooldown = a10.getCooldown();
			a10_casttime = a10.getCastTime();
			a10_damage = a10.getDamage();
			a10_manacost = a10.getManaCost();
			a10_name = a10.getAbilityName ();
			a10_effect = a10.getEffect ();
		}
	}
}
	
