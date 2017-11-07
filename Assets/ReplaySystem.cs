using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaySystem : MonoBehaviour 
{
	private const int bufferFrames = 1000; 
	private MyKeyFrame[] keyFrames = new MyKeyFrame[bufferFrames];
	private Rigidbody rigidBody;
	private GameBoss gameBoss ;

	// Use this for initialization
	void Start () 
	{
		rigidBody = GetComponent<Rigidbody> (); 
		gameBoss = GameObject.FindObjectOfType<GameBoss> (); 
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		Record (); 
		
	}

	void Record () 
	{
		if( gameBoss.isRecording){
		rigidBody.isKinematic = false; // Allows the object to be controlled by gravity
		int frame = Time.frameCount % bufferFrames; // creates a loop between 0 and 100 to store the keyframes
		float time = Time.time ; 
		print ("Writing frame" + frame); 
		keyFrames [frame] = new MyKeyFrame (time, transform.position, transform.rotation); // using the loop that repeats stores in the frame the constructor to play back to player (Time,pos and rot)
		}
	
	}
	public void PlayBack ()
	{

			rigidBody.isKinematic = true; // lets us controll motion without interuppted by gravity
			int frame = Time.frameCount % bufferFrames; 
			print ("Playing back frames" + frame); 
			transform.position = keyFrames [frame].position; 
			transform.rotation = keyFrames [frame].rotation; 

	}
}


// Constrtuctor for creating keyFrames to be played back to player
public struct MyKeyFrame
{
	public float frameTime; 
	public Vector3 position ; 
	public Quaternion rotation ; 

	public MyKeyFrame (float aTime , Vector3 aPosition , Quaternion aRotation)
	{
		frameTime = aTime; 
		position = aPosition; 
		rotation = aRotation; 
	}
}
