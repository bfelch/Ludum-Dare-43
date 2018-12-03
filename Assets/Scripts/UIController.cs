using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

	public GameObject deployButton;
	public GameObject resetButton;

	public GameObject challengePanel;
	public GameObject successPanel;
	public GameObject failurePanel;
	public GameObject finalePanel;
	public GameObject levelPanel;

	public Button[] challenges;

	public int unlockedChallenges = 0;
	private int currentChallenge;

	private GameObject[] components;

	// Use this for initialization
	void Start () {
		InitializeUI();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetChallenge(int challenge) {
		currentChallenge = challenge;
	}

	public void UnlockNextChallenge() {
		if (currentChallenge == unlockedChallenges) {
			unlockedChallenges++;
			PlayerPrefs.SetInt("Unlocked", unlockedChallenges);
		}

		InitializeUI();
	}

	public void InitializeUI() {
		components = new GameObject[] {
			deployButton,
			resetButton,

			challengePanel,
			successPanel,
			failurePanel,
			finalePanel,
			levelPanel
		};

		ShowComponents(challengePanel);
		unlockedChallenges = PlayerPrefs.GetInt("Unlocked");
		for (int i = 0; i < challenges.Length; i++) {
			challenges[i].interactable = (i <= unlockedChallenges);
		}
	}

	private void ShowComponents(GameObject obj) {
		foreach (GameObject component in components) {
			component.SetActive(component == obj);
		}
	}

	public void EndChallenge(bool success) {
		if (success) {
			if (unlockedChallenges + 1 >= challenges.Length) {
				ShowComponents(finalePanel);
			} else {
				ShowComponents(successPanel);
			}
		} else {
			ShowComponents(failurePanel);
		}
	}

	public void ShowLevelText() {
		ShowComponents(levelPanel);
	}

	public void Deploy() {
		ShowComponents(resetButton);
	}

	public void Reset() {
		ShowComponents(deployButton);
	}
}
