using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class testCharAttributeSelector : MonoBehaviour {
	
	
	class attributeSpace{
		int numRandomAttributes = 0;
		string name = "";
		List<string> attributes = new List<string>();
		List<bool> selecteds = new List<bool>();
		
		public attributeSpace(int numRandAttribs, List<string> newAttributes, string newName){
			name = newName;
			numRandomAttributes = numRandAttribs;
			attributes.AddRange(newAttributes);	
			for(int i = 0; i < attributes.Count; ++i){
				selecteds.Add(false);	
			}
		}
		
		public void draw(Rect pos){
			GUI.Label(new Rect(pos.x, pos.y - 50, 200, 50), name);
			for(int i = 0; i < attributes.Count; ++i){
				selecteds[i] = GUI.Toggle(new Rect(pos.x + i/10 * 250, pos.y + i* 50, pos.width, pos.height), selecteds[i], attributes[i]);
			
			}
		}
		
		public void randomize(){
			for(int i = 0; i < selecteds.Count; ++i){
				selecteds[i] = false;	
			}
			int prevRandom = -1;
			int randomNum = -1;
			for(int i = 0; i < numRandomAttributes; ++i){
				while(randomNum == prevRandom){
					randomNum = (int) Random.Range(0, attributes.Count);
				}
				prevRandom = randomNum;
				selecteds[randomNum] = true;
			}
		}
	}
	
	List<attributeSpace> attribSpaces = new List<attributeSpace>();
	
	string[] rangeAttribs = {"Ranged", "Melee"};
	string[] atkTypeAttribs = {"Physical", "Magical", "True Damage"};
	string[] dmgTypeAttribs = {"Direct Dmg/Heal", "DOTs/HOTs", "Absorbs Dmg/Heal", "Summons"};
	string[] dmgRangeTypeAtribs = {"Single Target", "AoE"};
	string[] resourceAttribs = {"Health", "Mana", "Rage", "Target Combo Points", "Self Combo Points", "Energy", "Dual State", "None/Cooldowns"};
	string[] genericTypeAttribs = {"Tank", "Healer", "Dps", "Buffer", "Debuffer", "Support", "CCer"};
	string[] buildAttribs = {"Tanky", "Bruiser", "Squishy"};
	string[] moveAttribs = {"Teleport", "Hover", "High Jumper", "Normal"};
	
	// Use this for initialization
	void Start () {
		attribSpaces.Add(new attributeSpace(1, new List<string>(rangeAttribs), "range"));
		attribSpaces.Add(new attributeSpace(1, new List<string>(atkTypeAttribs), "atk type"));
		attribSpaces.Add(new attributeSpace(2, new List<string>(dmgTypeAttribs), "damage type"));
		attribSpaces.Add(new attributeSpace(1, new List<string>(dmgRangeTypeAtribs), "dmg range type"));
		attribSpaces.Add(new attributeSpace(1, new List<string>(resourceAttribs), "resource"));
		attribSpaces.Add(new attributeSpace(1, new List<string>(buildAttribs), "build"));
		attribSpaces.Add(new attributeSpace(2, new List<string>(genericTypeAttribs), "generic role"));
		attribSpaces.Add(new attributeSpace(1, new List<string>(moveAttribs), "move type"));
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI() {
		for(int i = 0, j = 0; i < attribSpaces.Count; ++i, ++j){
			if(j == 2){
				j = 0;	
			}
			attribSpaces[i].draw(new Rect(i / 2 * 300 + 10, j * 500 + 100, 300, 100));	
		}
		
		if(GUI.Button(new Rect(Screen.width - 200, 100, 100, 100), "RANDOMIZE!!")){
			for(int i = 0; i < attribSpaces.Count; ++i){
				attribSpaces[i].randomize();
			}
		}
	}
}
