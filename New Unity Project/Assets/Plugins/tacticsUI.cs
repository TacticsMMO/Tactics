using UnityEngine;
using System.Collections;

public class tacticsUI : MonoBehaviour {

	// Use this for initialization
	public bool sphereSelected;
	GameObject Scripts;
	Referee myRef;
	
	void Start () {
		Scripts = GameObject.Find ("Scripts");
		myRef = Scripts.GetComponent<Referee> ();
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI () {
		
		/*
		if (GUI.Button (new Rect (Screen.width-200,Screen.height-400,100,30), "Show Grid")) {
			print ("You clicked the Grid button!");
		}
		*/
		
		if (myRef.characterSelected){
			if (GUI.Button (new Rect (Screen.width-200,Screen.height-450,100,30), "Move")) {
				myRef.moveButtonPressed = true;
				myRef.showMoveTiles();
			}
			
		}
		
	}
}
