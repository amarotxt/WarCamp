using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cart : MonoBehaviour {
	int points;
	public float speedMoves;
	public float damege;
	public float range;
	public float armor;
	public float health;

	public float timeBetweenAttacks;
	float timer;
	float distanceToPlayer;
	CommandsEnemies cart;
	GameObject player;
	Player playerstatus;
	GameObject drop;

	ControllerEnemyHealthBar healthBar;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		drop = (GameObject)Resources.Load ("Prefabs/Drops/DropLife", typeof(GameObject));
		playerstatus = player.GetComponent<Player> ();
		// speedMoves,health, damege, range, armor, player;
		cart =new WarriorCommands(speedMoves,health+(playerstatus.fullHealth*0.1f),damege+(playerstatus.damege*0.1f),range,armor+(playerstatus.armor*0.1f),player.GetComponent<Player>());
		healthBar = GetComponent<ControllerEnemyHealthBar>();
		healthBar.ChangeHealthvalue (cart.fullhealth, cart.health);
		points = 15+playerstatus.lvl;
	}

	void FixedUpdate (	) {
		timer += Time.deltaTime;
		distanceToPlayer = Vector3.Distance (new Vector3(player.transform.position.x,0),new Vector3( gameObject.transform.position.x,0));

		cart.Attack (distanceToPlayer);

		if (range >= distanceToPlayer){
			Destroy (gameObject);
			cart.health = 0;
			healthBar.ChangeHealthvalue (cart.fullhealth, cart.health);
		}
		cart.Move (gameObject.transform, distanceToPlayer);

	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.CompareTag ("arma")) {
			cart.TakeDamege (player.GetComponent<Player> ().damege, transform);
			Destroy (col.gameObject);
			healthBar.ChangeHealthvalue (cart.fullhealth, cart.health);
			if (cart.health <= 0) {
				player.GetComponent<Player>().IncreasePoints(points);
				if (Random.Range(0,100) < 10)
					Instantiate (drop, gameObject.transform.position, Quaternion.identity);
				Destroy (gameObject);
			} 

		}
	}
}
