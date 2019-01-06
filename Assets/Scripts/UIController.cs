using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

	public GameObject deployButton;
	public GameObject resetButton;
	public GameObject fastForwardButton;

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
			fastForwardButton,

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

		if (obj != fastForwardButton) {
			Time.timeScale = 1.0f;
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
		fastForwardButton.SetActive(true);
	}

	public void Reset() {
		ShowComponents(deployButton);
	}

	public void ToggleFastForward() {
		if (Time.timeScale == 1.0f) {
			Time.timeScale = 2.0f;
		} else {
			Time.timeScale = 1.0f;
		}
	}
}
