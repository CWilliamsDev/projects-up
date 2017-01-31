#pragma strict

// Class for handling resources and character vitals. This is used in UI, gameplay, enemy behaviours, etc.

public class Resource {

	var ammo : int = 200;
	var slugs : int = 40;
	var health : int = 100;

	function setAmmo (value) {
		ammo = value;
	}

	function setSlugs (value) {
		slugs = value;
	}

	function setHealth (value) {
		health = value;
	}

	function getAmmo () {
		return ammo;
	}

	function getSlugs () {
		return slugs;
	}

	function getHealth () {
		return health;
	}

}
