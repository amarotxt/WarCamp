using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : MonoBehaviour {
	
	float timeBetweenAttacks = 2f;
	float timer;
	float distanceToPlayer;
	Enimy warrior;
	EnimyHealth enimyHealth;
	GameObject player;
	// Use this for initialization
	void Start () {
		enimyHealth = GetComponent<EnimyHealth> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		warrior =new WarriorCommands(10,enimyHealth,10,7,5,5,player.GetComponent<Player>());
	}

	void Update () {
		timer += Time.deltaTime;
		distanceToPlayer = Vector3.Distance (new Vector3(player.transform.position.x,0),new Vector3( gameObject.transform.position.x,0));

		// If the timer exceeds the time between attacks, the player is in range and this enemy is alive...
		if(timer >= timeBetweenAttacks){
			warrior.Attack (distanceToPlayer);
			timer = 0f;
		}
		warrior.Move (gameObject.transform, distanceToPlayer);
	}
	void OnTriggerEnter(Collider col){

		if (col.gameObject.CompareTag ("arma")) {
			warrior.TakeDamege (player.GetComponent<Player>().damege);
			Destroy (col.gameObject);
		}
	}
}
