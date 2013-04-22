using UnityEngine;
using System.Collections;

public class tacticsGrid : MonoBehaviour {
	
	
	public Terrain Map;
	public GameObject tilePrefab;
	
	private float xRes;
	private float yRes;

	int tiles = 23;
	int rows = 28;
	Vector3 pos;
	int xSpacing = 12;
	int ySpacing = 10;
	int zSpacing = 6;
	int xPos = 20; //separacao dos tiles
	int yPos = 10;
	
	int tPointHeight;
	
	
	// Use this for initialization
	void Start () {
		xRes = Map.terrainData.heightmapWidth;
		yRes = Map.terrainData.heightmapHeight;
		print ("Map dimensions: (" + xRes.ToString() + "," + yRes.ToString() + ")");
		
		
		for (int i = 0; i < rows ; i++) {
			xPos = 20;
			for (int y = 0; y < tiles; y++) {
				
				//tPointHeight = (int) Map.terrainData.GetHeight(xPos,yPos) +1;
				pos = new Vector3(xPos,zSpacing,yPos);
				
				Instantiate(tilePrefab, pos , Quaternion.identity );		
				xPos += xSpacing;
			}
			yPos += ySpacing;
		}
	
	}
	
	// Update is called once per frame
	void Update () {
		
	
	}
	
}


