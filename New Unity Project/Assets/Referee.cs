using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Referee : MonoBehaviour
{
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
	public GameObject[] allTiles;
	Vector3 actSpherePos;
	int spherePlayerID;
	int newActiveSphere;    //valores temp para mudança de posiçao
	public GameObject sphereToMove;
	public bool moveButtonPressed;
	public bool movingSphere;
	public Vector3 oldPos;  // para anim de move;
	public Vector3 newPos;
	public GameObject showMovePrefab;
	GameObject showMove;
	bool tileInfo;
	
	// Use this for initialization
	void Start ()
	{
		tileInfo = false;
		movingSphere = false;
		moveButtonPressed = false;
		activePlayer = 0;
		errorText.material.color = Color.white;
		errorText.text = "";
		//uma para cada canto, 
		// to do: placement phase ;<
		startPos = new List<Vector3> ();
		startPos.Add (new Vector3 (20, 6, 10));
		startPos.Add (new Vector3 (270, 6, 280));
		startPos.Add (new Vector3 (30, 6, 10));
		startPos.Add (new Vector3 (280, 6, 280));
			
		//isto é quase programaçao quantica
		playerStrings.Add ("Player 1's Turn");
		playerStrings.Add ("Player 2's Turn");
		
		turnText.text = playerStrings [0];
		turnText.material.color = Color.red;
		
		//Processo industrial de criação, nomeação e pintura (10 anos garantia)
		for (int i = 0; i < numberPlayers; i++) {
			GameObject sphere = Instantiate (spherePrefab, startPos [i], Quaternion.identity) as GameObject;
			sphere.transform.localScale = new Vector3 (5, 5, 5);
			sphere.GetComponent<sphereData> ().playerID = i % 2;
			sphere.GetComponent<sphereData> ().sphereID = sphereID;
			sphere.GetComponent<sphereData> ().spherePos = startPos [i];
			sphereID++;  //mudar caso haja mais do que duas esferas
			if (i % 2 == 0) {
				sphere.renderer.material.color = Color.red;
			} else {
				sphere.renderer.material.color = Color.green;
			}
			sphere.transform.position = startPos [i];
		}
		sphereSelected = false;
		allSpheres = GameObject.FindGameObjectsWithTag ("Unit");
		allTiles = GameObject.FindGameObjectsWithTag("Tile");
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
	
	public void turnCycle ()
	{
		if (activePlayer == 1) {
			activePlayer = 0;
			turnText.text = playerStrings [0];
			turnText.material.color = Color.red;
		} else {
			activePlayer = 1;	
			turnText.text = playerStrings [1];
			turnText.material.color = Color.green;
		}
	}
	
	public void errorDisplay (int errorNumber)
	{
		if (errorNumber == 2) {
			errorText.text = "A friendly unit is already in that position!";
		}
		
		if (errorNumber == 3) {
			errorText.text = "A Enemy's unit is already in that position!";	
		}
		
		if (errorNumber == 4) {
			errorText.text = "It's not your turn!";	
		}
		
		if (errorNumber == 5) {
			errorText.text = "Can't move that far!";
		}
	}
	
	public void movementControl (Vector3 tileToMove)
	{	
		if (!tileInfo){
			allTiles = GameObject.FindGameObjectsWithTag("Tile"); //só faz uma vez
		}
		if (!movingSphere) {
			errorText.text = "";
			
			if (!sphereSelected && sphereCheck (allSpheres, activePlayer, tileToMove)) {
				sphereSelected = true;
				activeSphere = newActiveSphere;
			}
			else if (moveButtonPressed) {
				if (sphereSelected && sphereCheck (allSpheres, activePlayer, tileToMove) && canMove (tileToMove)) {
					sphereToMove.GetComponent<sphereData> ().spherePos = tileToMove;
					newPos = tileToMove;
					movingSphere = true;
					moveButtonPressed = false;
					GetComponent<MovementControl> ().startMovement (oldPos, newPos);
					turnCycle ();
					removeShowTiles();
					
				} 
				else {
					sphereSelected = false;	
					moveButtonPressed = false;
					removeShowTiles();
			}
			}
			else{
				moveButtonPressed = false;
				sphereSelected = false;
				removeShowTiles();
			}
		}
	}
			
	bool canMove (Vector3 tileToMove){
		Vector3 pos = sphereToMove.transform.position;
		foreach (GameObject tile in allTiles){
			Vector3 tilePos = tile.transform.position;	
			if (tilePos == tileToMove){
				float distance = Mathf.Sqrt( Mathf.Pow((pos.x - tilePos.x)/10,2) + Mathf.Pow((pos.z - tilePos.z)/10,2));
				if ((distance) <= 5 ){
					return true;
				}
				else{
					errorDisplay(5);
					return false;
				}
			}
			
		}
		return false;
	}
	
	
	bool sphereCheck (GameObject[] allSpheres, int activePlayer, Vector3 tileToMove)
	{
		foreach (GameObject sph in allSpheres) {
			actSpherePos = sph.GetComponent<sphereData> ().spherePos;
			sphereID = sph.GetComponent<sphereData> ().sphereID;
			spherePlayerID = sph.GetComponent<sphereData> ().playerID;
			
			if (actSpherePos == tileToMove && spherePlayerID == activePlayer && !sphereSelected) {
				newActiveSphere = sphereID;
				sphereToMove = sph;
				oldPos = actSpherePos;
				return true;
			} else if (actSpherePos == tileToMove && spherePlayerID != activePlayer && !sphereSelected){
				errorDisplay (4);
				return false;
			} else if (actSpherePos == tileToMove && spherePlayerID != activePlayer) {
				errorDisplay (3);
				return false;
			} else if (actSpherePos == tileToMove) {
				errorDisplay (2);
				return false;
			}
		}
		if (sphereSelected) {
			return true;
		}
		return false;
	}
	
	public void showMoveTiles (){
		Vector3 pos = sphereToMove.transform.position;

		foreach (GameObject tile in allTiles){
			Vector3 tilePos = tile.transform.position;	
			float distance = Mathf.Sqrt( Mathf.Pow((pos.x - tilePos.x)/10,2) + Mathf.Pow((pos.z - tilePos.z)/10,2));
			if ((distance) <= sphereToMove.GetComponent<sphereData>().Moves ){
				print (sphereToMove.GetComponent<sphereData>().Moves);
				GameObject showMove = Instantiate (showMovePrefab, tilePos + new Vector3(0,0.1f,0) , Quaternion.identity) as GameObject;
				showMove.renderer.material.color = Color.blue;
			}
			
		}
	}	
	
	void removeShowTiles(){
		foreach (GameObject showtile in GameObject.FindGameObjectsWithTag ("Show")){
			Destroy (showtile);
		}
	}	
}
	

