using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Referee : MonoBehaviour {
	
	
	
	public GUIText turnText;              // para escrever de quem é o turno actual
	public GUIText errorText;
	int numberPlayers = 4;
	public int activePlayer;               // identificador de turno
	public List<Vector3> startPos;       // para é metido a pata e usa indice do activeplayer
	public List<string> playerStrings;   // para GUI
	int sphereID = 0;        			 // id unico de esfera
	public int activeSphere;             // esfera activa
	public GameObject spherePrefab;
	public bool sphereSelected;
	GameObject[] allSpheres;      
	Vector3 actSpherePos;
	int spherePlayerID;
	int newActiveSphere;    //valores temp para mudança de posiçao
	GameObject sphereToMove;
	public bool moveButtonPressed;
	
	// Use this for initialization
	void Start () {
		moveButtonPressed = false;
		activePlayer = 0;
		errorText.material.color = Color.black;
		errorText.text = "";
		//uma para cada canto, 
		// to do: placement phase ;<
		startPos = new List<Vector3>();
		startPos.Add(new Vector3(20,6,10));
		startPos.Add(new Vector3(272,6,280));
		startPos.Add(new Vector3(32,6,10));
		startPos.Add(new Vector3(284,6,280));
			
		//isto é quase programaçao quantica
		playerStrings.Add ("Player 1's Turn");
		playerStrings.Add ("Player 2's Turn");
		
		turnText.text = playerStrings[0];
		turnText.material.color = Color.red;
		
		//Processo industrial de criação, nomeação e pintura (10 anos garantia)
		for (int i = 0; i < numberPlayers ; i++) {
			GameObject sphere = Instantiate(spherePrefab , startPos[i], Quaternion.identity) as GameObject;
			sphere.transform.localScale = new Vector3(5,5,5);
			sphere.GetComponent<sphereData>().playerID = i%2;
			sphere.GetComponent<sphereData>().sphereID = sphereID;
			sphere.GetComponent<sphereData>().spherePos = startPos[i];
			sphereID++;  //mudar caso haja mais do que duas esferas
			if (i%2 == 0){
				sphere.renderer.material.color = Color.red;
			}
			else{
				sphere.renderer.material.color = Color.green;	
			}
			sphere.transform.position = startPos[i];
		}
		sphereSelected = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void turnCycle() {
		if (activePlayer == 1){
			activePlayer = 0;
			turnText.text = playerStrings[0];
			turnText.material.color = Color.red;
		}
		else {
			activePlayer = 1;	
			turnText.text = playerStrings[1];
			turnText.material.color = Color.green;
		}
	}
	
	public void errorDisplay(int errorNumber) {
		if (errorNumber == 2){
			errorText.text = "A unit is already in that position!";
	
		}
	}
	
	public void movementControl(Vector3 tileToMove){
		errorText.text = "";
		allSpheres = GameObject.FindGameObjectsWithTag ("Unit");
		
		if (!sphereSelected && sphereCheck(allSpheres,activePlayer,tileToMove)){
			sphereSelected = true;
			activeSphere = newActiveSphere;
		}
		if (moveButtonPressed){
			if (sphereSelected && sphereCheck(allSpheres,activePlayer,tileToMove)){
				sphereToMove.GetComponent<sphereData>().spherePos = tileToMove;
				sphereToMove.transform.position = tileToMove;
				sphereSelected = false;
				turnCycle();
			}
			else{
				sphereSelected = false;	
			}
			moveButtonPressed = false;
		}
		
	}
			
			
	bool sphereCheck(GameObject[] allSpheres,int activePlayer, Vector3 tileToMove){
		foreach (GameObject sph in allSpheres){
			actSpherePos = sph.GetComponent<sphereData> ().spherePos;
			sphereID = sph.GetComponent<sphereData> ().sphereID;
			spherePlayerID = sph.GetComponent<sphereData> ().playerID;
			
			if (actSpherePos == tileToMove && spherePlayerID == activePlayer && !sphereSelected){
				newActiveSphere = sphereID;
				sphereToMove = sph;
				return true;
			}
			
			else if (actSpherePos == tileToMove) {
				errorDisplay(2);
				return false;	
			}
			
		}
		if (sphereSelected){
			return true;
		}
		return false;
	}
	
		
	
}
	

