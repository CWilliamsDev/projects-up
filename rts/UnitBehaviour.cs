using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitBehaviour : MonoBehaviour {
	public GameObject[] _models;

	public string[] _unitName;

	public void SpawnUnit (string name, int health, float range, int damage, int cost) {
		Unit newUnit = new Unit(name, health, range, damage, cost);
	}
}

class Unit {

	// Unit Statistics and Variables
	public string Name;
	public int Health;
	public float Range;
	public int Damage;
	public int Cost;
	public Unit (string name, int health, float range, int damage, int cost) {
		Name = name;
		Health = health;
		Range = range;
		Damage = damage;
		Cost = cost;
	}
}
