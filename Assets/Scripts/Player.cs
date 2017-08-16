using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public float health;
	public float damege;
	public float armor;
	public int arm;
	float timer;
	float timeBetweenAttacks;

	GameObject weapon;

	Vector3 mausePosition;
	Vector3 lookMausePosition;

	void Start () {
		arm = 1;
		weapon = (GameObject)Resources.Load ("Prefabs/Armas/Arma"+arm, typeof(GameObject));
		timeBetweenAttacks = 1+(weapon.GetComponent<Weapon> ().timeBetweenAttacksWeapon);

		damege = 20 + weapon.GetComponent<Weapon> ().damageWeapon;
		health = 15+(weapon.GetComponent<Weapon> ().healthWeapon);
		armor = 1+(weapon.GetComponent<Weapon> ().armorWeapon);
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		timer += Time.deltaTime;
		lookMausePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		lookMausePosition.y = gameObject.transform.position.y;
		gameObject.transform.LookAt (lookMausePosition);
		if (Input.GetMouseButton(0)){
			if(timer >= timeBetweenAttacks){
				Attack ();
				timer = 0f;
			}
		}
	}
		
	public void TakeDamage(float damage){
		if (health > 0){
			health = health -(Random.Range(damage/2f, damage)-Random.Range(armor/2f, armor));
		}
	}

	public void Attack(){
		mausePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		mausePosition.y = gameObject.transform.position.y;
		GameObject clone = Instantiate (weapon, gameObject.transform.position,Quaternion.identity);
		clone.transform.LookAt (mausePosition);
	}
}
