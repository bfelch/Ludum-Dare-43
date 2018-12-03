using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	private int totalChickenCount;
	private int chickenCount;
	private IDictionary<RitualCircle, int> ritualCounter = null;

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

		RitualCircle[] ritualCircles =
			(RitualCircle[])GameObject.FindObjectsOfType<RitualCircle>();
		
		foreach (RitualCircle ritualCircle in ritualCircles) {
			InitializeCircle(ritualCircle);
		}
	}

	public void InitializeCircle(RitualCircle ritualCircle) {
		if (ritualCounter == null) {
			ritualCounter = new Dictionary<RitualCircle, int>();
		}

		ritualCounter[ritualCircle] = 0;
	}

	public void AddChicken(RitualCircle ritualCircle) {
		string key = ritualCircle.gameObject.name;
		if (!ritualCounter.ContainsKey(ritualCircle)) {
			InitializeCircle(ritualCircle);
		}
		ritualCounter[ritualCircle]++;

		chickenCount++;

		CheckForWin();
	}

	private void CheckForWin() {
		if (chickenCount == totalChickenCount) {
			int minRatio = int.MaxValue;
			int minRatioCount = int.MaxValue;

			foreach (KeyValuePair<RitualCircle, int> ritual in ritualCounter) {
				if (ritual.Key.ritualType == 1) {
					if (ritual.Key.balanceRatio < minRatio) {
						minRatio = ritual.Key.balanceRatio;
						minRatioCount = ritual.Value;
					}
				}
			}

			bool failed = false;
			foreach (KeyValuePair<RitualCircle, int> ritual in ritualCounter) {
				if (ritual.Key.ritualType != 1) {
					continue;
				}

				if ((minRatioCount / minRatio * ritual.Key.balanceRatio) != ritual.Value) {
					failed = true;
					break;
				}
			}
			uiController.EndChallenge(!failed);
			ritualCounter = null;
		}
	}
}
