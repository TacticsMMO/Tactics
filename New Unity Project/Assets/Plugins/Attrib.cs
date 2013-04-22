using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Attrib {
	
	string attributeName;
	float attributeValue;
	
	int minAttributeValue;
	int maxAttributeValue;
	
	Dictionary<int, float> attributePerLvl;
	
	public Dictionary<int, float> AttributePerLvl {
		get {
			return this.attributePerLvl;
		}
		set {
			attributePerLvl = value;
		}
	}
	
	public string AttributeName {
		get {
			return this.attributeName;
		}
		set {
			attributeName = value;
		}
	}

	public float AttributeValue {
		get {
			return this.attributeValue;
		}
		set {
			attributeValue = value;
			validateAttrib();
		}
	}

	public int MinAttributeValue {
		get {
			return this.minAttributeValue;
		}
		set {
			minAttributeValue = value;
			validateAttrib();
		}
	}

	public int MaxAttributeValue {
		get {
			return this.maxAttributeValue;
		}
		set {
			maxAttributeValue = value;
			validateAttrib();
		}
	}
	public Attrib (string attributeName = "", float attributeValue = 0.0f, int minAttributeValue = 0, int maxAttributeValue = 255)
	{
		this.attributeName = attributeName;
		this.attributeValue = attributeValue;
		this.minAttributeValue = minAttributeValue;
		this.maxAttributeValue = maxAttributeValue;
	}
	
	public void levelUp(int level){
		AttributeValue += AttributePerLvl[level];
	}
	
	public void validateAttrib(){
		if(AttributeValue <= MinAttributeValue){
			AttributeValue = MinAttributeValue;	
		}
		if(AttributeValue >= MaxAttributeValue){
			AttributeValue = MaxAttributeValue;	
		}
	}
	
}

public class Strength : Attrib {
	
	public Strength(){
		AttributeName = "Strength";		
	}
}

public class Intelect : Attrib {
	
	public Intelect(){
		AttributeName = "Intelect";		
	}
}

public class Agility : Attrib {
	
	public Agility(){
		AttributeName = "Agility";		
	}
}

public class Health : Attrib {
	
	public Health(){
		AttributeName = "Health";		
	}
}
public class Movement : Attrib {
	
	public enum movementType 
	{
		Teleport, //ignores all movement predicaments
		Flying, //ignores height
		Float, //ignores terrain
		Normal
	}
	
	movementType moveType;
	
	public movementType MoveType {
		get {
			return this.moveType;
		}
		set {
			moveType = value;
		}
	}
	
	public Movement(){
		AttributeName = "Movement";		
	}
}
