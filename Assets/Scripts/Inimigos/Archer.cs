using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : MonoBehaviour {
	int points;
	float timeBetweenAttacks;
	float timer;
	float range;
	float distanceToPlayer;

	public float speedMoves;
	public float damege;
	public float armor;
	public float health;

	CommandsEnemies archer;
	GameObject player;
	GameObject drop;
	public GameObject bulets;
	Player playerstatus;

	ControllerEnemyHealthBar healthBar;

	// Use this for initialization
	void Start () {
		timeBetweenAttacks = Random.Range(2f, 4f);
		player = GameObject.FindGameObjectWithTag ("Player");
		range = Random.Range (40f, 70f);
		drop = (GameObject)Resources.Load ("Prefabs/Drops/DropLife", typeof(GameObject));
		playerstatus = player.GetComponent<Player> ();
		// speedMoves,health, damege, range, armor, player;
		archer =new ArcherCommands(speedMoves,health+(playerstatus.fullHealth*0.1f),damege+(playerstatus.armor*0.2f),range,armor+(playerstatus.damege*0.1f),player.GetComponent<Player>());
		healthBar = GetComponent<ControllerEnemyHealthBar>();
		healthBar.ChangeHealthvalue (archer.fullhealth, archer.health);
		points = 10+playerstatus.lvl;
	}

	void FixedUpdate () {
		timer += Time.deltaTime;
		distanceToPlayer = Vector3.Distance (new Vector3(player.transform.position.x,0),new Vector3( gameObject.transform.position.x,0));
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
			archer.TakeDamege (player.GetComponent<Player> ().damege,transform);
			Destroy (col.gameObject);
			healthBar.ChangeHealthvalue (archer.fullhealth,archer.health);

			if (archer.health <= 0) {
				player.GetComponent<Player>().IncreasePoints(points);
				if (Random.Range(0,100) < 10)
					Instantiate (drop, gameObject.transform.position, Quaternion.identity);
				
				Destroy (gameObject);
			}
			} 

	}
}

