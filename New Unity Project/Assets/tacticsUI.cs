using UnityEngine;
using System.Collections;

public class tacticsUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI () {

		if (GUI.Button (new Rect (Screen.width-200,Screen.height-400,100,30), "Show Grid")) {
			print ("You clicked the Grid button!");
		}

		if (GUI.Button (new Rect (Screen.width-200,Screen.height-450,100,30), "Move")) {
			print ("You clicked the Move button!");
		}
	}
}
