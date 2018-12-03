using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuChickenController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Chicken[] chickens = GetComponentsInChildren<Chicken>();
		foreach (Chicken chicken in chickens) {
			chicken.SetTarget(Vector3.positiveInfinity);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
