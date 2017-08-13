using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enimy{
	protected float speedMoves;
	protected float damege;
	protected float range;
	protected float armor;
	protected float timeBetweenAttacks;
	protected Player player;
	protected EnimyHealth enimyhealth;

	public virtual void Move(Transform enimy, float range){
		if (this.range < range){
			enimy.transform.Translate (speedMoves*Time.deltaTime*Vector3.left);
		}
	}
	public virtual void Attack(float distance){}

	public virtual void TakeDamege(float damage){
		if (damege>armor) {
			enimyhealth.enimyHealth = enimyhealth.enimyHealth -(Random.Range(damage/2f, damage)-Random.Range(armor/2f, armor));		
		}
	}

}

public class WarriorCommands: Enimy{
	public WarriorCommands(float speedMoves, EnimyHealth enimyhealth, float health, float damage, float range, float armor, Player player){
		this.speedMoves = speedMoves;
		this.enimyhealth = enimyhealth;
		this.enimyhealth.enimyHealth = health;
		this.damege = damage;
		this.range = range;
		this.armor = armor;
		this.player = player;
	}
	public override void Attack(float distance){
		if (this.range > distance) {
			this.player.TakeDamage (damege);
		}
	}
}

public class ArcherCommands: Enimy{
	public ArcherCommands(float speedMoves, EnimyHealth enimyhealth, float health, float damage, float range, float armor, Player player){
		this.speedMoves = speedMoves;
		this.enimyhealth = enimyhealth;
		this.enimyhealth.enimyHealth = health;
		this.damege = damage;
		this.range = range;
		this.armor = armor;
		this.player = player;
	}
}

public class BuletsCommands: Enimy{
	public BuletsCommands(float speedMoves, EnimyHealth enimyhealth, float health, float damage, float range, float armor, Player player){
		this.speedMoves = speedMoves;
		this.enimyhealth = enimyhealth;
		this.enimyhealth.enimyHealth = health;
		this.damege = damage;
		this.range = range;
		this.armor = armor;
		this.player = player;
	}
	public override void Move(Transform enimy, float range){
		if (this.range < range){
//			enimy.position =Vector3.MoveTowards (enimy.position, player.transform.position, speedMoves);
//			Vector3 direction = player.transform.position - enimy.position;
//			enimy.transform.Translate (speedMoves*Time.deltaTime*Vector3.Normalize(direction));
			enimy.transform.Translate (speedMoves*Time.deltaTime*Vector3.forward);

		}
	}	
	public override void Attack(float distance){
		this.player.TakeDamage (damege);
	}
}