using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CommandsEnemies{
	protected float speedMoves;
	protected float damege;
	protected float range;
	protected float armor;
	protected Player player;
	public float health;

	public virtual void Move(Transform enemy, float range){
		if (this.range < range){
			enemy.transform.Translate (speedMoves*Time.deltaTime*Vector3.left);
		}
	}
	public virtual void Attack(float distance){}

	public virtual void TakeDamege(float damage){
		if (damege>armor) {
			health = health -(Random.Range(damage/2f, damage)-Random.Range(armor/2f, armor));		
		}
	}

}

public class WarriorCommands: CommandsEnemies{
	public WarriorCommands(float speedMoves,float health, float damage, float range, float armor, Player player){
		this.speedMoves = speedMoves;
		this.health = health;
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

public class ArcherCommands: CommandsEnemies{
	public ArcherCommands(float speedMoves, float health, float damage, float range, float armor, Player player){
		this.speedMoves = speedMoves;
		this.health = health;
		this.damege = damage;
		this.range = range;
		this.armor = armor;
		this.player = player;
	}
}

public class BuletsCommands: CommandsEnemies{
	public BuletsCommands(float speedMoves, float health, float damage, float range, float armor, Player player){
		this.speedMoves = speedMoves;
		this.health = health;
		this.damege = damage;
		this.range = range;
		this.armor = armor;
		this.player = player;
	}

//			enimy.position =Vector3.MoveTowards (enimy.position, player.transform.position, speedMoves);
//			Vector3 direction = player.transform.position - enimy.position;
//			enimy.transform.Translate (speedMoves*Time.deltaTime*Vector3.Normalize(direction));
	public override void Move(Transform enemy, float range){
		if (this.range < range){
			enemy.transform.Translate (speedMoves*Time.deltaTime*Vector3.forward);

		}
	}	
	public override void Attack(float distance){
		this.player.TakeDamage (damege);
	}
}