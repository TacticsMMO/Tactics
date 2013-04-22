using UnityEngine;
using System.Collections;

public class Character {
	
	//Base Stats
	Strength Strength = new Strength();
	Intelect Intelect = new Intelect();
	Agility Agility = new Agility();
	
	//TODO: maybe create resource class??
	Health Health = new Health();
	
	//Movement
	Movement Movement = new Movement();
	
	Level Level = new Level();
	
	Team Team;
	
	public Character(){
		
	}	
	
	public bool isAlive(){
		return Health.AttributeValue > 0 ? true : false;	
	}
}
