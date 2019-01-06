using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void LoadGameplay() {
		ResetTimeScale();
		SceneManager.LoadScene("Gameplay");
	}

	public void LoadMainMenu() {
		ResetTimeScale();
		SceneManager.LoadScene("Main Menu");
	}

	private void ResetTimeScale() {
		Time.timeScale = 1.0f;
	}
}
