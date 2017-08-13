using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : MonoBehaviour {

	float timeBetweenAttacks;
	float timer;
	float range;
	float distanceToPlayer;
	Enimy archer;
	EnimyHealth enimyHealth;
	GameObject player;
	public GameObject bulets;
	// Use this for initialization
	void Start () {
		timeBetweenAttacks = Random.Range(2f, 4f);
		enimyHealth = GetComponent<EnimyHealth> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		range = Random.Range (40f, 70f);
		archer =new ArcherCommands(10,enimyHealth,20,7,range,5,player.GetComponent<Player>());
	}

	void Update () {
		timer += Time.deltaTime;
		distanceToPlayer = Vector3.Distance (new Vector3(player.transform.position.x,0),new Vector3( gameObject.transform.position.x,0));
			// If the timer exceeds the time between attacks, the player is in range and this enemy is alive...
		if(timer >= timeBetweenAttacks && distanceToPlayer < range){
			timer = 0f;
			timeBetweenAttacks = Random.Range(3f, 4f);
			Instantiate (bulets, gameObject.transform.position,Quaternion.identity);
		}
		archer.Move (gameObject.transform, distanceToPlayer);
	}

}

