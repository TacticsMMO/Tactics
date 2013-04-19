using UnityEngine;
using System.Collections;

public class BattlefieldCell {
	
	public enum cellType
	{
		Snow,
		Lava,
		Water,
		Grass
	}
	
	int height;
	int movementImpair;
	cellType groundType;
	
	
	public int MovementImpair {
		get {
			return this.movementImpair;
		}
		set {
			movementImpair = value;
		}
	}
	public int Height {
		get {
			return this.height;
		}
		set {
			height = value;
		}
	}
	
	public cellType GroundType {
		get {
			return this.groundType;
		}
		set {
			groundType = value;
		}
	}
	
	public BattlefieldCell (int height = 0, int movementImpair = 0)
	{
		this.height = height;
		this.movementImpair = movementImpair;
	}
	
	public void OnEnter (Character poorSap){
		
	}
	
	public void OnStay (Character snorlax){
		
	}
	
	public void OnExit (Character buBye){
		
	}

 
}

public class Snow : BattlefieldCell {
	public Snow(){
		GroundType = cellType.Snow;
	}
}
