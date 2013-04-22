using UnityEngine;
using System.Collections;

public class Battlefield {

	BattlefieldCell[,] BattleTerrain;
	
	public struct size {
		public int length;
		public int width;
	}
	
	size BattleTerrainSize;
	
	public size battleTerrainSize {
		get {
			return this.BattleTerrainSize;
		}
		set {
			BattleTerrainSize = value;
		}
	}
	
	
	public BattlefieldCell[,] battleTerrain {
		get {
			return this.BattleTerrain;
		}
		set {
			BattleTerrain = value;
		}
	}
	
	public Battlefield(){
	
	}
	
	public Battlefield(int width, int length){
		battleTerrain = new BattlefieldCell[width, length];
		BattleTerrainSize.length = length;
		BattleTerrainSize.width = width;
	}

}
