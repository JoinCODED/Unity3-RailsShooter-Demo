using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {

	[Tooltip("In ms^-1")][SerializeField] float speed = 40f;
	[Tooltip("In m")][SerializeField] float xRange = 25f;
	[Tooltip("In m")][SerializeField] float yRange = 15f;


	[SerializeField] float positionPitchFactor = -2f;
	[SerializeField] float controlPitchFactor = -2f;
	[SerializeField] float positionYawFactor = 1.5f;
	[SerializeField] float controlRollFactor = -20f;

	bool isControlEnabled = true;

	float xThrow, yThrow; 


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (isControlEnabled) {
			ProcessTranslation ();
			ProcessRotation ();
		}
	}

	

	void OnPlayerDeath(){
		isControlEnabled = false;
	}

	void OnCollisionEnter(Collision collision){
		print ("A collision occured!");
	}

	private void ProcessRotation() {
		//pitch
		float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
		float pitchDueToControlThrow = yThrow * controlPitchFactor;
		float pitch = pitchDueToPosition + pitchDueToControlThrow;

		float yaw = transform.localPosition.x * positionYawFactor;

		float roll = xThrow * controlRollFactor;

		transform.localRotation = Quaternion.Euler(pitch, yaw, roll);

	}

	private void ProcessTranslation ()
	{
		//Throw
		xThrow = CrossPlatformInputManager.GetAxis ("Horizontal");
		yThrow = CrossPlatformInputManager.GetAxis ("Vertical");
		//Offsets
		float xOffset = xThrow * speed * Time.deltaTime;
		float yOffset = yThrow * speed * Time.deltaTime;
		//X raw
		float rawNewXPos = transform.localPosition.x + xOffset;
		float clampedXPos = Mathf.Clamp (rawNewXPos, -xRange, xRange);
		//Y raw
		float rawYPos = transform.localPosition.y + yOffset;
		float clampedYPos = Mathf.Clamp (rawYPos, -yRange, yRange);
		transform.localPosition = new Vector3 (clampedXPos, clampedYPos, transform.localPosition.z);
		//change only Z, not Y and Z.
	}
}
