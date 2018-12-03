using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTextController : MonoBehaviour {

	public Text titleText;
	public Text levelText;
	public UIController uiController;

	private string[] titles = new string[] {
		"Introduction",
		"Corners",
		"Advanced Corners",
		"Splitters",
		"Advanced Splitters",
		"Finale"
	};

	private string[] levelTexts = new string[] {
		"Look, I know it's your first day on the job.  But, the Great Ones are getting hangry so we need to get get a move on.  All you have to do is sacrifice the chickens and it's job done.  Tap a floor tile to place a conveyor belt, then press play when you're ready.  Good luck!",
		"Seems you've got the hang of this, so how about something a little more difficult?  Use the rotational buttons to get around those pesky corners.",
		"Good work!  You're on your own for this one, so give it a try.",
		"Hey, it's me again.  I really didn't think you'd get that one, so you're doing pretty well.  The Great Ones are demanding balance.  That splitter will evenly distribute the chickens, it's up to you to get your ratios correct.  This one is easy, perfectly balanced as all things should be.",
		"Keep it up and you'll be in the running for cult member of the month.  Keep an eye on the ratios here and you'll get it in no time.",
		"You're almost there.  I have it on good authority that the Great Ones are almost satisfied.  On you go."
	};

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void SetLevelText(int level) {
		titleText.text = titles[level];
		levelText.text = levelTexts[level];

		uiController.ShowLevelText();
	}

	public void SetIntroductionText() {
		SetLevelText(0);
	}

	public void SetCornersText() {
		SetLevelText(1);
	}

	public void SetAdvancedCornersText() {
		SetLevelText(2);
	}

	public void SetSplittersText() {
		SetLevelText(3);
	}

	public void SetAdvancedSplittersText() {
		SetLevelText(4);
	}

	public void SetFinaleText() {
		SetLevelText(5);
	}
}
