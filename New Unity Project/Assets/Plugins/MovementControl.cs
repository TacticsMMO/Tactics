using UnityEngine;
using System.Collections;

public class MovementControl : MonoBehaviour {

	float speed = 150f;
	float journeyLength;
	float distCovered;
	float fracJourney;
	float startTime;
	Vector3 actualPos;
	Vector3 newPos;
	GameObject characterToMove;
		
	// Use this for initialization
	void Start () {
        	
	}
	
	
	// Update is called once per frame
	void Update () {
		
		if (GetComponent<Referee>().movingSphere){
		// Distance moved = time * speed.
        	float distCovered = (Time.time - startTime) * speed;
			
        
	        // Fraction of journey completed = current distance divided by total distance.
        	float fracJourney = distCovered / journeyLength;
	        
        	// Set our position as a fraction of the distance between the markers
			characterToMove.transform.position = Vector3.Lerp(actualPos, newPos, fracJourney);
	
			
			if (characterToMove.transform.position == newPos){
				GetComponent<Referee>().movingSphere=false;
				GetComponent<Referee>().characterSelected=false;
				characterToMove.GetComponent<Character>().StoppedMoving();
			}
			
		}
	}

	public void startMovement(Vector3 oldPos, Vector3 nPos){
		startTime = Time.time;
		actualPos = oldPos;
		newPos = nPos;
	    // Calculate the journey length.
        journeyLength = Vector3.Distance(actualPos, newPos);
		characterToMove = GetComponent<Referee>().characterToMove;
		characterToMove.GetComponent<Character>().StartedMoving();
	}
		
}
		
	

