#pragma strict

var player1 : GameObject;
var player2 : GameObject;

var spawn1 : Transform;
var spawn2 : Transform;

var playersAlive = false;

function Start () {
	Spawn();
}

function Update () {

}

function Spawn () {
	if (!playersAlive) {
		var p1 : GameObject;
		var p2 : GameObject;
		p1 = Instantiate(player1, spawn1.transform.position, spawn1.transform.rotation);
		p2 = Instantiate(player2, spawn2.transform.position, spawn2.transform.rotation);
		playersAlive = true;
	}
}
