﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RitualCircle : MonoBehaviour {

	private GameController gameController;

	public int ritualType;
	public int balanceRatio;

	public ParticleSystem particles;
	public AudioSource sound;

	public TextMesh ratioText;
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
		gameController = (GameController) FindObjectOfType<GameController>();

		circles = new GameObject[] {
			circleStandard,
			circleBalance
		};

		for (int i = 0; i < circles.Length; i++) {
			circles[i].SetActive(i == ritualType);
		}

		ratioText.text = balanceRatio.ToString();
		ratioText.gameObject.SetActive(ritualType == 1);

		gameObject.GetComponent<ParticleSystemRenderer>().material =
			circles[ritualType].GetComponent<Renderer>().material;
	}

	public void PerformRitual() {
		particles.Play();
		sound.Play();
		gameController.AddChicken(this);
	}
}
