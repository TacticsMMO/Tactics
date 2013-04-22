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
		/*
		activeSphere = myRef.activeSphere;
		activePlayer = myRef.activePlayer;
		renderer.material.color = new Color (0, 255, 0);
		allSpheres = GameObject.FindGameObjectsWithTag ("Unit");
		
		foreach (GameObject sph in allSpheres) {
			actSpherePos = sph.GetComponent<sphereData> ().spherePos;
			sphereID = sph.GetComponent<sphereData> ().sphereID;
			spherePlayerID = sph.GetComponent<sphereData> ().playerID;
			
			if (this.transform.position == actSpherePos && spherePlayerID == activePlayer) {
				timeToMove = true;
				myRef.activeSphere = sphereID;
				renderer.material.color = new Color (0, 255, 0);
				break;
			} else if (this.transform.position != actSpherePos && myRef.activeSphere == sphereID) {                 //criar funçao para limitar a distancia de mov.
					
				foreach (GameObject otherSph in allSpheres) {
					if (otherSph.GetComponent<sphereData> ().spherePos == this.transform.position && timeToMove) {
						timeToMove = false;
						myRef.errorDisplay (2);
						break;
					}	
				}
					
				if (timeToMove) {
					sph.GetComponent<sphereData> ().spherePos = this.transform.position;
					sph.transform.position = this.transform.position;
					timeToMove = false;
		
					myRef.turnCycle ();
					break;
				}
			}
		}
		print (activeSphere); */
		
		
		
		
	}
	
	void OnMouseUp ()
	{
		renderer.material.color = new Color (1, 1, 1);
	}
		
}
