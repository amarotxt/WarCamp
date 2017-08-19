using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulets : MonoBehaviour {

	float range;
	float distanceToPlayer;

	public float speedMoves;
	public float damege;
	public float armor;
	public float health;

	CommandsEnemies bulets;
	GameObject player;
	Vector3 randomDirectionBulets;

	Player playerstatus;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		range = 4f;
		playerstatus = player.GetComponent<Player> ();

		// speedMoves,health, damege, range, armor, player;
		bulets =new BuletsCommands(speedMoves+(int)Mathf.Log(playerstatus.lvl),1,damege+(playerstatus.armor*0.4f),range,0,player.GetComponent<Player>());
		randomDirectionBulets = player.transform.position;
		randomDirectionBulets.z = Random.Range (20f,-20f);
		gameObject.transform.LookAt (randomDirectionBulets);
	}

	void Update () {
		distanceToPlayer = Vector3.Distance (new Vector3(player.transform.position.x,0),new Vector3( gameObject.transform.position.x,0));
		bulets.Move (gameObject.transform, distanceToPlayer);
		if (distanceToPlayer < range) {
			bulets.Attack (distanceToPlayer);
			Destroy (gameObject);
		}
	}

}
