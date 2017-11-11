using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement ;

public class PlayerPrefManager : MonoBehaviour 
{
	const string MASTER_VOLUME_KEY = "master_volume";
	const string DIFFICULTY_KEY = "difficulty";
	const string LEVEL_KEY = "level_unlocked_" ; 

	public static void SetMasterVolume (float volume)
	{
		if (volume >= 0f && volume <= 1f) {
			PlayerPrefs.SetFloat (MASTER_VOLUME_KEY, volume); // key, value --- PLayer prefs is premade by unity to store preferences we made constant strings so we don't need to guess when trying to remember what we used
		} else
			Debug.LogError ("Master volume is out of range"); 
	}

	public static float GetMasterVolume ()
	{
		return PlayerPrefs.GetFloat (MASTER_VOLUME_KEY); 
	}

	public static void UnlockLevel ( int level) 
	{
		if (level <= SceneManager.sceneCountInBuildSettings) {
			PlayerPrefs.SetInt (LEVEL_KEY + level.ToString (), 1); // use 1 for true
			print("Unlocked level " + level) ; 
		} else {
			Debug.LogError ("Trying to query level not in build order"); 
		}
	}

	public static bool IsLevelUnlocked ( int level)
	{
		int levelValue = PlayerPrefs.GetInt (LEVEL_KEY + level.ToString());
		bool isLevelUnlocked = (levelValue == 1);

		if (level <= SceneManager.sceneCountInBuildSettings && (isLevelUnlocked)) {
			print ("Level is unlocked"); 
			return isLevelUnlocked;
		}
		else {
			Debug.LogError ("Trying to query level not in build order");
			return false; 
		}
	}

	public static void SetDifficulty (float difficulty)
	{
		if (difficulty >= 1f && difficulty <= 3f) {
			PlayerPrefs.SetFloat (DIFFICULTY_KEY, difficulty);
		} else {
			Debug.LogError ("Difficulty out of range"); 
		}
	}
	public static float GetDifficulty ()
	{
		return PlayerPrefs.GetFloat (DIFFICULTY_KEY); 
	}
}
