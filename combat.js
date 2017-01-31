// One of the first games I had ever written in Unity.
// Borrow whatever aspects you'd like but I highly recommend avoiding how I handled shotguns, and aiming the shells.

#pragma strict

//CLASSES
var resource : Resource;

// UI TEXT
var ammoCount : UnityEngine.UI.Text;
var slugCount : UnityEngine.UI.Text;
var currentAmmo;

// Attack controlling
var isShooting = false;
var isReloading = false;
var canSwitch = true;
var shootDelay = 0.2;
var shootDelay2 = 1.5;
var isMelee = false;
var ar = true;
var sg = false;
var weapon : int = 0;

// Resources
var ammo : int = 0;
var slugs : int = 0;

var bulletSpeed = 2000;
var isSprinting = false;
var isAiming = false;
var gunCamera : Camera;
var renderCamera : Camera;


// Animators
var uiAnim : Animator;
var recoilAnim : Animator;
var modelAnim : Animator;
var armAnim : Animator;
var gunAnim : Animator;
var aimAnim : Animator;
var legsAnim : Animator;

// Objects
var bullet : GameObject;
var bulletSpread : GameObject;
var bulletSpawn : Transform;

// ** Shotgun Related Bullet Spawners
var bulletSpawn1 : Transform;
var bulletSpawn2 : Transform;
var bulletSpawn3 : Transform;
var bulletSpawn4 : Transform;
var bulletSpawn5 : Transform;

var meleeSpawn : Transform;
var meleeHit : GameObject;

// Gun GameObjects
var assaultRifle : GameObject;
var shotgun : GameObject;

// INPUT CONTROL
var inputWalk : String = "Horizontal";
var inputForward : String = "Vertical";
var shootingInput : String = "Fire";
var meleeInput : String = "Melee";
var jumpInput : String = "";
var wSwitch : String = "";

var horizontalAim : String = "";

// Muzzle Flash 
var muzzleFlash : GameObject;
var muzzleHolder : Transform;

// Holders
var gunHolder : Transform;
var recoilHolder : Transform;

function Awake () {
	isShooting = false;
	isMelee = false;
	Application.targetFrameRate = 60;

	// Set Defaults
	ammo = resource.getAmmo();
	slugs = resource.getSlugs();

	weapon = 0; 

	assaultRifle.SetActive(true);
	shotgun.SetActive(false);
	sg = false;
}

function Update () {

	if (Input.GetAxis(shootingInput) && isShooting == false && isMelee == false && isReloading == false) {
		Fire();
	}

	if (Input.GetAxis(shootingInput) > -0.1) {
		//renderCamera.transform.position = Vector3.down * recoil * Time.deltaTime;
		recoilAnim.SetBool ("shooting", false);
		armAnim.SetBool ("shooting", false);
	}

	if (Input.GetButtonDown(meleeInput) && isMelee == false && isShooting == false) {
		gunAnim.SetTrigger ("melee");
		isMelee = true;
		canSwitch = false;
		SwitchTimer();
		var bash : GameObject;
		bash = Instantiate(meleeHit, meleeSpawn.transform.position, meleeSpawn.transform.rotation);
		bash.transform.parent = meleeSpawn;
		meleeDelay();
	}

	// Arm Based Animations
	if (Input.GetAxis(horizontalAim) <= 0) {
		aimAnim.SetBool("left", true);
		aimAnim.SetBool("right", false);
		aimAnim.SetBool("center", false);
	}

	if (Input.GetAxis(horizontalAim) >= 0) {
		aimAnim.SetBool("left", false);
		aimAnim.SetBool("right", true);
		aimAnim.SetBool("center", false);
	}

	if (Input.GetAxis(horizontalAim) == 0) {
		aimAnim.SetBool("left", false);
		aimAnim.SetBool("right", false);
		aimAnim.SetBool("center", true);
	}

	// WEAPON SWITCHING
	if (Input.GetButtonDown(wSwitch) && weapon == 0 && !isReloading && canSwitch) {
		WeaponSwitch();
		canSwitch = false;
		SwitchTimer();
		Debug.Log (weapon);
	} else 

	if (Input.GetButtonDown(wSwitch) && weapon == 1 && !isReloading && canSwitch) {
		WeaponSwitch2();
		canSwitch = false;
		SwitchTimer();
		Debug.Log (weapon);
	}

	Debug.Log(resource.getAmmo());	
	ammoCount.text = "" + ammo;
	slugCount.text = "" + slugs;

	Walking();
}


// RESOURCE MANAGEMNT
function OnTriggerEnter (other : Collider) {
	// If player touches the ASSAULT RIFLE ammo bix
	if (other.tag == "AR_AmmoBox") {
		ammo += 25;
		resource.setAmmo(ammo);
		Destroy (other.gameObject);
		Debug.Log (resource.getAmmo());
	}

	if (other.tag == "SG_AmmoBox") {
		slugs += 5;
		resource.setSlugs(slugs);
		Destroy (other.gameObject);
		Debug.Log (resource.getSlugs() + "SLUGS");
	}
}

function Walking () {

	// AIMING
	if (Input.GetButtonDown("Fire2")) {
		aimAnim.SetBool ("aiming", true);
		isAiming = true;
		uiAnim.SetBool ("aiming", true);
		aimAnim.SetBool ("aiming", true);
		gunAnim.SetBool ("slowwalk", true);
		modelAnim.SetBool ("aiming", true);
		if (gunCamera.fieldOfView < 40) {
			gunCamera.fieldOfView -= 0.1f;
			renderCamera.fieldOfView -= 0.1f;
		} else {
			gunCamera.fieldOfView = 40;
			renderCamera.fieldOfView = 40;
		}
	} else 
	if (Input.GetButtonUp("Fire2")) {
		aimAnim.SetBool("aiming", false);
		isAiming = false;
		uiAnim.SetBool ("aiming", false);
		aimAnim.SetBool ("aiming", false);
		gunAnim.SetBool ("slowwalk", false);
		modelAnim.SetBool ("aiming", false);
		yield WaitForSeconds(0.2);
		if (gunCamera.fieldOfView > 40) {
		gunCamera.fieldOfView += 0.1f;
		renderCamera.fieldOfView += 0.1f;
		} else {
			gunCamera.fieldOfView = 60f;
			renderCamera.fieldOfView = 60f;
		}
	}

	// Handling walk inputs and animations
	if (Input.GetAxis (inputWalk) || Input.GetAxis (inputForward)) {
		gunAnim.SetBool ("walking", true);
		armAnim.SetBool ("walking", true);
		legsAnim.SetBool ("walking", true);
	} else {
		gunAnim.SetBool ("walking", false);
		armAnim.SetBool ("walking", false);
		legsAnim.SetBool ("walking", false);
		isSprinting = false;
	}


}

function WeaponSwitch () {
		weapon++;
		aimAnim.SetTrigger("switch");
		assaultRifle.SetActive(false);
		ar = false;
		shotgun.SetActive(true);
		sg = true;
}

function WeaponSwitch2 () {
		weapon--;
		aimAnim.SetTrigger("switch");
		shotgun.SetActive(false);
		sg = false;
		assaultRifle.SetActive(true);
		ar = true;

}

function Fire () {

	if (weapon == 0 && resource.getAmmo() > 0 ) {
		gunAnim.SetBool ("shooting", true);
		recoilAnim.SetBool ("shooting", true);
		armAnim.SetBool ("shooting", true);
		// Bullet Spawning
		var shoot : GameObject;
		shoot = Instantiate (bullet, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
		shoot.GetComponent.<Rigidbody>().AddForce(transform.forward * bulletSpeed);

		//Muzzle Flash Spawning
		var flash : GameObject;
		flash = Instantiate (muzzleFlash, muzzleHolder.transform.position, transform.rotation);
		flash.transform.parent = recoilHolder;

		ammo--;
		resource.setAmmo(ammo);

		Debug.Log (resource.getAmmo());
		//renderCamera.transform.rotation = Quaternion(1f,1f,0f,0f);
		//gunCamera.transform.rotation = Quaternion(1f,1f,0f,0f);
		//gunHolder.transform.rotation = Quaternion(1f,1f,0f,0f);
		canSwitch = false;
		SwitchTimer();
		isShooting = true;
		ShootDelay();
	}

	if (weapon == 1 && slugs > 0) {
		// Bullet Spawning
		if (isReloading == false) {
			recoilAnim.SetBool("shotgun", true);
		}
		var shotgunShoot1 : GameObject;
		var shotgunShoot2 : GameObject;
		var shotgunShoot3 : GameObject;
		var shotgunShoot4 : GameObject;
		var shotgunShoot5 : GameObject;
		shotgunShoot1 = Instantiate (bullet, bulletSpawn1.transform.position, bulletSpawn1.transform.rotation);
		shotgunShoot2 = Instantiate (bullet, bulletSpawn2.transform.position, bulletSpawn2.transform.rotation);
		shotgunShoot3 = Instantiate (bullet, bulletSpawn3.transform.position, bulletSpawn3.transform.rotation);
		shotgunShoot4 = Instantiate (bullet, bulletSpawn4.transform.position, bulletSpawn4.transform.rotation);
		shotgunShoot5 = Instantiate (bullet, bulletSpawn5.transform.position, bulletSpawn5.transform.rotation);
		shotgunShoot1.GetComponent.<Rigidbody>().AddForce(transform.forward * bulletSpeed);
		shotgunShoot2.GetComponent.<Rigidbody>().AddForce(transform.forward * bulletSpeed);
		shotgunShoot3.GetComponent.<Rigidbody>().AddForce(transform.forward * bulletSpeed);
		shotgunShoot4.GetComponent.<Rigidbody>().AddForce(transform.forward * bulletSpeed);
		shotgunShoot5.GetComponent.<Rigidbody>().AddForce(transform.forward * bulletSpeed);

		slugs--;
		resource.setSlugs(slugs);

		//Muzzle Flash Spawning
		flash = Instantiate (muzzleFlash, muzzleHolder.transform.position, transform.rotation);
		flash.transform.parent = recoilHolder;
		//renderCamera.transform.rotation = Quaternion(1f,1f,0f,0f);
		//gunCamera.transform.rotation = Quaternion(1f,1f,0f,0f);
		//gunHolder.transform.rotation = Quaternion(1f,1f,0f,0f);

		isShooting = true;
		isReloading = true;

		canSwitch = false;
		SwitchTimer();

		ShootDelayShotgun();
	}

}

function ShootDelay () {
	yield WaitForSeconds(shootDelay);
	gunAnim.SetBool ("shooting", false);
	armAnim.SetBool ("shooting", false);
	isShooting = false;
}

function ShootDelayShotgun () {
	yield WaitForSeconds(shootDelay2);
	recoilAnim.SetBool("shotgun", false);
	isShooting = false;
	isReloading = false;
}

function SwitchTimer () {
	yield WaitForSeconds(1);
	canSwitch = true;
}

function meleeDelay () {
	yield WaitForSeconds(1.2);
	isMelee = false;
}
