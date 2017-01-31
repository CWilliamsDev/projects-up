var moveSpeed = 2;
var range : float = 10f;
var range2 : float = 10f;
var rotationSpeed = 2;
var stop = 0;

// Player Detections
var target : Transform;
var aiTransform : Transform;
var touchingPlayer = false;
var rb : Rigidbody;
var aggroRadius : GameObject;

// Enemy combat 
var health : int = 100;
var damage : int = 5;
var hitDamage : int = 5;
var meleeDamage : int = 40;

// Enemy Graphics
var gib : GameObject;
var blood : GameObject;
var isGrounded = false;
var enemyAnim : Animator;

function Awake () {
	// Nearest player detection
	aiTransform = transform;
	nearestPlayer = null;
	target = null;
	InvokeRepeating("findTarget", 0.05, 0.05);
	enemyAnim.SetBool ("chasing", false);
}

function Update () {
	if (!isGrounded) {
		transform.position += Vector3.down * 5 * Time.deltaTime;
	}
	if (health <= 0) {
		Death();
	}
}

function findTarget () { 
	// Distance and Quaternion Rotation math
	var distance = Mathf.Infinity;
	var position = transform.position;

	// Create an area of _player, _player is the character prefab, the enemy needs to know about all players
	var _players : GameObject[];
	_players = GameObject.FindGameObjectsWithTag("Player");

	// Finding nearest player
		for (var _player : GameObject in _players) {
			var difference = _player.transform.position - position;
			var currentDistance = difference.sqrMagnitude;

			if (currentDistance < distance) {
				nearestPlayer = _player;
				distance = currentDistance;
			  	target = nearestPlayer.transform;

			  	Debug.Log ("Nearest " + nearestPlayer);
			  	Debug.Log ("Target is " + target);

				// The enemy now has a target 
				var distance2 = Vector3.Distance(aiTransform.position, target.position);
				var dy : float = target.position.y - aiTransform.position.y;
				var dx : float = target.position.x - aiTransform.position.x;
				var angle : float = Mathf.Atan2(dy, dx);

				if (distance2<=range && distance2>stop){

					// The enemy is rotating constantly toward target
					transform.rotation = Quaternion.Slerp(transform.rotation,  Quaternion.LookRotation (target.position - transform.position), rotationSpeed * Time.deltaTime);
				
					var time = moveSpeed * Time.deltaTime;

					transform.position = Vector3.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);

					enemyAnim.SetBool ("chasing", true);
				
				}	
			}

		}	
}

// Collision Detection
function OnCollisionEnter(col:Collision){
      if(col.gameObject.tag == "Bullet"){
	      range = 200;
	      TakeDamage();
	      MultiAggro();
	      Debug.Log ("Enemy has " + health + " health left.");
      }

      if(col.gameObject.tag == "Melee"){
	      TakeMeleeDamage();
	      Debug.Log ("Enemy has " + health + " health left.");
      }

      // Checking if grounded
      if(col.gameObject.tag == "Floor"){
	      isGrounded = true;
      } else 
      {
      	isGrounded = false;
      }
}

function OnTriggerEnter (trig : Collider) {
	if (trig.gameObject.tag == "Aggro") {
		range = 200;
	}
}

function MultiAggro () {
	var aggroSphere : GameObject;
	aggroSphere = Instantiate(aggroRadius, transform.position, transform.rotation);
}

function OnCollisionExit(col:Collision){
	isGrounded = false;
}

function meleeInvulnerability () {
	yield WaitForSeconds(0.4);
	hasBeenHit = false;
}

function TakeDamage() {
	health -= hitDamage;
}

function TakeMeleeDamage () {
	meleeInvulnerability();
	yield WaitForSeconds (0.2);
	health -= meleeDamage;
}

function Death () {
	var spawnGib : GameObject;
	spawnGib = Instantiate(gib, transform.position, transform.rotation);
	gib.GetComponent.<Rigidbody>().AddForce(transform.up * 50);
	Destroy (gameObject);
}
