using UnityEngine;
using System.Collections;

public class testMatch : MonoBehaviour {
	
	public Battlefield map;
	public Terrain geo;
	
	// Use this for initialization
	void Start () {
		map = new Battlefield(10, 10);
		GameObject terr = Resources.Load("Prefabs/DefaultTerrainPrefab") as GameObject;
		float xOffset = 0.5f;
		float yOffset = 0.0f;
		float zOffset = 0.5f;
		for(int i = 0; i < map.battleTerrainSize.length; ++i){
			for(int j = 0; j < map.battleTerrainSize.width; ++j){
				yOffset = geo.SampleHeight(new Vector3(i + xOffset, 0.1f, j + zOffset));
				Debug.Log(yOffset);
				GameObject clone = Instantiate(terr, new Vector3(i + xOffset, 0.1f + yOffset, j + zOffset), Quaternion.identity) as GameObject;
				clone.name = "Cell_" + i.ToString() + "_" + j.ToString();
				deformCell(clone);
			}
		}	
	}
	
	void deformCell(GameObject cell){
		Mesh cellMesh = new Mesh();//Instantiate (cell.GetComponent<MeshFilter>().sharedMesh) as Mesh;
		//cellMesh = cell.GetComponent<MeshFilter>().sharedMesh;
		Vector3[] vertices = new Vector3[cell.GetComponent<MeshFilter>().sharedMesh.vertexCount];
		cell.GetComponent<MeshFilter>().sharedMesh.vertices.CopyTo(vertices, 0);
		cellMesh.vertices = vertices;
		Vector3[] normals = new Vector3[cell.GetComponent<MeshFilter>().sharedMesh.vertexCount];
		cell.GetComponent<MeshFilter>().sharedMesh.normals.CopyTo(normals, 0);
		for(int i = 0; i < cellMesh.vertexCount; ++i){
			Vector3 newPos = cell.transform.position + vertices[i];
			vertices[i].y = geo.terrainData.GetInterpolatedHeight(newPos.x, newPos.z);//SampleHeight(cell.transform.position + vertices[i]);
			Debug.Log("vertice: " + i + ": " + vertices[i]);
		}
		
		cellMesh.name = cell.name;
		
		cellMesh.vertices = vertices;
		cellMesh.normals = normals;
		cellMesh.triangles = cell.GetComponent<MeshFilter>().sharedMesh.triangles;
		cellMesh.uv = cell.GetComponent<MeshFilter>().sharedMesh.uv;
		cellMesh.uv1 = cell.GetComponent<MeshFilter>().sharedMesh.uv1;
		cellMesh.uv2 = cell.GetComponent<MeshFilter>().sharedMesh.uv2;
		cellMesh.Optimize();
		cellMesh.RecalculateBounds();
		
		cell.GetComponent<MeshFilter>().sharedMesh = cellMesh;
		cell.GetComponent<MeshCollider>().sharedMesh = cellMesh;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
