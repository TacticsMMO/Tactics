using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour{
	
	//Base Stats
	Strength Strength = new Strength();
	Intelect Intelect = new Intelect();
	Agility Agility = new Agility();
	
	int charId;
	public int CharId {
		get {
			return this.charId;
		}
		set {
			charId = value;
		}
	}
	
	//TODO: maybe create resource class??
	Health health = new Health();
	public Health Health {
		get {
			return this.health;
		}
		set {
			health = value;
		}
	}
	
	//Movement
	Movement movement = new Movement();
	public Movement Movement {
		get {
			return this.movement;
		}
		set {
			movement = value;
		}
	}
	
	Level level = new Level();
	public Level Level {
		get {
			return this.level;
		}
		set {
			level = value;
		}
	}
	
	Team team = new Team();
	public Team Team {
		get {
			return this.team;
		}
		set {
			team = value;
		}
	}
	
	bool isSelected = false;
	public bool IsSelected {
		get {
			return this.isSelected;
		}
		set {
			isSelected = value;
		}
	}
	
	public Character(){
		
	}	
	
	public bool isAlive(){
		return Health.AttributeValue > 0 ? true : false;	
	}
	
	public void Select(){
		isSelected = true;
		GetComponent<CharacterUI>().showHP = true;
	}
	
	public void UnSelect(){
		isSelected = false;
		GetComponent<CharacterUI>().showHP = false;
		
	}
	
	public void StoppedMoving(){
		GetComponent<CharacterAnimation>().PlayAnimation("Skel_Idle", true);
	}
	
	public void StartedMoving(){
		GetComponent<CharacterAnimation>().PlayAnimation("Skel_Running", true);
	}
	
}
