using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RitualCircle : MonoBehaviour {

	private GameController gameController;

	public int ritualType;
	public int balanceRatio;

	public ParticleSystem particles;
	public AudioSource sound;

	public GameObject circleStandard;
	public GameObject circleBalance;

	private GameObject[] circles;

	// Use this for initialization
	void Start () {
		InitializeCircles();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void InitializeCircles() {
		gameController = null;

		circles = new GameObject[] {
			circleStandard,
			circleBalance
		};

		for (int i = 0; i < circles.Length; i++) {
			circles[i].SetActive(i == ritualType);
		}

		gameObject.GetComponent<ParticleSystemRenderer>().material =
			circles[ritualType].GetComponent<Renderer>().material;
	}

	public void PerformRitual() {
		particles.Play();
		sound.Play();

		if (gameController == null) {
			gameController = (GameController) FindObjectOfType<GameController>();
		}
		gameController.AddChicken(this);
	}
}
