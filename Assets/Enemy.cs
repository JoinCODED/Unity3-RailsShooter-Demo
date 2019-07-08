using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	[SerializeField] GameObject deathFX;
	[SerializeField] Transform parent;
	[SerializeField] int scorePerHit = 12;

	ScoreBoard sb;

	// Use this for initialization
	void Start () {
		sb = FindObjectOfType<ScoreBoard>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnParticleCollision(GameObject other){
		sb.ScoreHit(scorePerHit);
		Destroy(gameObject);
		Instantiate (deathFX, transform.position, Quaternion.identity);
	}
}
