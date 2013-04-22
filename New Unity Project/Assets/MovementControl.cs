using UnityEngine;
using System.Collections;

public class MovementControl : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	float xDiff;
	float zDiff;
	float yHeight=6;
	
	public void Move(Vector3 newPos){
		/*
		while( newPos != sphere.transform.position) {
			xDiff = newPos.x - sphere.transform.position.x;
			print ( newPos.x.ToString() + "," + sphere.transform.position.x.ToString());
			if (xDiff < 0){
				xDiff = -1;
			}
			else if (xDiff > 0){
				xDiff = 1;	
			}
			zDiff = newPos.z - sphere.transform.position.z;
			print (newPos.z.ToString() + "," + sphere.transform.position.z.ToString());
			if (zDiff < 0){
				zDiff = -1;
			}
			else if (zDiff > 0) {
				zDiff = 1;
			}
			sphere.transform.position = new Vector3(sphere.transform.position.x+xDiff, yHeight, sphere.transform.position.z + zDiff);
			
		}
		*/
		//sphere.transform.position = newPos;
	}
}
