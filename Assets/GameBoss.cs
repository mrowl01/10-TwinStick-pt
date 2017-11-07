using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class GameBoss : MonoBehaviour 
{
	public bool isRecording = true ;
	private ReplaySystem replaySystem ;

	void Start ()
	{
		replaySystem = GameObject.FindObjectOfType<ReplaySystem> (); 
	}

	void Update () 
	{
		if (CrossPlatformInputManager.GetButton ("Fire1")) {
			isRecording = false; 
		} else {
			isRecording = true;
		} 

		if (isRecording == false) {
			replaySystem.PlayBack (); 
		}
	}
}
