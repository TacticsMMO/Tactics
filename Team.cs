using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Team {
	
	List<Character> roster;
	
	string name;
	
	public List<Character> Roster {
		get {
			return this.roster;
		}
		set {
			roster = value;
		}
	}

	public string Name {
		get {
			return this.name;
		}
		set {
			name = value;
		}
	}
	
	public Team (string name = "")
	{
		this.name = name;
	}

	
}
