using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulets : MonoBehaviour {

	float timeBetweenAttacks = 2f;
	float timer;
	float range;
	float distanceToPlayer;
	Enimy bulets;
	EnimyHealth enimyHealth;
	GameObject player;
	// Use this for initialization
	void Start () {
		enimyHealth = GetComponent<EnimyHealth> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		range = 4f;
		bulets =new BuletsCommands(40,enimyHealth,20,7,range,5,player.GetComponent<Player>());
		gameObject.transform.LookAt (player.transform.position);
	}

	void Update () {
		timer += Time.deltaTime;
		distanceToPlayer = Vector3.Distance (new Vector3(player.transform.position.x,0),new Vector3( gameObject.transform.position.x,0));
		bulets.Move (gameObject.transform, distanceToPlayer);
		if (distanceToPlayer < range) {
			bulets.Attack (distanceToPlayer);
			Destroy (gameObject);
		}
	}

}
