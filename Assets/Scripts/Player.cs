using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public float health;
	public float damege;
	public float armor;

	void Start () {
		health = 15;
		damege = 20;
		armor = 1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void TakeDamage(float damage){
		if (health > 0){
			health = health -(Random.Range(damage/2f, damage)-Random.Range(armor/2f, armor));
			Debug.Log ("vidaPlayer:"+health);
		}
	}
}
