using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Referee : MonoBehaviour
{
	public GUIText turnText;              // para escrever de quem é o turno actual
	public GUIText errorText;
	int numberPlayers = 2;
	public int activePlayer;               // identificador de turno
	public List<Vector3> startPos;       // para é metido a pata e usa indice do activeplayer
	public List<string> playerStrings;   // para GUI
	int characterID = 0;        			 // id unico de esfera
	public int activeCharacter;             // esfera activa
	public GameObject characterPrefab;
	public bool characterSelected;
	GameObject[] allCharacters;
	public GameObject[] allTiles;
	Vector3 actCharacterPos;
	int characterTeamID;
	int newActiveCharacter;    //valores temp para mudança de posiçao
	public GameObject characterToMove;
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
			GameObject character = Instantiate (characterPrefab, startPos [i], Quaternion.identity) as GameObject;
			character.transform.localScale = new Vector3 (25, 25, 25);
			character.GetComponent<Character> ().Team.Id = i % 2;
			character.GetComponent<Character> ().CharId = characterID;
			character.GetComponent<Character> ().Movement.AttributeValue = 4;
			//character.GetComponent<Character> ().sphereID = sphereID;
			//character.GetComponent<Character> ().spherePos = startPos [i];
			characterID++;  //mudar caso haja mais do que duas esferas
			/*if (i % 2 == 0) {
				character.renderer.material.color = Color.red;
			} else {
				character.renderer.material.color = Color.green;
			}*/
			character.transform.position = startPos [i];
		}
		characterSelected = false;
		allCharacters = GameObject.FindGameObjectsWithTag ("Unit");
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
			
			if (!characterSelected && CharacterCheck (allCharacters, activePlayer, tileToMove)) { //activates a character
				characterSelected = true;
				activeCharacter = newActiveCharacter;
			}
			else if (moveButtonPressed) {
				if (characterSelected && CharacterCheck (allCharacters, activePlayer, tileToMove) && canMove (tileToMove)) {
					//characterToMove.GetComponent<sphereData> ().spherePos = tileToMove;
					newPos = tileToMove;
					movingSphere = true;
					moveButtonPressed = false;
					GetComponent<MovementControl> ().startMovement (oldPos, newPos);
					turnCycle ();
					removeShowTiles();
					
				} 
				else {
					characterSelected = false;	
					moveButtonPressed = false;
					removeShowTiles();
			}
			}
			else{
				moveButtonPressed = false;
				characterSelected = false;
				removeShowTiles();
			}
		}
	}
			
	bool canMove (Vector3 tileToMove){
		Vector3 pos = characterToMove.transform.position;
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
	
	
	bool CharacterCheck (GameObject[] allCharacters, int activePlayer, Vector3 tileToMove)
	{
		foreach (GameObject character in allCharacters) {
			actCharacterPos = character.transform.position;//.GetComponent<sphereData> ().spherePos;
			character.GetComponent<Character>().UnSelect();
			characterID = character.GetComponent<Character>().CharId;//GetComponent<sphereData> ().sphereID;
			characterTeamID = character.GetComponent<Character>().Team.Id;// ().playerID;
			
			if (actCharacterPos == tileToMove && characterTeamID == activePlayer && !characterSelected) {
				//Character is now selected!
				newActiveCharacter = characterID;
				characterToMove = character;
				oldPos = actCharacterPos;
				character.GetComponent<Character>().Select();
				return true;
			} else if (actCharacterPos == tileToMove && characterTeamID != activePlayer && !characterSelected){
				errorDisplay (4);
				character.GetComponent<Character>().UnSelect();
				return false;
			} else if (actCharacterPos == tileToMove && characterTeamID != activePlayer) {
				errorDisplay (3);
				character.GetComponent<Character>().UnSelect();
				return false;
			} else if (actCharacterPos == tileToMove) {
				errorDisplay (2);
				character.GetComponent<Character>().UnSelect();
				return false;
			}
		}
		if (characterSelected) {
			characterToMove.GetComponent<Character>().UnSelect();
			return true;
		}
		characterToMove.GetComponent<Character>().UnSelect();
		return false;
	}
	
	public void showMoveTiles (){
		Vector3 pos = characterToMove.transform.position;

		foreach (GameObject tile in allTiles){
			Vector3 tilePos = tile.transform.position;	
			float distance = Mathf.Sqrt( Mathf.Pow((pos.x - tilePos.x)/10,2) + Mathf.Pow((pos.z - tilePos.z)/10,2));
			if ((distance) <= characterToMove.GetComponent<Character>().Movement.AttributeValue ){
				print (characterToMove.GetComponent<Character>().Movement.AttributeValue);
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
	

