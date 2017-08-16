using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
	public float speedWeapon;
	public float damageWeapon;
	public float timeBetweenAttacksWeapon;
	public float armorWeapon;
	public float healthWeapon;
	GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.Translate (speedWeapon*Time.deltaTime*Vector3.forward);
		if (Vector3.Distance(gameObject.transform.position,player.transform.position) > 100){
			Destroy (gameObject);
		}
	}
}
