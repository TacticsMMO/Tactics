using UnityEngine;
using System.Collections;

public class tile : MonoBehaviour
{
	
	int activeSphere;
	Vector3 actSpherePos;
	int sphereID;
	GameObject Scripts;
	Referee myRef;
	int activePlayer;
	int spherePlayerID;
	GameObject[] allSpheres;
	
	
	// Use this for initialization
	void Start ()
	{
		Scripts = GameObject.Find ("Scripts");
		myRef = Scripts.GetComponent<Referee> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
	}
	
	void OnMouseOver ()
	{
		renderer.material.color += new Color (255, 0, 0) * Time.deltaTime;
	}
	
	void OnMouseExit ()
	{
		renderer.material.color = new Color (1, 1, 1);	
		
	}
	
	void OnMouseDown (){
		myRef.movementControl(this.transform.position);
		
	}
	
	void OnMouseUp ()
	{
		renderer.material.color = new Color (1, 1, 1);
	}
		
}
