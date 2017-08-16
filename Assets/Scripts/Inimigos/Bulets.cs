using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulets : MonoBehaviour {

	float range;
	float distanceToPlayer;

	CommandsEnemies bulets;
	GameObject player;
	Vector3 randomDirectionBulets;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		range = 4f;
		bulets =new BuletsCommands(40,1,7,range,5,player.GetComponent<Player>());
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
