using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
	public float health;
	public float fullHealth;

	public float damege;
	public float armor;
	public int arm;
	float timer;
	public float timeBetweenAttacks;

	public Slider healthBar;

	GameObject weapon;

	Vector3 mausePosition;
	Vector3 lookMausePosition;

	public int lvl;
	int changelvl;
	int points;
	int totalpoints;

	void Start () {
		lvl = 0;
		arm = 1;
		weapon = (GameObject)Resources.Load("Prefabs/Armas/Arma"+arm, typeof(GameObject));
		timeBetweenAttacks = 1+(weapon.GetComponent<Weapon> ().timeBetweenAttacksWeapon);

		damege = 20 + weapon.GetComponent<Weapon> ().damageWeapon;
		health = 15+(weapon.GetComponent<Weapon> ().healthWeapon);
		fullHealth = health;
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
		Debug.Log (health);
		healthBar.value = CauculateHealthBar();
		if (points >= changelvl){
			lvl += 1;
			points = 0;
			changelvl += totalpoints/10;
		}
	}

	public float CauculateHealthBar(){
		return (health / fullHealth);
	}
		
	public void TakeDamage(float damage){
		if (health > 0){
			health -= (Random.Range(damage/2f, damage)-Random.Range(armor/2f, armor));
		}
	}

	public void Attack(){
		mausePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		mausePosition.y = gameObject.transform.position.y;
		GameObject clone = Instantiate (weapon, gameObject.transform.position,Quaternion.identity);
		clone.transform.LookAt (mausePosition);
	}

	public void IncreaseHealth(){
		health += 10;
		fullHealth += 10;
	}
	public void IncreaseArmor(){
		armor += 5;
		}
	public void IncreaseStrength(){
		damege += 5;
	}
	public void IncreaseAttackSpeed(){
		if (timeBetweenAttacks > 0.1f){
		timeBetweenAttacks = timeBetweenAttacks - 0.1f;
		}
	}
	public void IncreasePoints(int points){
		this.points += points;
		totalpoints += points;
	}
}
