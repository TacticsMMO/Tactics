using UnityEngine;
using System.Collections;

public class CharacterAnimation : MonoBehaviour {
	
	
	public Animation myAnim;
	//bool shouldLoop = false;
	bool isPlaying = false;
	string animationPlaying = "";
	
	// Use this for initialization
	void Start () {
		myAnim = GetComponent<Animation>();
	}
	
	// Update is called once per frame
	void Update () {
		isPlaying = myAnim.isPlaying;
		//if(shouldLoop && !isPlaying){
		//	myAnim.Play(animationPlaying);
		//}
	}
	
	public void PlayAnimation(string animationName, bool loop = false){
		//shouldLoop = loop;
		if(loop){
			myAnim[animationName].wrapMode = WrapMode.Loop;	
		} else {
			myAnim[animationName].wrapMode = WrapMode.Once;	
		}
		myAnim.Play(animationName);
	}
	
	
}
