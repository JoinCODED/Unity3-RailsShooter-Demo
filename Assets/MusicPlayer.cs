using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour {

	// Use this for initialization

	void Awake(){
		DontDestroyOnLoad(gameObject);
	}
	void Start () {
		Invoke ("LoadFirstScene", 4f); //string referenced
	}

	void LoadFirstScene(){
		SceneManager.LoadScene(1);
	}
}