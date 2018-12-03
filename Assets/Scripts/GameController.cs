using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	private int totalChickenCount;
	private int chickenCount;
	private IDictionary<RitualCircle, int> ritualCounter;

	public UIController uiController;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetChickenCount(int count) {
		totalChickenCount = count;
		chickenCount = 0;
		ritualCounter = new Dictionary<RitualCircle, int>();
	}

	public void AddChicken(RitualCircle ritualCircle) {
		string key = ritualCircle.gameObject.name;
		if (ritualCounter.ContainsKey(ritualCircle)) {
			ritualCounter[ritualCircle]++;
		} else {
			ritualCounter[ritualCircle] = 1;
		}

		chickenCount++;

		if (chickenCount == totalChickenCount) {
			uiController.EndChallenge(true);
			// TODO show success screen
			// TODO check matching ratios
		}
	}
}
