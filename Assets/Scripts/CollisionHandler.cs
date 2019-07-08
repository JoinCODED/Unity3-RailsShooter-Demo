using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour {


	[SerializeField] GameObject deathFX;
	[SerializeField] float levelLoadDelay = 3f;

	// Use this for initialization
	void Start () {
		
	}

	void OnTriggerEnter(Collider other) {
		deathFX.SetActive(true);
		StartDeathSequence();
		Invoke("ReloadScene", levelLoadDelay);
	}

	private void StartDeathSequence(){
		SendMessage("OnPlayerDeath"); //string referenced
	}

	private void ReloadScene(){
		SceneManager.LoadScene(1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
