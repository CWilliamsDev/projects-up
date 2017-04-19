using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine.UI;

[System.Serializable]
public class CastableAbility {

	private float cooldown;
	private float castTime;
	private int manaCost;
	private string abilityName;
	private float damage;
	private GameObject effect;

	public CastableAbility (float cooldown, float castTime, string abilityName, float damage, int manaCost, GameObject effect) {
		this.cooldown = cooldown;
		this.castTime = castTime;
		this.abilityName = abilityName;
		this.damage = damage;
		this.manaCost = manaCost;
		this.effect = effect;
	}

	// GET AND SET COOLDOWN
	public float getCooldown () {
		return this.cooldown;
	}

	public void setCooldown (float cd) {
		cooldown = cd;
	}

	// GET AND SET CASTTIME
	public float getCastTime () {
		return this.castTime;
	}

	public void setCastTime (float ct) {
		castTime = ct;
	}

	// GET AND SET ABILITYNAME
	public string getAbilityName () {
		return this.abilityName;
	}

	public void setAbilityName (string ab) {
		abilityName = ab;
	}

	// GET AND SET DAMAGE
	public float getDamage () {
		return this.damage;
	}

	public void setDamage (float dmg) {
		damage = dmg;
	}

	public int getManaCost () {
		return this.manaCost;
	}

	public void setManaCost (int mc) {
		manaCost = mc;
	}

	public GameObject getEffect () {
		return this.effect;
	}

	public void setEffect (GameObject ef) {
		effect = ef;
	}

}
