using UnityEngine;
using System.Collections;

public class CharacterUI : MonoBehaviour {
	
	
	public Rect healthLabel;
	public Character myChar;
	public Camera m_Camera;
	
	public bool showHP = false;
	
	// Use this for initialization
	void Start () {
		myChar = GetComponent<Character>();
		m_Camera = GameObject.Find("Main Camera").GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnGUI() {
		if(showHP){
			ShowHP ();
		}
	}
	
	void OnMouseOver(){
		//showHP = true;	
	}
	
	void OnMouseExit(){
		//showHP = false;	
	}
	
	void ShowHP(){
		Vector3 screenPosition = m_Camera.WorldToScreenPoint(transform.position);// gets screen position.
     	screenPosition.y = Screen.height - (screenPosition.y + 1);// inverts y
     	Rect rect = new Rect(screenPosition.x - 50,
        screenPosition.y - 112, 100, 24);// makes a rect centered at the player ( 100x24 )
		GUI.Box(rect, myChar.Health.AttributeName + ": " + myChar.Health.AttributeValue + "/" + myChar.Health.MaxAttributeValue);
	}
}
