using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengeController : MonoBehaviour {

	public GameObject[] challenges;
	public UIController uiController;

	// Use this for initialization
	void Start () {
		InitializeChallenge(-1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void InitializeChallenge(int challenge) {
		uiController.SetChallenge(challenge);
		
		for (int i = 0; i < challenges.Length; i++) {
			challenges[i].SetActive(i == challenge);
		}
	}

	public void PlayIntroduction() {
		InitializeChallenge(0);
	}

	public void PlayCorners() {
		InitializeChallenge(1);
	}

	public void PlayAdvancedCorners() {
		InitializeChallenge(2);
	}

	public void PlaySplitters() {
		InitializeChallenge(3);
	}

	public void PlayAdvancedSplitters() {
		InitializeChallenge(4);
	}

	public void PlayFinale() {
		InitializeChallenge(5);
	}
}
