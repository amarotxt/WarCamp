using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : MonoBehaviour {
	int points;
	public float timeBetweenAttacks;
	float timer;
	float distanceToPlayer;
	CommandsEnemies warrior;
	GameObject player;
	Player playerstatus;
	GameObject drop;
	// Use this for initialization
	void Start () {
		points = 10;
		player = GameObject.FindGameObjectWithTag ("Player");
		drop = (GameObject)Resources.Load ("Prefabs/Drops/DropLife", typeof(GameObject));
		playerstatus = player.GetComponent<Player> ();
		// speedMoves,health, damege, range, armor, player;
		warrior =new WarriorCommands(15,50+(playerstatus.fullHealth*0.1f),7+(playerstatus.damege*0.1f),5,5+(playerstatus.armor*0.1f),player.GetComponent<Player>());
		timeBetweenAttacks = 2;
	}

	void FixedUpdate (	) {
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
			
			warrior.TakeDamege (player.GetComponent<Player> ().damege);
			Destroy (col.gameObject);
			if (warrior.health <= 0) {
				player.GetComponent<Player>().IncreasePoints(points);
				if (Random.Range(0,100) < 10)
					Instantiate (drop, gameObject.transform.position, Quaternion.identity);
				Destroy (gameObject);
			} 

		}
	}
}
