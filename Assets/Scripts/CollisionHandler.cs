using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour {


	[SerializeField] GameObject deathFX;

	// Use this for initialization
	void Start () {
		
	}

	void OnTriggerEnter(Collider other) {
		deathFX.SetActive(true);
		StartDeathSequence();
	}

	private void StartDeathSequence(){
		SendMessage("OnPlayerDeath"); //string referenced
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
