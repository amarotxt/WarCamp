using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : MonoBehaviour {
	int points;
	float timeBetweenAttacks;
	float timer;
	float range;
	float distanceToPlayer;
	CommandsEnemies archer;
	GameObject player;
	GameObject drop;
	public GameObject bulets;
	Player playerstatus;
	// Use this for initialization
	void Start () {
		points = 10;
		timeBetweenAttacks = Random.Range(2f, 4f);
		player = GameObject.FindGameObjectWithTag ("Player");
		range = Random.Range (40f, 70f);
		drop = (GameObject)Resources.Load ("Prefabs/Drops/DropLife", typeof(GameObject));
		playerstatus = player.GetComponent<Player> ();
		// speedMoves,health, damege, range, armor, player;
		archer =new ArcherCommands(8,10+(playerstatus.fullHealth*0.1f),15+(playerstatus.damege*0.2f),range,5+(playerstatus.armor*0.3f),player.GetComponent<Player>());
	}

	void FixedUpdate () {
		timer += Time.deltaTime;
		distanceToPlayer = Vector3.Distance (new Vector3(player.transform.position.x,0),new Vector3( gameObject.transform.position.x,0));
			// If the timer exceeds the time between attacks, the player is in range and this enemy is alive...
		if(timer >= timeBetweenAttacks && distanceToPlayer < range){
			timer = 0f;
			timeBetweenAttacks = Random.Range(3f, 4f);
			if (bulets != null){
			Instantiate (bulets, gameObject.transform.position,Quaternion.identity);
			}
		}
		archer.Move (gameObject.transform, distanceToPlayer);
	}
	void OnTriggerEnter(Collider col){

		if (col.gameObject.CompareTag ("arma")) {
			archer.TakeDamege (player.GetComponent<Player> ().damege);
			Destroy (col.gameObject);
			if (archer.health <= 0) {
				player.GetComponent<Player>().IncreasePoints(points);
				if (Random.Range(0,100) < 10)
					Instantiate (drop, gameObject.transform.position, Quaternion.identity);
				
				Destroy (gameObject);
			}
			} 

	}
}

