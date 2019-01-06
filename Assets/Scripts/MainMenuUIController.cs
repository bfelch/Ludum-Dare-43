using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUIController : MonoBehaviour {

	public GameObject mainMenu;
	public GameObject aboutMenu;

	private GameObject[] menuItems;

	// Use this for initialization
	void Start () {
		menuItems = new GameObject[] {
			mainMenu,
			aboutMenu
		};

		ShowMain();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("space")) {
			ShowMenu(mainMenu.activeSelf ? null : mainMenu);
		}
	}

	private void ShowMenu(GameObject menu) {
		foreach (GameObject menuItem in menuItems) {
			menuItem.SetActive(menu == menuItem);
		}
	}

	public void ShowAbout() {
		ShowMenu(aboutMenu);
	}

	public void ShowMain() {
		ShowMenu(mainMenu);
	}
}
