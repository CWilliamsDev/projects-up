#pragma strict

var resource : Resource;
var currentHealth : int;

var healthTxt : UnityEngine.UI.Text;

var playerKilling = true;
var hasBeenHit = false;
var bulletDamage = 10;
var meleeDamage = 40;
var enemyDamage = 10;

// Player Spawning
var player : GameObject;
var spawnPoint : Transform;

// Player Effects
var gib : GameObject;
var blood : GameObject;
var hit_anim : Animator;

function Awake () {
	hasBeenHit = false;
	currentHealth = resource.getHealth();
}

function Update () {
	if (resource.getHealth() <= 0) {
		Respawn ();
		Death ();
	}

	healthTxt.text = "" + currentHealth;
}

function OnCollisionEnter(col:Collision){
      	if(col.gameObject.tag == "Bullet" && playerKilling == true){
      		Debug.Log ("You hit a player");
      		TakeDamage();
      	}

      	if(col.gameObject.tag == "Melee" && playerKilling == true && hasBeenHit == false){
      		Debug.Log ("You hit a player");
      		hasBeenHit = true;
      		TakeMeleeDamage();
      	}

      	if(col.gameObject.tag == "Enemy" && hasBeenHit == false){
      		Debug.Log ("You hit a player");
      		hasBeenHit = true;
      		TakeEnemyDamage();
      	}

}

function TakeDamage () {

	currentHealth -= bulletDamage;
	resource.setHealth(currentHealth);
	hit_anim.SetTrigger ("hit");
	Debug.Log ("Player health is " + currentHealth);
}

function TakeMeleeDamage () {
	meleeInvulnerability();
	yield WaitForSeconds (0.2);
	currentHealth -= meleeDamage;
	resource.setHealth(currentHealth);
	hit_anim.SetTrigger ("hit");
	Debug.Log ("Player health is " + currentHealth);
}

function TakeEnemyDamage () {
	meleeInvulnerability();
	yield WaitForSeconds (0.2);
	currentHealth -= enemyDamage;
	resource.setHealth(currentHealth);
	hit_anim.SetTrigger ("hit");
	Debug.Log ("Player health is " + currentHealth);
}

function meleeInvulnerability () {
	yield WaitForSeconds(0.4);
	hasBeenHit = false;
}

function Respawn () {
		currentHealth = 100;
		resource.setHealth(currentHealth);
		var newLife : GameObject;
		newLife = Instantiate(this.player, spawnPoint.transform.position, transform.rotation);
}

function Death () {
	var spawnGib : GameObject;
	spawnGib = Instantiate(gib, transform.position, transform.rotation);
	gib.GetComponent.<Rigidbody>().AddForce(transform.up * 50);
	Destroy (gameObject);
}
