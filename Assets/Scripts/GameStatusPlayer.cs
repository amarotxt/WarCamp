using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStatusPlayer : MonoBehaviour {
	Player player;
	int lvlUp;
	int extraPoints;
	public Text extraPointsText;
	public Text healthTotalText;
	public Text damageText;
	public Text armorText;
	public Text attackSpeedText;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player>();
	}
	void FixedUpdate(){
		extraPointsText.text = extraPoints.ToString();
		healthTotalText.text = player.fullHealth.ToString();
		damageText.text = player.damege.ToString();
		armorText.text = player.armor.ToString();
		attackSpeedText.text = player.timeBetweenAttacks.ToString();

		if (player.lvl > lvlUp){
			extraPoints += 5;
			lvlUp = player.lvl;
		}
	}
	public void IncreaseHealth(){
		if (extraPoints != 0){
		player.IncreaseHealth ();
		extraPoints -= 1;
		}
	}
	public void IncreaseArmor(){
		if (extraPoints != 0) {
			player.IncreaseArmor ();
			extraPoints -= 1;
		}
	}
	public void IncreaseStrength(){
		if (extraPoints != 0) {
			player.IncreaseStrength ();
			extraPoints -= 1;
		}
	}
	public void IncreaseAttackSpeed(){
		if(extraPoints != 0){
		if (player.timeBetweenAttacks < 0.1f) {
			extraPoints = extraPoints;
		} else {
			player.IncreaseAttackSpeed ();
			extraPoints -= 1;
			}
		}
	}


}
