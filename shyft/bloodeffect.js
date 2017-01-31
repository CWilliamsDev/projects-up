#pragma strict

var gib = this;
var blood : GameObject;
var hasLanded = false;
var worldSpace : Transform;

function Awake () {
	gib.GetComponent.<Rigidbody>().AddForce(transform.forward * 50);
}

function OnCollisionEnter (col:Collision) {
	if(col.gameObject.tag == "Floor" && !hasLanded){
		var spawnBlood : GameObject;
		spawnBlood = Instantiate(blood, transform.position, worldSpace.transform.rotation);
	}
}
