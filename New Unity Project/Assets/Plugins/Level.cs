using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Level {

	int lvl;
	
	int maxLevel;
	
	int currentXp;
	
	Dictionary<int, int> xpPerLevel;
	
	public int Lvl {
		get {
			return this.lvl;
		}
		set {
			lvl = value;
		}
	}

	public int MaxLevel {
		get {
			return this.maxLevel;
		}
		set {
			maxLevel = value;
		}
	}

	public int CurrentXp {
		get {
			return this.currentXp;
		}
		set {
			currentXp = value;
		}
	}

	public Dictionary<int, int> XpPerLevel {
		get {
			return this.xpPerLevel;
		}
		set {
			xpPerLevel = value;
		}
	}
	
	public Level (int lvl = 0, int maxLevel = 100, int currentXp = 0)
	{
		this.lvl = lvl;
		this.maxLevel = maxLevel;
		this.currentXp = currentXp;
	}
	
	public void applyExp(int xpGained, out bool didLevel, out int levelIncreases){
		didLevel = false;
		levelIncreases = 0;
		while(xpGained > 0){
			if((CurrentXp + xpGained) > XpPerLevel[Lvl]){
				xpGained -= (XpPerLevel[Lvl] - CurrentXp);
				CurrentXp = 0;
				Lvl += 1;
				levelIncreases += 1;
				didLevel = true;
			} else {
				CurrentXp += xpGained;
				xpGained = 0;
			}
		}
	}

}
